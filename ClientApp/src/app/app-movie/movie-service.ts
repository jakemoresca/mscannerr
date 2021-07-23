import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IMovie } from './movie';

@Injectable({providedIn: 'root'})
export class MovieService {
    viewType: string = "Poster"
    filterType: string = "All"
    constructor(private httpClient: HttpClient) { }
    
    getMovies() {
        return this.httpClient.get<IMovie[]>("/api/Movie");
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