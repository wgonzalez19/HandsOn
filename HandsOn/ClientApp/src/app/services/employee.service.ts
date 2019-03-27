import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { map } from 'rxjs/operators';

@Injectable()
export class EmployeeService {

  constructor(private http: Http) { }

  getEmployee(id: number) {
    return this.http.get(`/api/Employees/${id}`)
      .pipe(map(res => res.json()));
  }

  getEmployees() {
    return this.http.get(`/api/Employees`)
      .pipe(map(res => res.json()));
  }

}
