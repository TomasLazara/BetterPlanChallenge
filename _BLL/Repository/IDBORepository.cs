namespace _BLL.Repository
{
    public interface IDBORepository
    {
        Task<IEnumerable<Tout>> ResolveQuery<Tout>(string query);
    }
}