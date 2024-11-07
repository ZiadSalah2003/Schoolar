using Microsoft.EntityFrameworkCore;
using Schoolar.Data.Entities;
using Schoolar.infrastructure.Abstracts;
using Schoolar.infrastructure.Bases;
using Schoolar.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Repositories
{
	public class InstructorRepository :GenericRepositoryAsync<Instructor>, IInstructorRepository
	{
		private readonly DbSet<Instructor> _instructor;
        public InstructorRepository(ApplicationDbContext context):base(context)
        {
			_instructor = context.Set<Instructor>();
		}
    }
}
