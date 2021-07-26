export interface IMovie
{
    id: number;
    tmdbId: number;
    imdbId: number;
    title: string;
        //public string CleanTitle { get; set; }
        //public string SortTitle { get; set; }
    status: string;
    overview: string;
    monitored: boolean;
        //public string MinimumAvailability { get; set; }
        //public int ProfileId { get; set; }
    lastInfoSync?: string;
        //public int Runtime { get; set; }
    images: IMovieImage[];
    year: number;
    genres: string[];
}

export interface IMovieImage
{
    coverType: string;
    url: string;
}

export interface IScannedMovie
{
    title: string;
    countries: string[];
    exist: boolean;
}