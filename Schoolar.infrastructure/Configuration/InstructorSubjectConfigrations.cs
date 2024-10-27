using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schoolar.Data.Entities;

namespace Schoolar.infrastructure.Configuration
{
	public class InstructorSubjectConfigrations : IEntityTypeConfiguration<InstructorSubject>
	{
		public void Configure(EntityTypeBuilder<InstructorSubject> builder)
		{
			builder
				.HasKey(x => new { x.SubjectId, x.InstructorId });


			builder.HasOne(ds => ds.instructor)
					 .WithMany(d => d.InstructorSubjects)
					 .HasForeignKey(ds => ds.InstructorId);

			builder.HasOne(ds => ds.Subject)
				 .WithMany(d => d.InstructorSubjects)
				 .HasForeignKey(ds => ds.SubjectId);

		}
	}
}
