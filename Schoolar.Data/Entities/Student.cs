﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Data.Commons;

namespace Schoolar.Data.Entities
{
	public class Student : GeneralLocalizableEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int StudentId { get; set; }
		[StringLength(200)]
		public string? NameAr { get; set; }
		[StringLength(200)]
		public string? Name { get; set; }

		[StringLength(500)]
		public string? Address { get; set; }
		[StringLength(500)]
		public string? Phone { get; set; }
		public int? DepartmentId { get; set; }

		[ForeignKey("DepartmentId")]
		[InverseProperty("Students")]
		public virtual Department? Department { get; set; }
		[InverseProperty("Student")]
		public virtual ICollection<StudentSubject> StudentSubject { get; set; }

		public Student()
		{
			StudentSubject = new HashSet<StudentSubject>();
		}
	}
}
