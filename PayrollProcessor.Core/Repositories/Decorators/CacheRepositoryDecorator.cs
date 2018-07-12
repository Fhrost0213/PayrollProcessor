using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories.Decorators
{
    public class CacheRepositoryDecorator : IEmployeeGetRepository
    {
        private readonly IEmployeeGetRepository _repo;
        private readonly Dictionary<int, Employee> _cache;

        public CacheRepositoryDecorator(IEmployeeGetRepository repo)
        {
            if (_cache is null)
                _cache = new Dictionary<int, Employee>();

            _repo = repo;
        }

        public Employee Get(int objectId)
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

        public List<Employee> GetList(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
