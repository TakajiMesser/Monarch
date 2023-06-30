using Monarch.Shared.Models;

namespace Monarch.Shared.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : IModel
    {
        private readonly List<TModel> _models = new();

        public IEnumerable<int> GetIDs() => _models.Select(m => m.ID);

        public TModel Get(int id) => _models[id - 1];

        public TModel? GetOrDefault(int id) => id <= _models.Count ? Get(id) : default;

        public void InsertOrUpdate(TModel model)
        {
            if (model.ID < _models.Count)
            {
                _models[model.ID - 1] = model;
            }
            else
            {
                _models.Add(model);
            }
        }
    }
}
