using Dapper;
using Germac.Domain.Repositories;

namespace Germac.Infrastructure.UnitOfWork
{
    public class GenericRepository<T>(IUnitOfWork unitOfWork) : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<T?> GetById(string query, long id)
        {
            var connection = _unitOfWork.Connection;
            return connection == null
                ? throw new InvalidOperationException("Database connection is not initialized.")
                : await connection.QueryFirstOrDefaultAsync<T>(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );
        }

        public async Task<IEnumerable<T>> GetAll(string query)
        {
            var connection = _unitOfWork.Connection;
            return connection == null
                ? throw new InvalidOperationException("Database connection is not initialized.")
                : await connection.QueryAsync<T>(
                query,
                transaction: _unitOfWork.Transaction
            );
        }

        public async Task<int> Add(string query, T entity)
        {
            var connection = _unitOfWork.Connection;
            return connection == null
                ? throw new InvalidOperationException("Database connection is not initialized.")
                : await connection.ExecuteAsync(
                query,
                entity,
                _unitOfWork.Transaction
            );
        }

        public async Task<int> Update(string query, T entity)
        {
            var connection = _unitOfWork.Connection;
            return connection == null
                ? throw new InvalidOperationException("Database connection is not initialized.")
                : await connection.ExecuteAsync(
                query,
                entity,
                _unitOfWork.Transaction
            );
        }

        public async Task<int> Delete(string query, long id)
        {
            var connection = _unitOfWork.Connection;
            return connection == null
                ? throw new InvalidOperationException("Database connection is not initialized.")
                : await connection.ExecuteAsync(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );
        }
    }
}
