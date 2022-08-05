import config from './../config/config';
import { v4 as uuid } from 'uuid';

class SettingsService {
    constructor() {
        "ngInject";
        this.USERNAME_SETTING_NAME = "USER_NAME";
        this.TOKEN_SETTING_NAME = "TOKEN";
        this.REFRESH_TOKEN_SETTINGS_NAME = 'REFRESH_TOKEN';
        this.EXPIRES_SETTINGS_NAME = 'EXPIRES';
        this.LAST_STATE_SETTING_NAME = "LAST_STATE";
        this.menuClosedSettingName = 'LEFT_MENU_CLOSED';
        this.CLIENT_ID_SETTING_NAME = "CLIENT_ID";

        this.localStorage = window.localStorage;
    }

    saveSetting(name, value) {
        this.localStorage[config.appName + name] = value;
    }
    getSetting(name) {
        return this.localStorage[config.appName + name];
    }
    removeSetting(name) {
        this.localStorage.removeItem(config.appName + name);
    }
    saveMenuState(state) {
        this.saveSetting(this.menuClosedSettingName, state);
    }
    loadMenuState() {
        const menuState = this.getSetting(this.menuClosedSettingName);
        return menuState === "true" || angular.isUndefined(menuState);
    }
    saveUserInformation(userName, token, refreshToken, expiresIn) {
        this.saveSetting(this.USERNAME_SETTING_NAME, userName);
        this.saveSetting(this.TOKEN_SETTING_NAME, token);
        this.saveSetting(this.REFRESH_TOKEN_SETTINGS_NAME, refreshToken);
        const expires = new Date();
        expires.setSeconds(expires.getSeconds() + expiresIn);
        this.saveSetting(this.EXPIRES_SETTINGS_NAME, expires);
    }
    getUserInformation() {
        return {
            token: this.getSetting(this.TOKEN_SETTING_NAME),
            userName: this.getSetting(this.USERNAME_SETTING_NAME),
            refreshToken: this.getSetting(this.REFRESH_TOKEN_SETTINGS_NAME),
            expires: new Date(this.getSetting(this.EXPIRES_SETTINGS_NAME))
        };
    }
    getClientId() {
        var clientId = this.getSetting(this.CLIENT_ID_SETTING_NAME);
        if (!clientId || clientId === 'undefined') {
            clientId = uuid();
            this.saveSetting(this.CLIENT_ID_SETTING_NAME, clientId);
        }
        return clientId;
    }
    saveLastVisitedState(state) {
        this.saveSetting(this.LAST_STATE_SETTING_NAME, state);
    }
    getLastVisitedState() {
        return this.getSetting(this.LAST_STATE_SETTING_NAME);
    }
    clearCurrentUserInfo() {
        this.removeSetting(this.TOKEN_SETTING_NAME);
        this.removeSetting(this.USERNAME_SETTING_NAME);
        this.removeSetting(this.LAST_STATE_SETTING_NAME);
    }
}

export default new SettingsService();
