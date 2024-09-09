using System.Data;

namespace Germac.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDbConnection _connection;
        private IDbTransaction? _transaction;
        private bool _disposed = false;

        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IDbConnection Connection => _connection;

        public IDbTransaction? Transaction => _transaction;

        // Implement IDisposable
        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;

            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected virtual method for derived classes to override
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    _connection?.Dispose();
                }

                // Dispose unmanaged resources (if any)

                _disposed = true;
            }
        }

        // Destructor / Finalizer (only if needed)
        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                Dispose();
            }
        }
    }
}
