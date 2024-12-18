﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Students.Commands.Models;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Features.Students.Queries.Models;
using Schoolar.Core.Resources;
using Schoolar.Data.Entities;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Commands.Handlers
{
	public class StudentCommandHandler : ResponseHandler,
		IRequestHandler<CreateStudentCommand, Response<string>>,
		IRequestHandler<EditStudentCommand, Response<string>>,
		IRequestHandler<DeleteStudentCommand, Response<string>>
	{
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources> _localizer;
		public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_localizer = localizer;
		}

		public async Task<Response<string>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
		{
			var studentMapper = _mapper.Map<Student>(request);
			var student = await _studentService.CreateStudentAsync(studentMapper);

			if (student == "Success")
				return Created("");

			return BadRequest<string>("Something went wrong");
		}
		public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
		{
			var studentExist = await _studentService.GetStudentByIdAsync(request.Id);
			if (studentExist is null)
				return NotFound<string>("Student not found");

			var studentMapper = _mapper.Map(request, studentExist);
			var student = await _studentService.EditStudentAsync(studentMapper);

			if (student == "Success")
				return Success("Update Successfuly");

			return BadRequest<string>("Something went wrong");
		}

		public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
		{
			var studentExist = await _studentService.GetStudentByIdAsync(request.Id);
			if (studentExist is null)
				return NotFound<string>("Student not found");

			var result = await _studentService.DeleteStudentAsync(studentExist);

			if (result == "Success")
				return Deleted<string>("Deleted Successfuly");

			return BadRequest<string>("Something went wrong");
		}
	}
}
