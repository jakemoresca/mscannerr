import { Component, OnInit } from '@angular/core';
import { MovieService } from './movie-service';

@Component({
    selector: 'app-movie-list',
    templateUrl: 'app-movie-list.component.html'
})

export class AppMovieListComponent implements OnInit
{
    movies = this.movieService.getMovies();
    constructor(private movieService: MovieService) { }

    ngOnInit(){ }
}