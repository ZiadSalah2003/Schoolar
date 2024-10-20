using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Students.Queries.Contracts
{
	public class GetStudentPaginatedListResponse
	{ 
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? DepartmentName { get; set; }
        public GetStudentPaginatedListResponse(string? name,string? address,string? DepartmentName)
        {
            Name = name;
			Address = address;
			DepartmentName = DepartmentName;
		}
    }
}
