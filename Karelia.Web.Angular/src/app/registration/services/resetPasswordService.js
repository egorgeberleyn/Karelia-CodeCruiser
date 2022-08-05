export default class ResetPasswordService {
    constructor(httpService) {
        'ngInject';
        this.httpService = httpService;
    }

    resetPasswrod(password, confirmPassword, token) {
        return this.httpService.postModel('ResetPassword', {
            password,
            confirmPassword,
            token
        });
    }

    sendLink(email) {
        return this.httpService.get(`SendResetPasswordLink?name=${encodeURI(email)}`);
    }
}
