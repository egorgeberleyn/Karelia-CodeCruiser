export default class CheckServerVersionService {
    constructor(httpService) {
        "ngInject"
        this.httpService = httpService;
        this.serverVersion = null;
        this.instanceName = null;
    }

    init() {
        return this.httpService.get('check').then((result) => {
            const { Major, Minor, MajorRevision, MinorRevision} = result.data.Version;
            this.serverVersion =`${Major}.${Minor}.${MajorRevision}.${MinorRevision}`;
            this.instanceName = result.data.InstanceName;
            return this.serverVersion;
        });
    }
}


