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
    
    constructor(private movieService: MovieService, private settingService: SettingService) { }

    ngOnInit(){ 
        this.settingService.getSettings().toPromise()
            .then(result => 
            {
                const protocol = result.useSsl ? "https://" : "http://"
                this.baseUrl = `${protocol}${result.host}:${result.port}`;
            });
    }

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