using System.Data;

namespace Germac.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
    }
}
