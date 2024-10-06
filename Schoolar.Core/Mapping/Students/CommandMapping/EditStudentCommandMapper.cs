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
		public void EditStudentCommandMapping()
		{
			CreateMap<EditStudentCommand, Student>()
					.ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
					.ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
		}
	}
}
