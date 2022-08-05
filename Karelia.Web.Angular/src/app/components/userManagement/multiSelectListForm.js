import template from './multiSelectListForm.html'
import './multiSelectListForm.scss'
class MultiSelectListFormController {
  constructor(services, $scope) {
    'ngInject';
    this.services = services;
    this.$scope = $scope;
  }

  cancelClicked() {
    this.services.modalWindowService.hide(this.$scope.$parent.$id)
  }

  assignClicked() {
    this.services.modalWindowService.confirm(this.$scope.$parent.$id, this.items);
  }
}

export default {
  template,
  bindings: {
    items: "=",
  },
  controller: MultiSelectListFormController
}