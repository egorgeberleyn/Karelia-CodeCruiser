import 'file-saver';
import { ActionStatus } from '../actions/actionEnums';
export default class ReportManagementService{
    constructor(httpService, modalWindowService, wizardInvokeService) {
        'ngInject';
        this.httpService = httpService;
        this.modalWindowService = modalWindowService;
        this.wizardInvokeService = wizardInvokeService;
    }

    printReport(reportName, parameters) {
        return this.httpService.getReport(`PrintReport/${reportName}`, parameters)
            .then(report => { 
                return this.showReport(report.data, report.fileName)
            });
    }

    showReport(report, reportName = '') {
        if (reportName && reportName.endsWith('.pdf')) {
            return this.modalWindowService.show({
                template: '<report-viewer data="data"></report-viewer>',
                locals: {
                    data: new Uint8Array(report)
                },
                title: reportName,
                width: "600px",
                height: "600px"
            }); 
        } else {
            const result = {
                data: {
                    Type: ActionStatus.SUCCESS
                }
            }
            try {
                saveAs(new Blob([report]), reportName);
            }
            catch(e) {
                result.data.Type = ActionStatus.FAIL;
                result.data.Message = e;
            }
            return result;
        }
    }

    printReportWithParameters(reportName, parameters, title) {
        return this.openReportForm(parameters, title).then(result => {
            if (result.complete) {
                return this.printReport(reportName, result.model);
            }
            else {
                return false;
            }
        });
    }

    openReportForm(parameters, title) {
        const wizardSettings = {
            items: [{
                type: 1,
                editors: [],
                title: title,
                name: "parametersPage"
            }]
        };
        parameters.forEach(p => {
            wizardSettings.items[0].editors.push({
                field: {
                    name: p.name,
                    dataType: p.dataType
                },
                type: p.editorType,
                title: p.title
            });
        });
        return this.wizardInvokeService.openReportForm(wizardSettings);
    }
}
