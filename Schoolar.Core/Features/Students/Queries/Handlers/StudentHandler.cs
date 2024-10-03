using AutoMapper;
using MediatR;
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
	public class StudentHandler : IRequestHandler<GetStudentsQuery, List<GetStudentsResponse>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
        public StudentHandler(IStudentService studentService, IMapper mapper)
        {
			_studentService= studentService;
			_mapper = mapper;
		}
		public async Task<List<GetStudentsResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			var result = await _studentService.GetStudentsAsync();
			var resultMapper = _mapper.Map<List<GetStudentsResponse>>(result);
			return resultMapper;
		}
	}
}
