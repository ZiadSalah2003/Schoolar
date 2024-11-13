using Schoolar.Core.Features.Departments.Queries.Contracts;
using Schoolar.Core.Features.Departments.Queries.Models;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Mapping.Departments
{
	public partial class DepartmentProfile
	{
		public void GetDepartmentByIdQueryMapping()
		{
			CreateMap<Department, GetDepartmentResponse>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.DepartmentNameAr, src.DepartmentName)))
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.MangerName, opt => opt.MapFrom(src => src.Instructor.Localize(src.Instructor.NameAr, src.Instructor.Name)))
				.ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
				.ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
				.ForMember(dest => dest.Instructors, opt => opt.MapFrom(src => src.Instructors));

		}
	}
}
