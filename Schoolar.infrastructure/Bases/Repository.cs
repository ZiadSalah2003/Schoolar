using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Schoolar.infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schoolar.infrastructure.Bases
{
	public class GenericRepositoryAsync<T> : IGenericReposatoriyAsync<T> where T : class
	{
		protected readonly ApplicationDbContext _context;
        public GenericRepositoryAsync(ApplicationDbContext context)
        {
			_context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public virtual async Task AddRangeA(ICollection<T> entities)
		{
			await _context.AddRangeAsync(entities);
			await _context.SaveChangesAsync();
		}

		public IDbContextTransaction BeginTransaction()
		{
			return _context.Database.BeginTransaction();
		}

		public void Commit()
		{
			_context.Database.CommitTransaction();
		}

		public virtual async Task DeleteAsync(T entity)
		{
			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public virtual async Task DeleteRangeAsync(ICollection<T> entities)
		{
			foreach (var entity in entities)
			{
				_context.Entry(entity).State = EntityState.Deleted;
			}
			await _context.SaveChangesAsync();
		}

		public virtual async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public IQueryable<T> GetTableAsTracking()
		{
			return _context.Set<T>().AsQueryable();
		}

		public IQueryable<T> GetTableNoTracking()
		{
			return _context.Set<T>().AsNoTracking().AsQueryable();
		}

		public void RollBack()
		{
			_context.Database.RollbackTransaction();
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public virtual async Task UpdateAsync(T entity)
		{
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}

		public virtual async Task UpdateRangeAsync(ICollection<T> entities)
		{
			_context.Set<T>().UpdateRange(entities);
			await _context.SaveChangesAsync();
		}
	}
}
