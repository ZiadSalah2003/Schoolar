using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.Entities
{
	public class Subjects
	{
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int SubjectId { get; set; }
		[StringLength(500)]
		public string? SubjectNameAr { get; set; }
		[StringLength(500)]
		public string? SubjectName { get; set; }
		public DateTime Period { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
		[InverseProperty("Subject")]
		public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

		public Subjects()
		{
			StudentsSubjects = new HashSet<StudentSubject>();
			DepartmetsSubjects = new HashSet<DepartmetSubject>();
			InstructorSubjects = new HashSet<InstructorSubject>();
		}
	}
}
