using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Core.Features.Departments.Queries.Contracts
{
	public record GetDepartmentResponse
	(
		int Id,
		string Name,
		string MangerName,
		List<StudentResponse>? Students,
		List<SubjectResponse>? Subjects,
		List<InstructorResponse>? Instructors

	);
	public class StudentResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class SubjectResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	public class InstructorResponse
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
