﻿using MediatR;
using Schoolar.Core.Bases;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Commands.Models
{
	public class CreateStudentCommand : IRequest<Response<string>>
	{
		public string? Name { get; set; }
		public string? NameAr { get; set; }
		public string? Address { get; set; }
		public string? Phone { get; set; }
		public int DepartmentId { get; set; }
	}
}
