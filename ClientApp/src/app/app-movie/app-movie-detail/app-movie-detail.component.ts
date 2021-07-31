import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SettingService } from 'src/app/app-settings/setting-service';
import { IMovie, IScannedMovie } from '../movie';
import { movieAdditionalDetails } from '../movie-helper';
import { MovieService } from '../movie-service';

@Component({
    selector: 'app-movie-detail',
    templateUrl: 'app-movie-detail.component.html'
})

export class AppMovieDetailComponent implements OnInit
{
    movie!: IMovie;
    scannedMovie!: IScannedMovie;
    baseUrl!: string;

    isHidden!: boolean | undefined;
    notExist!: boolean | undefined;
    foundOnOtherCountry!: boolean | undefined;
    existStatus!: string;

    constructor(private route: ActivatedRoute,
        private movieService: MovieService,
        private settingService: SettingService) { }

    async ngOnInit()
    {
        const routeParams = this.route.snapshot.paramMap;
        const movieIdFromRoute = Number(routeParams.get('movieId'));

        this.movie = await this.movieService.getMovie(movieIdFromRoute);
        this.scannedMovie = await this.movieService.getMatchedMovie(this.movie.title);

        const settings = await this.settingService.getSettings().toPromise()
        const protocol = settings.useSsl ? "https://" : "http://";

        this.baseUrl = `${protocol}${settings.host}:${settings.port}`;
        
        const countryFilter = settings.countryFilter.split(",");
        const { notExist, foundOnOtherCountry, existStatus } = movieAdditionalDetails(this.scannedMovie, countryFilter, "");

        this.notExist = notExist;
        this.foundOnOtherCountry = foundOnOtherCountry;
        this.existStatus = existStatus;
    }
}