using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Schoolar.Data.Entities;
using Schoolar.infrastructure.Abstracts;
using Schoolar.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Service.Implementations
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentService(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;

		}
		public Task<Department> GetDepartmentByIdAsync(int id)
		{
			var department =_departmentRepository.GetTableAsTracking().Where(x => x.DepartmentId == id)
																	  .Include(x=>x.DepartmentSubjects).ThenInclude(x => x.Subject)
																	  .Include(x=>x.Students)
																	  .Include(x=>x.Instructors)
																	  .Include(x=>x.Instructor).FirstOrDefaultAsync();
			return department;
		}
	}
}
