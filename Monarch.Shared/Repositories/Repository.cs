using Monarch.Shared.Models;
using System.Collections.Generic;

namespace Monarch.Shared.Repositories
{
    public abstract class Repository<TModel> : IRepository<TModel> where TModel : IModel
    {
        private readonly List<TModel> _models = new();

        public TModel Get(int id) => _models[id - 1];

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
