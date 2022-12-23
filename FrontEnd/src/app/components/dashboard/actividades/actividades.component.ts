import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { ActividadService } from 'src/app/services/actividad.service';
import { Actividad } from 'src/app/interfaces/actividad';
import { MatDialog } from '@angular/material/dialog';
import { UsuarioComponent } from '../usuario/usuario.component';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-actividades',
  templateUrl: './actividades.component.html',
  styleUrls: ['./actividades.component.css']
})
export class ActividadesComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['fechaCreacion', 'nombre', 'actividadDescripcion', 'acciones'];
  dataSource = new MatTableDataSource<Actividad>();
  loading: boolean = false;

  @ViewChild(MatPaginator) paginator!: MatPaginator
  @ViewChild(MatSort) sort!: MatSort;

  constructor(public dialog: MatDialog, private _snackBar: MatSnackBar, private _actividadService: ActividadService,
    private _usuarioService: UsuarioService) {

      this.obtenerActividades();

     }

  ngOnInit(): void {
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    if (this.dataSource.data.length > 0) {
      this.paginator._intl.itemsPerPageLabel = 'Items por pagina'
    }
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  obtenerActividades() {

    this.loading = true;
    this._actividadService.getActividades().subscribe(data => {
      this.loading = false;
      this.dataSource.data = data.reverse();
      console.log(data)
    })
  }


  deleteUsuario(id: number){
    this.loading = true;
 
      const actividad: Actividad={
        idUsuario: id,
        actividadDescripcion: 'USUARIO ELIMINADO'
      }
      this._actividadService.addActividad(actividad).subscribe((respons: any) => { 
      })

      this._usuarioService.deleteUsuario(id).subscribe(() => {
        this.mensaje('Usuario eliminado.');
      })

    this.obtenerActividades();

    this.loading = false;
  }
  
  mensaje(msg: string){
    this._snackBar.open(msg, '',{
      duration: 2000
    })
  }


}
