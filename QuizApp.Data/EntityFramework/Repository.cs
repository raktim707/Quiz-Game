using Microsoft.EntityFrameworkCore;
using QuizApp.Data.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data.EntityFramework
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class, new()
    {
        private readonly DbSet<T> _objectSet;
        public Repository()
        {
            _objectSet = context.Set<T>();
        }
       
        public IQueryable<T> RawList(string sqlCommand = "", Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            var x = context.Set<T>().FromSqlRaw(sqlCommand).AsNoTracking();

            if (orderBy != null)
                return orderBy(x);

            return x;
        }
        public bool Insert(T obj)
        {
            _objectSet.Add(obj);
            bool status = Save();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        public bool Update(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;

            bool status = Save();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        public bool Delete(T obj)
        {
            _objectSet.Remove(obj);
            bool status = Save();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        private bool Save()
        {
            bool transactionResult = context.SaveChanges() > 0;
            return transactionResult;
        }
        public IQueryable<T> List(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = _objectSet;
            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                return orderBy(query);

            return query.AsNoTracking();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        public IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where);
        }
        public IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where).AsNoTracking();
        }
        #region Async Methods
        private async Task<bool> SaveAsync()
        {
            bool transactionResult = await context.SaveChangesAsync() > 0;
            return transactionResult;
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await _objectSet.Where(where).FirstOrDefaultAsync();
        }
        
        public async Task<bool> InsertAsync(T obj)
        {
            await _objectSet.AddAsync(obj);
            bool status = Save();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        public async Task<bool> UpdateAsync(T obj)
        {
            context.Entry(obj).State = EntityState.Modified;

            bool status = await SaveAsync();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        public async Task<bool> DeleteAsync(T obj)
        {
            _objectSet.Remove(obj);
            bool status = await SaveAsync();
            context.Entry<T>(obj).State = EntityState.Detached;
            return status;
        }
        #endregion
    }
}
