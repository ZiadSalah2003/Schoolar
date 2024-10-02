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
        public Subjects()
        {
			StudentsSubjects = new HashSet<StudentSubject>();
			DepartmetsSubjects = new HashSet<DepartmetSubject>();
		}
        [Key]
		public int SubjectId { get; set; }
		[StringLength(500)]
		public string? SubjectNameAr { get; set; }
		public DateTime Period { get; set; }
		public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
		public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
	}
}
