import { Component, EventEmitter, HostBinding, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Observable } from 'rxjs';
import { IMovie, IScannedMovie } from '../movie';

@Component({
    selector: 'app-movie-table',
    templateUrl: 'app-movie-table.component.html'
})

export class AppMovieTableComponent implements OnInit {
    @Input() movies!: Observable<IMovie[]>;
    @Input() matchedMovies!: IScannedMovie[];
    @Input() countryFilter!: string[];
    @Input() filterType!: string

    @Output() scanMovie = new EventEmitter<IMovie>();
    constructor() { }

    ngOnInit() { }
}