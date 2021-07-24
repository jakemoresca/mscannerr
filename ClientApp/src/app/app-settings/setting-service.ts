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
        return this.httpClient.get<ISettings>("/api/Setting");
    }

    saveSettings(settings: ISettings)
    {
        return this.httpClient.post<{ ok: boolean }>("/api/Setting", settings)
    }
}