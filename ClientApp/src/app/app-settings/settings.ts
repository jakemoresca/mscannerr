export interface ISettings
{
    movieSettings: IMovieSettings;
    seriesSettings: ISeriesSettings;
}

export interface IMovieSettings
{
    baseUrl: string;
    apiKey: string;
    host: string;
    port: number
    useSsl: boolean

    countryFilter: string;
}

export interface ISeriesSettings
{
    baseUrl: string;
    apiKey: string;
    host: string;
    port: number;
    useSsl: boolean;
    countryFilter: string;
}