using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.Entities
{
	public class StudentSubject
	{
		[Key]
		public int StudentId { get; set; }
		[Key]
		public int SubjectId { get; set; }

		[ForeignKey("StudentId")]
		[InverseProperty("StudentSubjects")]
		public virtual Student Student { get; set; }
		[ForeignKey("SubjectId")]
		[InverseProperty("StudentsSubjects")]
		public virtual Subjects Subject { get; set; }
	}
}
