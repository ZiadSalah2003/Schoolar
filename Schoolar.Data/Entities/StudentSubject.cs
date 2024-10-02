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
		public int StudentSubjectId { get; set; }
		public int StudentId { get; set; }
		public int SubjectId { get; set; }

		[ForeignKey("StudID")]
		public virtual Student Student { get; set; }
		[ForeignKey("SubID")]
		public virtual Subjects Subject { get; set; }
	}
}
