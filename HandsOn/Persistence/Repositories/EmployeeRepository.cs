using AutoMapper;
using HandsOn.Core.Domain;
using HandsOn.Core.Dtos;
using HandsOn.Core.Repositories;
using HandsOn.Mapping;
using HandsOn.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandsOn.Persistence.Repositories
{
    public class EmployeeRepository : Repository<EmployeeDto>, IEmployeeRepository
    {
        private readonly IMapper mapper;

        public EmployeeRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeeWithAnnualSalary(int id)
        {
            try
            {
                IEnumerable<Employee> entities = await DataService<Employee>.GetData("api/Employees");

                var employee = entities.Where(e => e.Id == id);

                var employeesDto = new List<EmployeeDto>();

                foreach (var e in employee)
                {
                    var employeeDto = mapper.Map<Employee, EmployeeDto>(e);

                    switch (employeeDto.ContractTypeName)
                    {
                        case "HourlySalaryEmployee":
                            {
                                employeeDto.AnnualSalary = 120 * employeeDto.HourlySalary * 12;
                            }
                            break;
                        case "MonthlySalaryEmployee":
                            {
                                employeeDto.AnnualSalary = employeeDto.MonthlySalary * 12;
                            }
                            break;
                    }

                    employeesDto.Add(employeeDto);
                }

                return employeesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllWithAnnualSalary()
        {
            try
            {
                IEnumerable<Employee> entities = await DataService<Employee>.GetData("api/Employees");

                var employeesDto = new List<EmployeeDto>();

                foreach(var e in entities)
                {
                    var employeeDto = mapper.Map<Employee, EmployeeDto>(e);

                    switch (employeeDto.ContractTypeName)
                    {
                        case "HourlySalaryEmployee":
                            {
                                employeeDto.AnnualSalary = 120 * employeeDto.HourlySalary * 12;
                            }
                            break;
                        case "MonthlySalaryEmployee":
                            {
                                employeeDto.AnnualSalary = employeeDto.MonthlySalary * 12;
                            }
                            break;
                    }

                    employeesDto.Add(employeeDto);
                }

                return employeesDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
