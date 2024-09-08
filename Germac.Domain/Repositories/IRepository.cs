﻿namespace Germac.Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(string query, int id);
        Task<IEnumerable<T>> GetAll(string query);
        Task<int> Add(string query, T entity);
        Task<int> Update(string query, T entity);
        Task<int> Delete(string query, int id);
    }
}
