using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Contracts
{
	public record GetStudentsResponse
	(
		string? Name,
		string? Address,
		string? DepartmentName
	);
}
