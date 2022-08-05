import template from './cancelableProgress.html';

class CancellableProgressController {
    constructor(services) {
        "ngInject"
        this.modalWindowService = services.modalWindowService;
    }

    $onInit() {
        this.progress.setProgress = (value) => {
            if (value === -1) {
                this.showSpinner = true;
            } else {
                this.showProgress = true;
                this.progressValue = value;
            }
        }
        this.progress.setCaption = (caption) => {
            this.message = caption;
        }
    }

    cancelClicked() {
        this.progress.cancel();
    }
}

export default {
    template,
    controller: CancellableProgressController,
    bindings: {
        cancelText: "@",
        progress: "="
    }
}