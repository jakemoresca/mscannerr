import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppMovieDetailComponent } from './app-movie/app-movie-detail/app-movie-detail.component';
import { AppMovieListComponent } from './app-movie/app-movie-list.component';
import { AppMovieSettingsComponent } from './app-settings/app-movie-settings.component';
import { AppSeriesSettingsComponent } from './app-settings/app-series-settings.component';

const routes: Routes = [
  { path: '', component: AppMovieListComponent },
  { path: 'movies', component: AppMovieListComponent },
  { path: 'movies/:movieId', component: AppMovieDetailComponent },
  { path: 'settings/movies', component: AppMovieSettingsComponent },
  { path: 'settings/series', component: AppSeriesSettingsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
