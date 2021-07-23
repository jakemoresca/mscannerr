import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IMovie } from './movie';

@Injectable({providedIn: 'root'})
export class MovieService {
    constructor(private httpClient: HttpClient) { }
    
    getMovies() {
        return this.httpClient.get<IMovie[]>("/api/Movie");
    }
}