import connectionSettings from './../config/connectionSettings';
import settingsService from './../common/settingsService';

export default class KendoDataSourceService {
    constructor(connectionErrorHandler, $state) {
        "ngInject";
        Object.assign(this, {connectionErrorHandler, $state});
    }

    getBaseDataSourcePath(relativePath) {
        return `${connectionSettings.baseApiOdataPath}${relativePath}`;
    }

    getBaseDataSource(path, queryFilterExtractor) {
        return {
            type: "odata-v4",
            serverFiltering: true,
            transport: {
                read: {
                    url: this.getBaseDataSourcePath(path),
                    contentType: 'application/json; charset=utf-8',
                    beforeSend: (e, req) => {
                        const queryFilter = queryFilterExtractor && queryFilterExtractor();
                        if (queryFilter) {
                            const url = decodeURIComponent(req.url);
                            let newUrl;
                            const filterIndex = url.indexOf('$filter');
                            if (filterIndex !== -1) {
                                const endFilterIndex = url.indexOf('&', filterIndex);
                                if (endFilterIndex === -1){
                                    newUrl = `${url.substr(0, filterIndex + 8)}(${url.substr(filterIndex+8)})+and+${queryFilter}`;
                                } else {
                                    newUrl = `${url.substr(0, filterIndex + 8)}(${url.substr(filterIndex+8, endFilterIndex-filterIndex-8)})+and+${queryFilter}${url.substr(endFilterIndex)}`;
                                }
                            } else {
                                newUrl = `${url}&$filter=${queryFilter}`;
                            }
                            req.url = encodeURI(newUrl);
                        }
                        var token = settingsService.getUserInformation().token;
                        e.setRequestHeader('Authorization', 'Bearer ' + token);
                    },
                    cache: false
                }
            },
            error: (e) => {
                if (e.xhr && e.xhr.status == 0) {
                    e.preventDefault();
                    this.connectionErrorHandler.showLostConnectionDialog()
                        .then(() => {
                            e.sender.fetch();
                        }).catch(() => {
                        this.$state.go('welcome');
                    });
                }
            }
        }
    }
}

