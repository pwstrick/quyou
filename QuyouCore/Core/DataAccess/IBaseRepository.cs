namespace QuyouCore.Core.DataAccess
{
    public interface IBaseRepository<T>
    {
        int Insert(T data);
        void Update(T data);
        void Delete(int id);
    }
}
