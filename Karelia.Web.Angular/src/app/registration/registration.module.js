import angular from "angular";
import register from './components/register/register';
import confirm from './components/confirm/confirm';
import resetPassword from './components/resetPassword/resetPassword';
import inputEmail from './components/inputEmail/inputEmail';
import registrationService from './services/registrationService';
import resetPasswordService from './services/resetPasswordService';

const module = angular.module('app.registration', []);
module.component('register', register);
module.component('confirm', confirm);
module.component('resetPassword', resetPassword);
module.component('inputEmail', inputEmail);
module.service('registrationService', registrationService);
module.service('resetPasswordService', resetPasswordService);




