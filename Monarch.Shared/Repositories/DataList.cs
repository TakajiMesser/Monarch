using Monarch.Shared.Data.Entities;
using System.Collections.Generic;

namespace Monarch.Shared.Repositories
{
    public class DataList<TEntity> where TEntity : IEntity
    {
        private readonly List<TEntity> _entities = new();

        public TEntity Get(int id) => _entities[id - 1];

        public int GetNextID() => _entities.Count + 1;

        public void Insert(TEntity entity) => _entities[entity.ID - 1] = entity;

        public void Update(TEntity entity) => _entities[entity.ID + 1] = entity;

        public void Delete()
        {
            // TODO
        }
    }
}
