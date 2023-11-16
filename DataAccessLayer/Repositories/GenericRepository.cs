using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> :IGenericDal<T> where T : BaseEntity
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context = context;
        }

		public T Add(T entity)
		{
            if (entity == null) throw new ArgumentNullException("Entity Not Null");
            EntityEntry<T> addResult = this._context.Add(entity);
            this._context.SaveChanges();
            return addResult.Entity;
		}

		public bool Any(Expression<Func<T, bool>> filter)
		{
			bool sss1 = this._context.Set<T>().Any(filter);
			return true;
		}

		public T Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
		{
			IQueryable<T> query = this._context.Set<T>().AsNoTracking().AsQueryable();
			if (filter != null)
				query = query.Where(filter);

			if (include != null)
				query = include(query);

			return query.FirstOrDefault();
		}

		public List<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = this._context.Set<T>().AsNoTracking().AsQueryable();
            if (filter != null)
                query = query.Where(filter);

            if (include != null)
                query = include(query);

            return query.ToList();
        }

		public T Update(T entity)
		{
			if (entity == null) throw new ArgumentNullException("Entity Not Null");
			EntityEntry<T> addResult = this._context.Update(entity);
			this._context.SaveChanges();
			return addResult.Entity;
		}
	}
}
