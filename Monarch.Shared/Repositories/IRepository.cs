using Monarch.Shared.Models;

namespace Monarch.Shared.Repositories
{
    public interface IRepository<TModel> where TModel : IModel
    {
        TModel Get(int id);

        void InsertOrUpdate(TModel model);
    }
}
