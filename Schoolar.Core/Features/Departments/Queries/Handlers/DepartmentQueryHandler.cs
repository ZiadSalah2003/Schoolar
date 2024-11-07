using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Departments.Queries.Contracts;
using Schoolar.Core.Features.Departments.Queries.Models;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Resources;
using Schoolar.Service.Abstracts;
using Schoolar.Service.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Departments.Queries.Handlers
{
	public class DepartmentQueryHandler : ResponseHandler,
		IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentResponse>>
	{
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;
		public DepartmentQueryHandler(IDepartmentService departmentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
		{
			_departmentService = departmentService;
			_mapper = mapper;
			_localizer = localizer;
		}

		public async Task<Response<GetDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			var response = await _departmentService.GetDepartmentByIdAsync(request.Id);
			if (response is null)
				return NotFound<GetDepartmentResponse>(_localizer[SharedResourcesKeys.NotFound]);
			var resultMapper = _mapper.Map<GetDepartmentResponse>(response);
			return Success(resultMapper);
		}
	}
}
