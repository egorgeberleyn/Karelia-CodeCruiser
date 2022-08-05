import spinnerTemplate from './spinner.html'
import './spinner.scss'
import progressService from './../../../services/common/progressService'

class SpinnerController{
    constructor(){
        'ngInject';
        progressService.addListener((visible) => {
            this.showSpinner = visible;
        });
        this.showSpinner = false;
    }
}

export default {
  template: spinnerTemplate,
    controller: SpinnerController
}

