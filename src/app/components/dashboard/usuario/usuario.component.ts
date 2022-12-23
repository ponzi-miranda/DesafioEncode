import { HttpHeaderResponse } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Actividad } from 'src/app/interfaces/actividad';
import { Usuario } from 'src/app/interfaces/usuario';
import { ActividadService } from 'src/app/services/actividad.service';
import { UsuarioService } from 'src/app/services/usuario.service';


@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent{
  loading: boolean = false;
  id: number | undefined;
  idUser: number = 0;
  operacion: string = 'Alta';
  btOperacion: string = 'Crear';
  form: FormGroup;

  constructor(private fb: FormBuilder, private _usuarioService: UsuarioService, private _actividadService : ActividadService,
    private route: ActivatedRoute, private _snackBar: MatSnackBar, private router: Router){      
    this.form = this.fb.group({
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      correo_electronico: ['', Validators.email],
      fecha_nacimiento: ['', Validators.required],
      telefono: [''],
      pais_residencia: ['', Validators.required],
      info: false

    })
    
    route.params.subscribe(params => {
      this.id = params['idUsuario']; })
  }

  ngOnInit(): void {
    this.esEditar(this.id);
  }

  esEditar(id: number | undefined){
    if(id !== undefined){
      this.operacion = 'Editar';
      this.btOperacion = 'Modificar';
      this.getUsuario(id);
    }
  }

  getUsuario(id: number){
    this.idUser = id;
    this._usuarioService.getUsuario(id).subscribe(data => {
      this.form.patchValue({
        nombre: data.nombre,
        apellido: data.apellido,
        correo_electronico: data.correoElectronico,
        fecha_nacimiento: data.fechaNacimiento,
        telefono: data.telefono,
        pais_residencia: data.paisResidencia,
        info: data.informacionContacto
      })
    })
  }

  altaUsuario(){

    this.loading = true;
    if(this.form.invalid){
      return;
    }
    const usuario: Usuario = {
      id: this.id,
      nombre: this.form.value.nombre,
      apellido: this.form.value.apellido,
      correoElectronico: this.form.value.correo_electronico,
      fechaNacimiento: this.form.value.fecha_nacimiento,
      telefono: this.form.value.telefono,
      paisResidencia: this.form.value.pais_residencia,
      informacionContacto: this.form.value.info 
    }
    
    console.log(usuario, this.form);

    if(usuario.id){
      this._usuarioService.updateUsuario(this.idUser, usuario).subscribe((response : any) =>{
        const actividad: Actividad={
          idUsuario: this.idUser,
          actividadDescripcion: 'MODIFICACION DE DATOS'
        }
        this._actividadService.addActividad(actividad).subscribe((respons: any) => { 
          this.mensaje('Usuario modificado!')
        })
      })
    }else{
      this._usuarioService.addUsuario(usuario).subscribe((response: any) => { 

        const actividad: Actividad={
          idUsuario: response.id,
          actividadDescripcion: 'ALTA USUARIO'
        }
        this._actividadService.addActividad(actividad).subscribe((respons: any) => { 
          this.mensaje('Usuario dado de alta!')
        })
      })
    }   
    this.loading = false;
    this.router.navigateByUrl('/dashboard/usuario');
  }

  mensaje(msg: string){
    this._snackBar.open(msg, '',{
      duration: 2000
    })
  }


}
