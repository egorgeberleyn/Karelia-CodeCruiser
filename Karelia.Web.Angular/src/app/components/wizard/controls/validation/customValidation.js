import template from "./custom-validation.html"
class CustomValidationController{
    constructor($compile, $element, $scope){
        "ngInject";
        Object.assign(this, {$compile, $element, $scope});
    }


    createValidator (validator) {
        const validationMethod = (modelValue) => {
            return validator.method.call(validator.context, modelValue, this.model());
        };
        if (validator.async) {
            this.modelCtrl.$asyncValidators[validator.name] = validationMethod;
        } else {
            this.modelCtrl.$validators[validator.name] = validationMethod;
        }
    }

    $onInit(){
        this.field = this.$scope.$parent.$ctrl.field;
        this.model = () => { return this.$scope.$parent.$ctrl.model };
        if (this.field && this.field.validators && this.field.validators.length > 0) {
            const element = this.$compile(template)(this.$scope);
            element.insertAfter(this.$element);
            this.field.validators.forEach(v => this.createValidator(v));
        }
    }
}
export default () => {
    return {
        restrict: "A",
        require: {
            modelCtrl: 'ngModel'
        },
        scope: true,
        bindToController: true,
        controllerAs: "$ctrl",
        controller: CustomValidationController
    };
}
