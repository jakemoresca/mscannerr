import { Component, OnInit } from '@angular/core';
import { SettingService } from './setting-service';
import { ISettings } from './settings';

@Component({
    selector: 'app-settings',
    templateUrl: 'app-settings.component.html'
})

export class AppSettingsComponent implements OnInit {
    settings: ISettings | undefined;
    constructor(private settingService: SettingService) { }

    ngOnInit() 
    { 
        this.settings = this.settingService.getSettings()
    }

    saveSettings()
    {
        if (this.settings)
        {
            this.settingService.saveSettings(this.settings)
        }
    }
}