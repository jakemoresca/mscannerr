import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppMovieListComponent } from './app-movie/app-movie-list.component';
import { AppSettingsComponent } from './app-settings/app-settings.component';

const routes: Routes = [
  { path: '', component: AppMovieListComponent },
  { path: 'movies', component: AppMovieListComponent },
  { path: 'settings', component: AppSettingsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
