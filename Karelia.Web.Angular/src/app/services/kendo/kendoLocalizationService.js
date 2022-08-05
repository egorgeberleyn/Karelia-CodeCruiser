import config from './../config/config';

class KendoLocalizationService {
    setLocale(locale) {
        const kendoMessagesBasePath = config.useCDN ?
            "https://kendo.cdn.telerik.com/2017.1.223/js/messages/kendo.messages." :
            "kendo-2017-1-223/js/messages/kendo.messages.";
        const kendoMessagesEnd = ".min.js";
        
        return new Promise(resolve => {
            jQuery.getScript(kendoMessagesBasePath + locale + kendoMessagesEnd, function () {
                kendo.culture(locale);
                /* change kendo culture */
                resolve();
            });
        });
    }
}

export default new KendoLocalizationService();
