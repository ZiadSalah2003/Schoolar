using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.Entities
{
	public class InstructorSubject
	{
		[Key]
		public int InstructorId { get; set; }
		[Key]
		public int SubjectId { get; set; }
		[ForeignKey(nameof(InstructorId))]
		[InverseProperty("InstructorSubjects")]
		public Instructor? instructor { get; set; }
		[ForeignKey(nameof(SubjectId))]
		[InverseProperty("InstructorSubjects")]
		public Subjects? Subject { get; set; }
	}
}
