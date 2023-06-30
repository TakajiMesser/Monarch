using Monarch.Shared.Models;

namespace Monarch.Shared.Repositories
{
    public interface IRepository<TModel> where TModel : IModel
    {
        IEnumerable<int> GetIDs();

        TModel Get(int id);
        TModel? GetOrDefault(int id);

        void InsertOrUpdate(TModel model);
    }
}
