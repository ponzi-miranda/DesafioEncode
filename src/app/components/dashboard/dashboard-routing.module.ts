import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActividadesComponent } from './actividades/actividades.component';
import { DashboardComponent } from './dashboard.component';
import { UsuarioComponent } from './usuario/usuario.component';

const routes: Routes = [
  {path:'', component: DashboardComponent, children: [
    {path: 'usuario', component: UsuarioComponent},
    {path: 'usuario/:idUsuario', component: UsuarioComponent},
    {path: 'actividades', component: ActividadesComponent},
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
