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
	public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder
			   .HasOne(x => x.Supervisor)
			   .WithMany(x => x.Instructors)
			   .HasForeignKey(x => x.SupervisorId)
			   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}
