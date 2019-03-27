using HandsOn.Core.Repositories;

namespace HandsOn.Core
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
    }
}
