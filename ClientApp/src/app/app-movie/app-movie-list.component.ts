import { Component, OnInit } from '@angular/core';
import { SettingService } from '../app-settings/setting-service';
import { IMovie, IScannedMovie } from './movie';
import { MovieService } from './movie-service';

@Component({
    selector: 'app-movie-list',
    templateUrl: 'app-movie-list.component.html'
})

export class AppMovieListComponent implements OnInit
{
    movies = this.movieService.getMovies();
    matchedMovies: IScannedMovie[] = [];
    baseUrl!: string;
    countryFilter: string[] = [];
    filterType!: string;
    viewType!: string;
    
    constructor(private movieService: MovieService, private settingService: SettingService) { }

    ngOnInit(){ 
        this.settingService.getSettings().toPromise()
            .then(result => 
            {
                const protocol = result.movieSettings.useSsl ? "https://" : "http://"
                this.baseUrl = `${protocol}${result.movieSettings.host}:${result.movieSettings.port}`;

                this.countryFilter = result.movieSettings.countryFilter.split(",");
            });

        this.movieService.getMatchedMovies().toPromise()
            .then(result =>
                {
                    this.matchedMovies = result;
                })

        this.getViewType();
        this.getFilterType();
    }

    getViewType() {
        this.viewType = this.movieService.getViewType();
    }

    getFilterType() {
        this.filterType = this.movieService.getFilterType();
    }

    changeFilterType(filterType: string)
    {
        this.movieService.changeFilterType(filterType);
        this.getFilterType();
    }

    changeViewType(viewType: string)
    {
        this.movieService.changeViewType(viewType);
        this.getViewType();
    }

    scanMovie(movie: IMovie) {
        this.movieService.matchMovie(movie).toPromise()
            .then(result =>
            {
                const matchedMovie = this.matchedMovies.find(matchedMovie => matchedMovie.title == result.title);

                if(matchedMovie)
                {
                    this.matchedMovies = this.matchedMovies.map(x => {
                        if(x.title == result.title)
                            return result;
                        else
                            return x;
                    });
                }
                else
                {
                    this.matchedMovies = this.matchedMovies.concat([result]);
                }
            })
    }

    scanMovies()
    {
        this.movieService.matchMovies().toPromise()
            .then(result =>
            {
                this.matchedMovies = result;
            })
    }
}