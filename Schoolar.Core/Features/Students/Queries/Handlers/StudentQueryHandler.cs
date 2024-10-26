using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Features.Students.Queries.Models;
using Schoolar.Core.Resources;
using Schoolar.Core.Wrappers;
using Schoolar.Data.Entities;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Handlers
{
	public class StudentQueryHandler : ResponseHandler,
		IRequestHandler<GetStudentsQuery, Response<List<GetStudentsResponse>>>,
		IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
		IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;
		public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_localizer = localizer;
		}
		public async Task<Response<List<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var result = await _studentService.GetStudentsAsync();
			var resultMapper = _mapper.Map<List<GetStudentsResponse>>(result);
			var response = Success(resultMapper);
			response.Meta = new { Count = resultMapper.Count() };
			return response;
		}

		public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
			if (student is null)
				return NotFound<GetStudentResponse>(_localizer[SharedResourcesKeys.NotFound]);
			var resultMapper = _mapper.Map<GetStudentResponse>(student);
			return Success(resultMapper);
		}

		public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
		{
			Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.Localize(e.NameAr, e.Name), e.Address, e.Department.Localize(e.Department.DepartmentNameAr, e.Department.DepartmentName));
			//var querable = _studentService.GetStudentsQueryable();
			var filterQuery = _studentService.FilterStudentsPaginatedQueryable(request.OrderBy, request.Search);
			var paginatedList = await filterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
			paginatedList.Meta = new { Count = paginatedList.Data.Count() };
			return paginatedList;
		}
	}
}
