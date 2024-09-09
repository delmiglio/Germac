using Dapper;
using Germac.Domain.Repositories;
using Serilog;


namespace Germac.Infrastructure.UnitOfWork
{
    public class GenericRepository<T>(IUnitOfWork unitOfWork, ILogger logger) : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger _logger = logger.ForContext("RepositoryType", typeof(T).Name); // Contextual logger
        public async Task<T?> GetById(string query, long id)
        {
            _logger.Information("Executing GetById with id: {Id}", id);
            _logger.Debug("Query: {Query}, Parameters: {Parameters}", query, new { Id = id });

            var connection = _unitOfWork.Connection;
            if (connection == null)
            {
                _logger.Error("Database connection is null while attempting GetById.");
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            var result = await connection.QueryFirstOrDefaultAsync<T>(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );

            _logger.Information("GetById result for id: {Id} is: {Result}", id, result);
            return result;
        }

        public async Task<IEnumerable<T>> GetAll(string query)
        {
            _logger.Information("Executing GetAll");
            _logger.Debug("Query: {Query}", query);

            var connection = _unitOfWork.Connection;
            if (connection == null)
            {
                _logger.Error("Database connection is null while attempting GetAll.");
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            var result = await connection.QueryAsync<T>(
                query,
                transaction: _unitOfWork.Transaction
            );

            _logger.Information("GetAll result count: {Count}", result?.Count() ?? 0);
            return result ?? [];
        }

        public async Task<int> Add(string query, T entity)
        {
            _logger.Information("Executing Add with entity: {Entity}", entity);
            _logger.Debug("Query: {Query}, Parameters: {Entity}", query, entity);

            var connection = _unitOfWork.Connection;
            if (connection == null)
            {
                _logger.Error("Database connection is null while attempting Add.");
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            var rowsAffected = await connection.ExecuteScalarAsync<int>(
                query,
                entity,
                _unitOfWork.Transaction
            );

            _logger.Information("Add operation completed. Rows affected: {RowsAffected}", rowsAffected);
            _unitOfWork.Commit();
            return rowsAffected;
        }

        public async Task<int> Update(string query, T entity)
        {
            _logger.Information("Executing Update with entity: {Entity}", entity);
            _logger.Debug("Query: {Query}, Parameters: {Entity}", query, entity);

            var connection = _unitOfWork.Connection;
            if (connection == null)
            {
                _logger.Error("Database connection is null while attempting Update.");
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            var rowsAffected = await connection.ExecuteAsync(
                query,
                entity,
                _unitOfWork.Transaction
            );

            _logger.Information("Update operation completed. Rows affected: {RowsAffected}", rowsAffected);
            _unitOfWork.Commit();
            return rowsAffected;
        }

        public async Task<int> Delete(string query, long id)
        {
            _logger.Information("Executing Delete with id: {Id}", id);
            _logger.Debug("Query: {Query}, Parameters: {Id}", query, new { Id = id });

            var connection = _unitOfWork.Connection;
            if (connection == null)
            {
                _logger.Error("Database connection is null while attempting Delete.");
                throw new InvalidOperationException("Database connection is not initialized.");
            }

            var rowsAffected = await connection.ExecuteAsync(
                query,
                new { Id = id },
                _unitOfWork.Transaction
            );

            _logger.Information("Delete operation completed. Rows affected: {RowsAffected}", rowsAffected);
            _unitOfWork.Commit();
            return rowsAffected;
        }
    }
}
