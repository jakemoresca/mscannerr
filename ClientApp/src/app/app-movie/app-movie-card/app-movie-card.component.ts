import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { IMovie, IScannedMovie } from '../movie';

@Component({
    selector: 'app-movie-card',
    templateUrl: 'app-movie-card.component.html'
})

export class AppMovieCardComponent implements OnInit, OnChanges {
    @Input() movie!: IMovie;
    @Input() baseUrl!: string;
    @Input() matchedMovies!: IScannedMovie[];
    @Output() scanMovie = new EventEmitter<IMovie>();

    matchedMovie!: IScannedMovie | undefined;

    constructor() { }

    ngOnInit() { }

    ngOnChanges(changes: SimpleChanges) {
        const matchedMovies = changes["matchedMovies"].currentValue as IScannedMovie[];
        const previousMatchedMovies = changes["matchedMovies"].previousValue as IScannedMovie[];

        if (matchedMovies != previousMatchedMovies)
        {
            this.matchedMovie = matchedMovies.find(x => x.title == this.movie?.title);
        }
    }
}