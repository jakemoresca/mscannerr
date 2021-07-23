import { Component, Input, OnInit } from '@angular/core';
import { IMovie } from '../movie';

@Component({
    selector: 'app-movie-card',
    templateUrl: 'app-movie-card.component.html'
})

export class AppMovieCardComponent implements OnInit {
    @Input() movie!: IMovie;
    @Input() baseUrl!: string;
    constructor() { }

    ngOnInit() { }
}