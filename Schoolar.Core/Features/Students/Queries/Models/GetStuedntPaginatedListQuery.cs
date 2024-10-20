using MediatR;
using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Core.Wrappers;
using Schoolar.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Models
{
	public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
	{
		public int PageNumber { get; set; }
		public int PageSize { get; set; }
		public StudentOrderingEnum OrderBy { get; set; }
		public string? Search { get; set; }
	}
}
