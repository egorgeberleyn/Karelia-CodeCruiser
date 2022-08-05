import settingsService from './../common/settingsService';

export default class TranslateProviderStorageService {
    constructor(){
        "ngInject";
        this.SETTING_NAME = "TRANSLATE_KEY"
    }

    put(value) {
        settingsService.saveSetting(this.SETTING_NAME, value);
    }

    get () {
        return settingsService.getSetting(this.SETTING_NAME);
    }
}
