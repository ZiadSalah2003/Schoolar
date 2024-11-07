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
	public class SubjectRepository : GenericRepositoryAsync<Subjects>, ISubjectRepository
	{
		private readonly DbSet<Subjects> _subject;
		public SubjectRepository(ApplicationDbContext context) : base(context)
		{
			_subject = context.Set<Subjects>();
		}
	}
}
