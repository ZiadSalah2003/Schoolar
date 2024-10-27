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
	public class DepartmentConfigrations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{

			builder.HasKey(x => x.DepartmentId);
			builder.Property(x => x.DepartmentNameAr).HasMaxLength(500);

			builder.HasMany(x => x.Students)
				  .WithOne(x => x.Department)
				  .HasForeignKey(x => x.DepartmentId)
				  .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Instructor)
			.WithOne(x => x.departmentManager)
			.HasForeignKey<Department>(x => x.InstructorManger)
			.OnDelete(DeleteBehavior.Restrict);


		}
	}
}
