import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IMovie } from '../movie';

@Component({
    selector: 'app-movie-table-row',
    templateUrl: 'app-movie-table-row.component.html'
})

export class AppMovieTableRowComponent implements OnInit {
    @Input() movies!: Observable<IMovie[]>;
    constructor() { }

    ngOnInit() { }
}