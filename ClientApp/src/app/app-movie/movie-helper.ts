import { IScannedMovie } from "./movie";

export const movieAdditionalDetails = function(matchedMovie?: IScannedMovie, countryFilter?: string[], filterType?: string)
{
    const intersection = matchedMovie?.countries?.filter(country => countryFilter?.includes(country)) || [];

    const notExist = (intersection.length == 0 || matchedMovie == null || matchedMovie.exist == false);
    const foundOnOtherCountry = matchedMovie?.exist && intersection.length == 0;
    const existStatus = !notExist && !foundOnOtherCountry ? "Exist" : foundOnOtherCountry ? "Found on other Country" : "Not Found";

    const isHidden = (filterType == 'Existing' && notExist) ||
        (filterType == "ExistOnOtherCountry" && !foundOnOtherCountry) ||
        (filterType == "NotExisting" && (!notExist || foundOnOtherCountry))

    return { notExist, foundOnOtherCountry, existStatus, isHidden };
}