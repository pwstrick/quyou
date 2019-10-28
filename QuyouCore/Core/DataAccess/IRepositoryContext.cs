using System.Data.Linq;

namespace QuyouCore.Core.DataAccess
{
    public interface IRepositoryContext
    {
        Table<TEntity> GetTable<TEntity>() where TEntity : class;
        bool IsReadOnly { get; }
    }
}
