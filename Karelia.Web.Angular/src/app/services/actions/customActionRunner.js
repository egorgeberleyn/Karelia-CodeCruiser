import progressService from './../common/progressService'

export default class CustomActionRunner {
    constructor(httpService, reportManagementService) {
        "ngInject";
        Object.assign(this, { httpService, reportManagementService });
    }
    run(path, model) {
        return this.runAction(path, model, false);
    }

    runReportAction(path, model) {
        return this.runAction(path, model, true).then(report => 
            this.reportManagementService.showReport(report.data, report.fileName)
        );
    }

    runAction(path, model, isReport) {
        progressService.show();
        const method = isReport ? 'getReport' : 'postModel';
        return this.httpService[method](path, model).then(result => {
            progressService.hide();
            return result;
        });
    }
}
