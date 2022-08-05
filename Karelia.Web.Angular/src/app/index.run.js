import config from './services/config/config';
import settingsService from './services/common/settingsService';

export default function run($log, $window, $rootScope, $state, $translate, configInitializationService,
    $urlRouter, startUpInitService, runtimeStates, loginModalService,
    checkServerVersionService, $document, $location) {
    'ngInject';


    $rootScope.onEvent = function (scope, event, handler) {
        const watcher = $rootScope.$on(event, handler);
        scope.$on('$destroy', function () {
            watcher();
        });
    };

    const stateChangeStartWatcher = $rootScope.$on('$stateChangeStart', function (event, toState, toParams) {
        const requireLogin = toState.data && toState.data.requireLogin;
        if (requireLogin && angular.isUndefined($rootScope.currentUser)) {
            event.preventDefault();

            loginModalService.showLoginForm()
                .then(function (user) {
                    $rootScope.currentUser = user;
                    return $state.go(toState.name, toParams);
                })
                .catch(function () {
                    return $state.go('login');
                });
        }
    });
    const stateChangeSuccessWatcher = $rootScope.$on('$stateChangeSuccess', function (event, toState) {
        if ($rootScope.currentUser) {
            settingsService.saveLastVisitedState(toState.name);
        }
    });

    $rootScope.$on('SET_DEFAULT_LOCALE', (event, locale) => {
        $translate.preferredLanguage(locale);
        $translate.fallbackLanguage(locale);
        $translate.refresh();
    });

    configInitializationService.load().then(() => {
        startUpInitService.init().then(() => {

            document.getElementById('loading').remove();

            var userInfo = settingsService.getUserInformation();
            var instanceName = checkServerVersionService.instanceName;
            var appTitle = '';
            if (instanceName) {
                appTitle += '[' + instanceName + '] ';
            }
            appTitle += config.appTitle;
            var title = $document.find('title').eq(0);
            title.text(appTitle);

            let doLogin = 
            	userInfo.userName &&
            	!location.href.includes('/register') &&
            	!location.href.includes('/confirm?email') &&
            	!location.href.includes('/restore') &&
            	!location.href.includes('/reset?');

            if (doLogin) {
                $rootScope.currentUser = userInfo.userName;
                startUpInitService.afterLoginInit().then(function () {
                    $urlRouter.sync();
                    $urlRouter.listen();
                    var currentLocation = $location.url();
                    if (currentLocation && currentLocation !== "/") {
                        var stateName = currentLocation.substr(1).replace('/', '.');
                        try {
                            $state.go(stateName);
                        } catch (e) {
                            $log.error(e);
                        }
                    } else {
                        var lastState = settingsService.getLastVisitedState();
                        var firstState = runtimeStates.getFirstState();
                        if (lastState) {
                            try {
                                $state.go(lastState);
                            } catch (e) {
                                $state.go('app');
                            }
                        } else if (firstState) {
                            $state.go(firstState);
                        }
                        else {
                            $state.go('app');
                        }
                    }
                });
            } else if (location.href.indexOf('confirm') === -1) {
                $state.go('login');
                $urlRouter.sync();
                $urlRouter.listen();
            } else {
                $urlRouter.sync();
                $urlRouter.listen();
            }
        });
    });

    $rootScope.$on('$destroy', function () {
        stateChangeStartWatcher();
        stateChangeSuccessWatcher();
        setDefaultLanguageWatcher();
    })
}
