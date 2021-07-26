import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IMovie, IScannedMovie } from './movie';

@Injectable({providedIn: 'root'})
export class MovieService {
    viewType: string = "Poster"
    filterType: string = "All"
    constructor(private httpClient: HttpClient) { }
    
    getMovies() {
        return this.httpClient.get<IMovie[]>("/api/Movie");
    }

    getMatchedMovies() {
        return this.httpClient.get<IScannedMovie[]>("/api/Movie/MatchedMovies");
    }

    matchMovie(movie: IMovie) {
        return this.httpClient.post<IScannedMovie>("/api/Movie/Match", movie);
    }

    matchMovies() {
        return this.httpClient.post<IScannedMovie[]>("/api/Movie/MatchAll", {});
    }

    getViewType() {
        return this.viewType;
    }

    getFilterType() {
        return this.filterType;
    }

    changeViewType(viewType: string) {
        this.viewType = viewType;
    }

    changeFilterType(filterType: string)
    {
        this.filterType = filterType;
    }
}