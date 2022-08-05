import template from "./confirmationDialog.html"

class ConfirmationDialogController {
    constructor(modalWindowService, $scope) {
        "ngInject";
        Object.assign(this, {modalWindowService, $scope});
        this.detailsCollapsed = true;
    }
    okClicked () {
        this.modalWindowService.confirm(this.$scope.$parent.$id);
    }
    cancelClicked() {
        this.modalWindowService.hide(this.$scope.$parent.$id);
    }
}

export default {
    template: template,
    bindings: {
        message: "@",
        details: "@",
        cancelText: "@",
        okText: "@"
    },
    controller: ConfirmationDialogController
}


