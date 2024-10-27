﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Data.Entities
{
	public class Instructor
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int InstructorId { get; set; }
		public string? NameAr { get; set; }
		public string? Name { get; set; }
		public string? Address { get; set; }
		public string? Position { get; set; }
		public int? SupervisorId { get; set; }
		public decimal? Salary { get; set; }
		public int? DepartmentId { get; set; }
		[ForeignKey(nameof(DepartmentId))]
		[InverseProperty("Instructors")]
		public Department? department { get; set; }

		[InverseProperty("Instructor")]
		public Department? departmentManager { get; set; }


		[ForeignKey(nameof(SupervisorId))]
		[InverseProperty("Instructors")]
		public Instructor? Supervisor { get; set; }
		[InverseProperty("Supervisor")]
		public virtual ICollection<Instructor> Instructors { get; set; }

		[InverseProperty("instructor")]
		public virtual ICollection<InstructorSubject> InstructorSubjects { get; set; }

		public Instructor()
		{
			Instructors = new HashSet<Instructor>();
			InstructorSubjects = new HashSet<InstructorSubject>();
		}
	}
}
