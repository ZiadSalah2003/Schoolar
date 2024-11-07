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
	public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
	{
		private readonly DbSet<Department> _department;
		public DepartmentRepository(ApplicationDbContext context):base(context)
        {
			_department = context.Set<Department>();
		}
        public Task<List<Department>> GetDepartmentsAsync()
		{
			throw new NotImplementedException();
		}
	}
}
