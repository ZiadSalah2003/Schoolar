using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Configuration
{
	public class DepartmentSubjectConfigurations : IEntityTypeConfiguration<DepartmetSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmetSubject> builder)
		{
			builder.HasKey(x => new { x.SubjectId, x.DepartmetId });

			builder.HasOne(ds => ds.Department)
				 .WithMany(d => d.DepartmentSubjects)
				 .HasForeignKey(ds => ds.DepartmetId);

			builder.HasOne(ds => ds.Subject)
				 .WithMany(d => d.DepartmetsSubjects)
				 .HasForeignKey(ds => ds.SubjectId);


		}
	}
}
