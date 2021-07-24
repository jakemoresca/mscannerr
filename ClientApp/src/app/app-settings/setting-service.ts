import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISettings } from './settings';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class SettingService
{
    constructor(private httpClient: HttpClient) { }

    getSettings()
    {
        let settings: ISettings = {
            "baseUrl": "",
            "apiKey": "",
            "host": "",
            "port": 80,
            "useSsl": false
        };

        this.httpClient.get<ISettings>("/api/Setting").toPromise()
            .then(result => 
                {
                    return result;
                });

        return settings;
    }

    saveSettings(settings: ISettings)
    {
        let lastResult = false;

        const subscription = this.httpClient.post<{ ok: boolean }>("/api/Setting", settings).toPromise()
            .then(result => lastResult = result.ok);

        return lastResult;
    }
}