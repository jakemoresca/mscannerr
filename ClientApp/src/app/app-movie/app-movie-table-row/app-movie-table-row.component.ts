import { Component, EventEmitter, HostBinding, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { IMovie, IScannedMovie } from '../movie';

@Component({
    selector: 'app-movie-table-row',
    templateUrl: 'app-movie-table-row.component.html'
})

export class AppMovieTableRowComponent implements OnInit, OnChanges {
    @Input() movie!: IMovie;
    @Input() matchedMovies!: IScannedMovie[];
    @Input() countryFilter!: string[];
    @Input() filterType!: string

    @Output() scanMovie = new EventEmitter<IMovie>();

    matchedMovie!: IScannedMovie | undefined;
    isHidden: boolean | undefined = false;

    @HostBinding('attr.class') cssClass: string = "";
    constructor() { }

    ngOnInit() { }

    ngOnChanges(changes: SimpleChanges)
    {

        if (changes.hasOwnProperty("matchedMovies"))
        {
            const matchedMovies = changes["matchedMovies"].currentValue as IScannedMovie[];

            if (!matchedMovies)
                return;

            this.matchedMovie = matchedMovies.find(x => x.title == this.movie?.title);
        }

        const filterType = changes.hasOwnProperty("filterType") ? changes["filterType"].currentValue as string : this.filterType;
        const countryFilter = changes.hasOwnProperty("countryFilter") ? changes["countryFilter"].currentValue as string : this.countryFilter;

        if (changes.hasOwnProperty("filterType") || changes.hasOwnProperty("countryFilter"))
        {
            const intersection = this.matchedMovie?.countries?.filter(country => countryFilter.includes(country)) || [];

            this.isHidden = filterType == 'Existing' && (intersection.length > 0 || this.matchedMovie == null || this.matchedMovie.exist == false);

            this.cssClass = this.isHidden ? "d-none" : "";
        }
    }
}