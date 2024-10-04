using AutoMapper;
using MediatR;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Features.Students.Queries.Models;
using Schoolar.Data.Entities;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Handlers
{
	public class StudentQueryHandler : ResponseHandler, IRequestHandler<GetStudentsQuery,Response<List<GetStudentsResponse>>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
        public StudentQueryHandler(IStudentService studentService, IMapper mapper)
        {
			_studentService= studentService;
			_mapper = mapper;
		}
		public async Task<Response<List<GetStudentsResponse>>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var result = await _studentService.GetStudentsAsync();
			var resultMapper = _mapper.Map<List<GetStudentsResponse>>(result);
			return Success(resultMapper);
		}
	}
}
