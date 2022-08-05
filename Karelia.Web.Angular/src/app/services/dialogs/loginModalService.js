import screenSizeService from "../helpers/screenSizeService";

export default class LoginModalService{
    constructor($translate, modalWindowService){
        "ngInject";
        this.modalWindowService = modalWindowService;
        this.$translate = $translate;
    }

    showForm(template, titleKey) {
        return new Promise(resolve => {
            return this.$translate(titleKey).then(title => {
                resolve(this.modalWindowService.show({
                    template,
                    title,
                    maximize: screenSizeService.getScreenSize().width <= 440,
                    actions: [],
                    width: 440 + 'px',
                    cssClass: 'title-center'
                }));
            });
        });
    }

    showLoginForm  () {
        return this.showForm('<login></login>', 'login_form.caption');
    }

    showRegisterForm() {
        return this.showForm('<register></register>', 'register_form.caption');
    }
    showResetForm() {
        return this.showForm('<reset-password></reset-password>', 'reset_password.caption');
    }
    showInputEmailForm(){
        return this.showForm('<input-email></input-email>', 'reset_password.caption');
    }
}


