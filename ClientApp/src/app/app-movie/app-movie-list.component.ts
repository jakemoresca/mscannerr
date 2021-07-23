import { Component, OnInit } from '@angular/core';
import { IMovie } from './movie';

@Component({
    selector: 'app-movie-list',
    templateUrl: 'app-movie-list.component.html'
})

export class AppMovieListComponent implements OnInit {
    movies: IMovie[] = [];
    constructor() { }

    ngOnInit() { 
        this.movies = [{
            title: "Kill Bill", description: "The Bride wakens from a four-year coma.", year: 2003, status: "Unmonitored"
        }]
    }
}