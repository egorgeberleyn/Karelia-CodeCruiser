import template from './reportViewer.html'

class ReportViewerController {
    constructor() {
        'ngInject';
        this.data = null;
    }
}

export default {
    template: template,
    bindings: {
        data: "="
    },
    controller: ReportViewerController
}





