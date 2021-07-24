import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppSidebarMenuComponent } from './app-sidebar-menu/app-sidebar-menu.component';
import { AppNavMenuComponent } from './app-nav-menu/app-nav-menu.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppMovieListComponent } from './app-movie/app-movie-list.component';
import { AppMovieCardComponent } from './app-movie/app-movie-card/app-movie-card.component';
import { HttpClientModule } from '@angular/common/http';
import { AppMovieTableRowComponent } from './app-movie/app-movie-table-row/app-movie-table-row.component';
import { AppSettingsComponent } from './app-settings/app-settings.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    AppSidebarMenuComponent,
    AppNavMenuComponent,
    AppMovieListComponent,
    AppMovieCardComponent,
    AppMovieTableRowComponent,
    AppSettingsComponent
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
