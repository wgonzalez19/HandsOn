using System.Collections.Generic;
using System.Threading.Tasks;
using HandsOn.Core;
using HandsOn.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace HandsOn.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> Get()
        {
            var employees = await _unitOfWork.Employees.GetAllWithAnnualSalary();

            return employees;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _unitOfWork.Employees.GetEmployeeWithAnnualSalary(id);

            return Ok(employee);
        }

    }
}
