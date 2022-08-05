export default class RegistrationService {
    constructor(httpService) {
        'ngInject';
        this.httpService = httpService;
    }

    registerUser(model) {
        return this.httpService.postModel('register', model);
    }
}
