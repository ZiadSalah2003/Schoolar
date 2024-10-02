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
		public int DepartmetSubjectId { get; set; }
		public int DepartmetId { get; set; }
		public int SubjectId { get; set; }

		[ForeignKey("DID")]
		public virtual Department Department { get; set; }

		[ForeignKey("SubID")]
		public virtual Subjects Subject { get; set; }
	}
}
