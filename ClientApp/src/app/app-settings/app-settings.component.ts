import { Component, OnInit } from '@angular/core';
import { SettingService } from './setting-service';
import { ISettings } from './settings';

@Component({
    selector: 'app-settings',
    templateUrl: 'app-settings.component.html'
})

export class AppSettingsComponent implements OnInit {
    settings: ISettings | undefined;
    saveSuccess: boolean = false;
    testSuccess?: boolean = undefined;
    constructor(private settingService: SettingService) { }

    ngOnInit() 
    { 
        this.settingService.getSettings().toPromise()
            .then(result => 
            {
                this.settings = result;
            });
    }

    saveSettings()
    {
        if (this.settings)
        {
            this.settingService.saveSettings(this.settings).toPromise()
                .then(result => this.saveSuccess = result.ok);
        }
    }

    testSettings()
    {
        if (this.settings)
        {
            this.settingService.testSettings(this.settings).toPromise()
                .then(result => this.testSuccess = result.ok);
        }
    }
}