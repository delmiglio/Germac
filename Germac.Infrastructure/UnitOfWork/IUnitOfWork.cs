using System.Data;

namespace Germac.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
        new void Dispose();

        IDbConnection? Connection { get; }
        IDbTransaction? Transaction { get; }
    }
}
