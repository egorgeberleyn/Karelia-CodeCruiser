import config from './../config/config';
import kendoLocalizationService from './../kendo/kendoLocalizationService';

export default class LanguageService {
    constructor(httpService, $translate, $rootScope, translateProviderStorageService) {
        "ngInject";

        this.languages = [];
        this.translate = $translate;
        this.httpService = httpService;
        this.$rootScope = $rootScope;
        this.translateProviderStorageService = translateProviderStorageService;
        $rootScope.$on('$translateChangeSuccess', (event, current, previous) => {
            if (current) {
                translateProviderStorageService.put(current.language);
            }
        });
    }

    getAvaliableLanguages() {
        return this.languages;
    }

    setCurrentLanguage(locale) {
        kendoLocalizationService.setLocale(locale).then(() => {
            this.translate.use(locale);
        });
    }

    init() {
        let locale = null;
        const lastSavedLocale = this.translateProviderStorageService.get();
        if (lastSavedLocale && lastSavedLocale !== "undefined") {
            locale = lastSavedLocale;
        } else {
            locale = config.defaultCulture;
        }
        this.$rootScope.$emit('SET_DEFAULT_LOCALE', locale);
        this.setCurrentLanguage(locale);
        return this.httpService.get('Language').then(result => {
            if (result && result !== undefined) {
                this.languages = result.data;
            }
            return this.translate('init');
        });
    }
}
