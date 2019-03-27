import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  private readonly PAGE_SIZE = 3;

  filterParam: string;
  queryResult: any = {};
  query: any = {
    pageSize: this.PAGE_SIZE
  };
  columns = [
    { title: 'Id' },
    { title: 'Name', key: 'name', isSortable: true },
    { title: 'Contract Type', key: 'contractTypeName', isSortable: true },
    { title: 'Role Id', key: 'roleId', isSortable: true },
    { title: 'Role Name', key: 'roleName', isSortable: true },
    { title: 'Role Description', key: 'roleDescription', isSortable: true },
    { title: 'Hourly Salary', key: 'hourlySalary', isSortable: true },
    { title: 'Monthly Salary', key: 'monthlySalary', isSortable: true },
    { title: 'Annual Salary', key: 'annualSalary', isSortable: true }
  ];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.populateEmployees();
  }

  private populateEmployees() {
    this.employeeService.getEmployees()
      .subscribe(employees => this.queryResult = employees);
  }

  private getSingleEmployee(id: number) {
    this.employeeService.getEmployee(id)
      .subscribe(employee => this.queryResult = employee);
  }

  filter() {
    debugger;
    if (this.filterParam === undefined || this.filterParam === '') {
      this.populateEmployees();
    }
    else {
      this.getSingleEmployee(+this.filterParam);
    }
  }

  onFilterChange() {
    this.query.page = 1;
    this.populateEmployees();
  }

  resetFilter() {
    this.query = {
      page: 1,
      pageSize: this.PAGE_SIZE
    };
    this.populateEmployees();
  }

  sortBy(columnName) {
    if (this.query.sortBy === columnName) {
      this.query.isSortAscending = !this.query.isSortAscending;
    } else {
      this.query.sortBy = columnName;
      this.query.isSortAscending = true;
    }
    this.populateEmployees();
  }

  onPageChange(page) {
    this.query.page = page;
    this.populateEmployees();
  }
}
