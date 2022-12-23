import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Modulos
import {ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


//Angular Material
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatSortModule} from '@angular/material/sort';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatTabsModule} from '@angular/material/tabs';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import { MatNativeDateModule } from '@angular/material/core';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SpinnerComponent } from './spinner/spinner.component'
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDialogModule} from '@angular/material/dialog';



@NgModule({
  declarations: [
    SpinnerComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatSidenavModule,
    MatTabsModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatListModule,
    MatCardModule,
    MatGridListModule,
    MatDatepickerModule,
    MatSlideToggleModule,
    MatNativeDateModule,
    HttpClientModule,
    MatSnackBarModule,
    MatProgressBarModule,
    ReactiveFormsModule,
    MatDialogModule
    
  ],
  exports:[
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatTooltipModule,
    MatSidenavModule,
    MatTabsModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatListModule,
    MatCardModule,
    MatGridListModule,
    MatDatepickerModule,
    MatSlideToggleModule,
    MatNativeDateModule,
    HttpClientModule,
    MatSnackBarModule,
    SpinnerComponent,
    MatProgressBarModule,
    ReactiveFormsModule,
    MatDialogModule


  ]
})
export class SharedModule { }
