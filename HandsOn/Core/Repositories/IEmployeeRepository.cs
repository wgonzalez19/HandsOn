using HandsOn.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HandsOn.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<EmployeeDto>
    {
        Task<EmployeeDto> GetEmployeeWithAnnualSalary(int id);

        Task<IEnumerable<EmployeeDto>> GetAllWithAnnualSalary();
    }
}
