using System.Collections.Generic;
using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public interface IGetRepository
    {
        IEntity Get(int id);

        List<IEntity> GetList(int id);
    }
}
