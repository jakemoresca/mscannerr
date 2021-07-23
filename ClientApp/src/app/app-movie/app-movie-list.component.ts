import { Component, OnInit } from '@angular/core';
import { MovieService } from './movie-service';

@Component({
    selector: 'app-movie-list',
    templateUrl: 'app-movie-list.component.html'
})

export class AppMovieListComponent implements OnInit
{
    movies = this.movieService.getMovies();
    baseUrl = "http://server937.seedhost.eu:11151";
    constructor(private movieService: MovieService) { }

    ngOnInit(){ }

    getViewType() {
        return this.movieService.getViewType();
    }

    getFilterType() {
        return this.movieService.getFilterType();
    }

    changeFilterType(filterType: string)
    {
        this.movieService.changeFilterType(filterType);
    }

    changeViewType(viewType: string)
    {
        this.movieService.changeViewType(viewType);
    }
}