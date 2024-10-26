using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Data.Commons;

namespace Schoolar.Data.Entities
{
	public partial class Department : GeneralLocalizableEntity
	{
        public Department()
        {
            Students= new HashSet<Student>();
			DepartmentSubjects = new HashSet<DepartmetSubject>();
		}
        [Key]
		public int DepartmentId { get; set; }
		[StringLength(500)]
		public string? DepartmentNameAr { get; set; }
		[StringLength(500)]
		public string? DepartmentName { get; set; }
		public int InstructorManger { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<Student> Students { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
		[InverseProperty("Department")]
		public virtual ICollection<Instructor> Instructors { get; set; }
		[ForeignKey("InstructorManger")]
		[InverseProperty("DepartmentManger")]
		public virtual Instructor Instructor { get; set; }
	}
}
