import settingsService from './services/common/settingsService';

export default function config($locationProvider, $stateProvider, $urlRouterProvider, $httpProvider, $translateProvider, $compileProvider) {
    "ngInject";
    $locationProvider.html5Mode(false);
    $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|local|data|chrome-extension):/);
    $stateProvider
        .state('login', {
            url: "/login?parameters",
            data: {
                login: true
            },
            template: "<welcome></welcome>"
        })
        .state('register', {
            url: "/register?parameters",
            data: {
                register: true
            },
            template: "<welcome></welcome>"
        })
        .state('restore', {
            url: "/restore?parameters",
            data: {
                restore: true
            },
            template: "<welcome></welcome>"
        })   
        .state('reset', {
            url: "/reset?token",
            data: {
                reset: true
            },
            template: "<welcome></welcome>"
        })        
        .state('confirm', {
            url: "/confirm?email&emailToken",
            data: {
                loadSettings: false
            },
            template: "<confirm></confirm>"
        })
        .state('app', {
            url: "/app",
            template: '<main-layout></main-layout>',
            data: {
                requireLogin: true
            }
        });

    $httpProvider.defaults.headers = {};

    $httpProvider.interceptors.push([
        '$injector', function ($injector) {
            return {
                request: function (config) {
                    if (settingsService) {
                        config.headers = config.headers || {};
                        const token = settingsService.getUserInformation().token;
                        if (token) {
                            config.headers.Authorization = 'Bearer ' + token;
                        }
                    }
                    return config;
                },

                responseError: function (rejection) {
                    //Connection lost
                    if (rejection.config && rejection.config.timeout && rejection.config.timeout.$$state.value === "Canceled")
                        return rejection;
                    if (rejection.status === -1) {
                        var connectionErrorHandler = $injector.get('connectionErrorHandler');
                        return connectionErrorHandler.showLostConnectionDialog()
                            .then(function () {
                                const $http = $injector.get('$http');
                                return $http(rejection.config);
                            }).catch(function () {
                                const state = $injector.get('$state');
                                state.go('login');
                                return rejection;
                            });
                    }
                    return rejection;
                }
            };
        }
    ]);

    $httpProvider.interceptors.push([
        '$injector', function ($injector) {
            return {
                request: function (config) {
                    var $translate = $injector.get('$translate');
                    if ($translate) {
                        var currentLocale = $translate.use();
                        config.headers = config.headers || {};
                        config.headers["Accept-Language"] = currentLocale;
                    }
                    return config;
                }
            };
        }
    ]);

    $urlRouterProvider.deferIntercept();

    $translateProvider.useSanitizeValueStrategy('escapeParameters');
    $translateProvider.useStaticFilesLoader({
        files: [{
            prefix: 'assets/strings/common.',
            suffix: '.json'
        }, {
            prefix: 'assets/strings/screenResources.',
            suffix: '.json'
        }]
    });
}

