using Schoolar.Core.Features.Students.Commands.Models;
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
		public void CreateStudentCommandMapping()
		{
			CreateMap<CreateStudentCommand, Student>()
				.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
				.ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
		}
	}
}
