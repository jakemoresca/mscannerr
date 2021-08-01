import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppSidebarMenuComponent } from './app-sidebar-menu/app-sidebar-menu.component';
import { AppNavMenuComponent } from './app-nav-menu/app-nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppMovieListComponent } from './app-movie/app-movie-list.component';
import { AppMovieCardComponent } from './app-movie/app-movie-card/app-movie-card.component';
import { HttpClientModule } from '@angular/common/http';
import { AppMovieTableComponent } from './app-movie/app-movie-table-row/app-movie-table.component';
import { AppMovieSettingsComponent } from './app-settings/app-movie-settings.component';
import { FormsModule } from '@angular/forms';
import { AppMovieTableRowComponent } from './app-movie/app-movie-table-row/app-movie-table-row.component';
import { AppMovieDetailComponent } from './app-movie/app-movie-detail/app-movie-detail.component';
import { AppSeriesSettingsComponent } from './app-settings/app-series-settings.component';

@NgModule({
  declarations: [
    AppComponent,
    AppSidebarMenuComponent,
    AppNavMenuComponent,
    AppMovieListComponent,
    AppMovieCardComponent,
    AppMovieTableRowComponent,
    AppMovieTableComponent,
    AppMovieSettingsComponent,
    AppSeriesSettingsComponent,
    AppMovieDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
