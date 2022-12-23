import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';

const routes: Routes = [
  {path:'', redirectTo:'/dashboard/usuario', pathMatch:'full'},
  {path:'', component: DashboardComponent},
  {path:'dashboard', loadChildren: () => import('./components/dashboard/dashboard.module').then(x => x.DashboardModule)},
  {path:'**', redirectTo:'/dashboard/usuario', pathMatch:'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
