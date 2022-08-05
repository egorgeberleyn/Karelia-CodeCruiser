import numeral from 'numeral';
import connectionSettings from './../config/connectionSettings';
import config from './../config/config';

export default class ConfigInitializationService {
    constructor($http){
        'ngInject';
        this.$http = $http;
    }

    load(){
        return this.$http.get('config.json').then(result => {
            connectionSettings.baseUrl = result.data.baseUrl;
            connectionSettings.baseApiOdataPath = result.data.baseUrl + 'api/odata/';
            connectionSettings.baseApiPath = result.data.baseUrl + 'api/';
            config.appName = result.data.appName;
            config.appTitle = result.data.appTitle;
            config.clientLink = result.data.clientLink;
            config.clientName = result.data.clientName;
            config.allowRegistration = result.data.allowRegistration === "True";
            config.allowPasswordRestore = result.data.allowPasswordRestore === "True";
            config.useCDN = result.data.useCDN === "True";
            config.defaultSkinName = result.data.defaultSkinName;

            config.defaultCulture = result.data.locale.defaultCulture;
            config.defaultDecimalDelimeter = result.data.locale.defaultDecimalSeparator;
            
            const locales = Object.keys(numeral.locales);
            locales.forEach(locale => {
                numeral.locales[locale].delimiters.decimal = result.data.locale.defaultDecimalSeparator;
            });
            
            return {};
        });
    }
}


