using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LeaveManagementDbContext _dbContext;
        public GenericRepository(LeaveManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return null;
        }

        public async Task<bool> Exists(int id)
        {
            var entity = Get(id);
            return entity != null;
        }

        public async Task<T> Get(int Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return null;
        }
    }
}
