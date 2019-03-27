using AutoMapper;
using HandsOn.Core;
using HandsOn.Core.Repositories;
using HandsOn.Persistence.Repositories;

namespace HandsOn.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMapper _mapper;

        public IEmployeeRepository Employees { get; private set; }

        public UnitOfWork(IMapper mapper)
        {
            _mapper = mapper;
            Employees = new EmployeeRepository(_mapper);
        }
    }
}
