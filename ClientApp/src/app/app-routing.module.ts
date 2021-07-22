import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppMovieListComponent } from './app-movie/app-movie-list.component';

const routes: Routes = [{ path: '', component: AppMovieListComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
