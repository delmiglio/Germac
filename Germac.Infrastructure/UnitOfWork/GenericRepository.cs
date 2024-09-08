using Dapper;
using Germac.Domain.Repositories;

namespace Germac.Infrastructure.UnitOfWork
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<T> GetById(string query, long id)
        {
            return await _unitOfWork.Connection.QueryFirstAsync<T>(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );
        }

        public async Task<IEnumerable<T>> GetAll(string query)
        {
            return await _unitOfWork.Connection.QueryAsync<T>(
                query,
                transaction: _unitOfWork.Transaction
            );
        }

        public async Task<int> Add(string query, T entity)
        {
            return await _unitOfWork.Connection.ExecuteAsync(
                query,
                entity,
                _unitOfWork.Transaction
            );
        }

        public async Task<int> Update(string query, T entity)
        {
            return await _unitOfWork.Connection.ExecuteAsync(
                query,
                entity,
                _unitOfWork.Transaction
            );
        }

        public async Task<int> Delete(string query, long id)
        {
            return await _unitOfWork.Connection.ExecuteAsync(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );
        }
    }
}
