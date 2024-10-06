using MediatR;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Models
{
	public class GetStudentByIdQuery : IRequest<Response<GetStudentResponse>>
	{
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
