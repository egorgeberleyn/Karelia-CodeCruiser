import config from './../config/config';

export default class DownloadClientService {
    constructor(httpService){
        'ngInject';
        this.httpService = httpService;
    }
    downloadClient(){
        this.httpService.downloadFileViaLink(config.clientLink, config.clientName || 'WindowsClient');
    }

    get showDownloadClientLink() {
        return !!config.clientLink;
    }
}
