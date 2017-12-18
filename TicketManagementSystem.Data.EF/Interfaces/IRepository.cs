﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TicketManagementSystem.Data.EF.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int GetCount();
        int GetCount(Expression<Func<T, bool>> predicate);

        bool IsEmpty();
        bool ExistsById(int id);
        bool Any(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);

        IQueryable<T> GetAllWithInclude();
        IQueryable<T> GetAllWithInclude(Expression<Func<T, bool>> predicate);
        T GetByIdWithInclude(int id);

        T Create(T item);
        void Update(T item);
        void Remove(T item);
        void Remove(int id, string table);
        void RemoveRange(IEnumerable<T> entities);

        #region Async methods.

        Task<int> GetCountAsync();
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);

        Task<bool> IsEmptyAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);

        #endregion
    }
}
