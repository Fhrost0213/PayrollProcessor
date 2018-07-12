using PayrollProcessor.Core.Entities;

namespace PayrollProcessor.Core.Repositories
{
    public interface IGetRepository
    {
        T Get<T>(int objectId);
    }
}
