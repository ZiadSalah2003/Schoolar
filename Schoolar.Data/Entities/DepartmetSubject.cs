using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.Entities
{
	public class DepartmetSubject
	{
		[Key]
		public int DepartmetId { get; set; }
		[Key]
		public int SubjectId { get; set; }

		[ForeignKey("DepartmetId")]
		[InverseProperty("DepartmentSubjects")]
		public virtual Department Department { get; set; }

		[ForeignKey("SubjectId")]
		public virtual Subjects Subject { get; set; }
	}
}
