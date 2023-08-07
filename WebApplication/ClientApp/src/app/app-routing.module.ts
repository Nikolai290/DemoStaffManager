import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {MainComponent} from "./pages/main/main.component";
import {EmployeesComponent} from "./pages/employees/employees.component";

const routes: Routes = [
  { path: "employees", component: EmployeesComponent, pathMatch: "full"},
  { path: "home", component: MainComponent, pathMatch: "prefix"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
