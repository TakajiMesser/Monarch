using Monarch.Shared.Models;
using System.Collections.Generic;

namespace Monarch.Shared.Repositories
{
    public class ModelList<TModel> where TModel : IModel
    {
        private readonly List<TModel> _models = new();

        public TModel Get(int id) => _models[id - 1];

        public int GetNextID() => _models.Count + 1;

        public void Insert(TModel model) => _models[model.ID - 1] = model;

        public void Update(TModel model) => _models[model.ID + 1] = model;

        public void Delete()
        {
            // TODO
        }
    }
}
