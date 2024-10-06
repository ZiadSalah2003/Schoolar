using Schoolar.Core.Features.Students.Queries.Contracts;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Mapping.Students
{
	public partial class StudentProfile
	{
		public void GetStudentsQueryMapping()
		{
			CreateMap<Student, GetStudentsResponse>()
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName));
		}
	}
}
