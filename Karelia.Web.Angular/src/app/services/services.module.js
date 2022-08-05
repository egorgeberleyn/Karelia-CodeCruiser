import angular from 'angular'

import translateProviderStorageService from './translation/translateProviderStorageService'
import settingsService from './common/settingsService'
import startUpInitService from './initializationServices/startUpInitService'
import kendoThemeService from './kendo/kendoThemeService'
import languageService from './translation/languageService'
import httpService from './connection/httpService'
import checkServerVersionService from './initializationServices/checkServerVersionService'
import runtimeStatesProvider from './initializationServices/runtimeStateService'

import messageBoxService from './dialogs/messageBoxService'
import modalWindowService from './dialogs/modalWindowService'
import loginModalService from './dialogs/loginModalService'
import cancelableProgressService from './dialogs/cancelableProgressService'

import mainToolbarService from './mainLayout/mainToolbarService'
import connectionErrorHandler from './connection/connectionErrorHandler'
import stringFormat from './helpers/stringFormat'
import oDataService from './connection/oDataService'
import domainManagementService from './actions/domainManagementService'
import wizardManagementService from './wizards/wizardManagementService'
import kendoDataSourceService from './kendo/kendoDataSourceService'
import popupActionMenuService from './actions/popupActionMenuService'
import customActionRunner from './actions/customActionRunner.js'
import reportManagementService from './report/reportManagementService.js'
import wizardInvokeService from './wizards/wizardInvokeService'
import wizardSaveService from './wizards/wizardSaveService'
import configInitializationService from './initializationServices/configInitializationService'
import rightMenuService from './mainLayout/rightMenuService'
import downloadClientService from './common/downloadClientService'
import serverErrorProcessor from './actions/serverErrorProcessor'
import downloadHelpers from './helpers/downloadHelpers'

import angularServices from './angularServices';

const app = angular.module('app.services', []);

app.provider('runtimeStates', runtimeStatesProvider);
app.service('translateProviderStorageService', translateProviderStorageService);
app.service('settingsService', settingsService);
app.service('startUpInitService', startUpInitService);
app.service('kendoThemeService', kendoThemeService);
app.service('languageService', languageService);
app.service('httpService', httpService);
app.service('checkServerVersionService', checkServerVersionService);
app.service('messageBoxService', messageBoxService);
app.service('modalWindowService', modalWindowService);
app.service('loginModalService', loginModalService);
app.service('cancelableProgressService', cancelableProgressService);
app.service('mainToolbarService', mainToolbarService);
app.service('connectionErrorHandler', connectionErrorHandler);
app.service('stringFormat', stringFormat);
app.service('odataService', oDataService);
app.service('domainManagementService', domainManagementService);
app.service('wizardManagementService', wizardManagementService);
app.service('kendoDataSourceService', kendoDataSourceService);
app.service('popupActionMenuService', popupActionMenuService);
app.service('customActionRunner', customActionRunner);
app.service('reportManagementService', reportManagementService);
app.service('wizardInvokeService', wizardInvokeService);
app.service('wizardSaveService', wizardSaveService);
app.service('configInitializationService', configInitializationService);
app.service('rightMenuService', rightMenuService);
app.service('downloadClientService', downloadClientService);
app.service('serverErrorProcessor', serverErrorProcessor);
app.service('downloadHelpers', downloadHelpers);
app.service('services', angularServices);