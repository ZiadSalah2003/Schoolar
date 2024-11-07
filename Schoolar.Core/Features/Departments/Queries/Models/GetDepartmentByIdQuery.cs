using MediatR;
using Schoolar.Core.Bases;
using Schoolar.Core.Features.Departments.Queries.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Departments.Queries.Models
{
	public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentResponse>>
	{
		public int Id { get; set; }
		public GetDepartmentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
