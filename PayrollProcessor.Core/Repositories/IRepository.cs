using System.Collections.Generic;

namespace PayrollProcessor.Core.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);

        List<T> GetList(int id);
    }
}
