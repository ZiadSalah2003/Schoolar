using Schoolar.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.Service.Abstracts
{
	public interface IDepartmentService
	{
		public Task<Department> GetDepartmentByIdAsync(int id);
	}
}
