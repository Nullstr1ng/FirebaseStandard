namespace FirebaseStandard.Database.Offline
{
    using FirebaseStandard.Database.Query;

    using System.Threading.Tasks;

    public interface ISetHandler<in T>
    {
        Task SetAsync(ChildQuery query, string key, OfflineEntry entry);
    }
}
