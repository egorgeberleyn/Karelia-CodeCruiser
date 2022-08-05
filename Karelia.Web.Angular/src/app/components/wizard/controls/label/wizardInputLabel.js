class WizardInputLabelController{
    constructor($compile, $element, $scope){
        "ngInject"
        Object.assign(this, {$compile, $element, $scope});
    }

    $onInit(){
        let template = `<span class="input-label">${this.title} `;
        if (this.fieldRequired) {
            template += '<span class="required-validation-marker">*</span>';
        }
        template += '</span>';
        const element = this.$compile(template)(this.$scope);
        element.insertAfter(this.$element);
    }
}
export default {
    bindings: {
        title: "=",
        fieldRequired: "="
    },
    controller: WizardInputLabelController
}

