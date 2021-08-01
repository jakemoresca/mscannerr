import { Component, OnChanges, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SettingService } from 'src/app/app-settings/setting-service';
import { ISettings } from 'src/app/app-settings/settings';
import { IMovie, IScannedMovie } from '../movie';
import { movieAdditionalDetails } from '../movie-helper';
import { MovieService } from '../movie-service';

@Component({
    selector: 'app-movie-detail',
    templateUrl: 'app-movie-detail.component.html'
})

export class AppMovieDetailComponent implements OnInit, OnChanges
{
    movie!: IMovie;
    scannedMovie!: IScannedMovie;
    baseUrl!: string;
    countryFilter!: string[];

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
        const protocol = settings.movieSettings.useSsl ? "https://" : "http://";

        this.baseUrl = `${protocol}${settings.movieSettings.host}:${settings.movieSettings.port}`;
        
        this.countryFilter = settings.movieSettings.countryFilter.split(",");
    }

    ngOnChanges() {
        const { notExist, foundOnOtherCountry, existStatus } = movieAdditionalDetails(this.scannedMovie, this.countryFilter, "");

        this.notExist = notExist;
        this.foundOnOtherCountry = foundOnOtherCountry;
        this.existStatus = existStatus;
    }

    async scanMovie() {
        this.scannedMovie = await this.movieService.matchMovie(this.movie).toPromise();
    }
}