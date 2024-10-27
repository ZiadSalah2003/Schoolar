﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Configuration
{
	public class StudentSubjectConfigurations : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder
			   .HasKey(x => new { x.StudentId, x.SubjectId });


			builder.HasOne(ds => ds.Student)
					 .WithMany(d => d.StudentSubject)
					 .HasForeignKey(ds => ds.StudentId);

			builder.HasOne(ds => ds.Subject)
				 .WithMany(d => d.StudentsSubjects)
				 .HasForeignKey(ds => ds.SubjectId);

		}
	}
}
