export default class AngularServices{
    constructor(messageBoxService, httpService, modalWindowService, $translate){
        'ngInject';
        Object.assign(this, {
            messageBoxService,
            httpService,
            modalWindowService,
            $translate
        });
    }
}