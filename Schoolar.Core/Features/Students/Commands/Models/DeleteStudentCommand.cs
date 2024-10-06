﻿using MediatR;
using Schoolar.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Commands.Models
{
	public class DeleteStudentCommand : IRequest<Response<string>>
	{
		public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
