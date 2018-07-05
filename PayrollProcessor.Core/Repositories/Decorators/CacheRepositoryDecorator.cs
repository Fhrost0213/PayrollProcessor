using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories.Decorators
{
    public class CacheRepositoryDecorator : IGetRepository
    {
        private readonly IGetRepository _repo;
        private readonly Dictionary<int, IEntity> _cache;

        public CacheRepositoryDecorator(IGetRepository repo)
        {
            if (_cache is null)
                _cache = new Dictionary<int, IEntity>();

            _repo = repo;
        }

        public IEntity Get(int objectId)
        {
            if (_cache.ContainsKey(objectId))
            {
                return _cache[objectId];
            }
            else
            {
                var entity = _repo.Get(objectId);
                _cache.Add(objectId, entity);

                return entity;
            }
        }
    }
}
