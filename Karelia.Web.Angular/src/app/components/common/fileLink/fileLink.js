import template from './fileLink.html'
import { downloadFile } from '../../../services/screens/screenHelpers';
class FileLinkController {
    constructor($translate, httpService, cancelableProgressService) {
        'ngInject';
        this.httpService = httpService;
        this.cancelableProgressService = cancelableProgressService;
        this.$translate = $translate;
    }

    $onInit(){
        this.setFileLink();
    }

    $onChanges() {
        this.setFileLink();
    }

    linkClicked() {
        downloadFile(this.fileLink.Id, 
            this.fileLink.FileName, 
            this.httpService, 
            this.cancelableProgressService, 
            this.$translate.instant("cancelable_progress.downloading"));
    }

    setFileLink() {
        if (this.fileLink) {
            this.link = this.httpService.getFileUrl(this.fileLink.Id);
            this.fileName = this.fileLink.FileName;
        } else {
            this.link = this.fileName = "";

        }
    }

}
export default {
    template,
    controller: FileLinkController,
    bindings: {
        fileLink: "<"
    }
}