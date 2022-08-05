import { createGlobalActionsByDeclaration } from "../actions/actionConstructor";
import { buildContextState } from "../screens/screenHelpers";
import { getBlocks } from "../screens/htmlTemplateBuilder";
import { screenResolved } from '../../domain/customScreenResolved';

export default class RuntimeStatesProvider {
    constructor($stateProvider) {
        "ngInject"
        this.addedStates = {};
        this.urls = [];
        this.groups = [];
        this.globalActions = [];
        this.firstState = null;
        this.addState = (name, state) => {
            if (!this.addedStates[name]) {
                $stateProvider.state(name, state);
                this.addedStates[name] = true;
                this.urls[state.url] = name;
            }
        };
    }

    $get(services) {
        "ngInject";
        return {
            fillStates: () => {
                return services.httpService.refreshToken().then(() => {
                    return services.httpService.get('MainMenuSettings').then(result => {
                        let first = true;
                        if (result && result.data && result.data.groups && result.data.groups.length > 0) {
                            result.data.groups.forEach(group => {
                                if (group.screens && group.screens.length > 0) {
                                    group.screens.forEach(screen => {
                                        const stateName = 'app.' + screen.name;
                                        const state = {
                                            url: getStateUrl(screen),
                                            views: {
                                                'menuContent': {
                                                    templateUrl: `templates/screens/${screen.name}.html`,
                                                    controller: ($scope, $rootScope, $stateParams, screenSettings, $injector) => {
                                                        "ngInject";
                                                        $scope.contextState = buildContextState(screenSettings, $rootScope);
                                                        $scope.contextState.screenService = $injector.get(screenSettings.name + 'Service');
                                                        $scope.blocks = getBlocks(screenSettings);
                                                        if (screen.parameters) {
                                                            Object.assign($scope.contextState.parameters, $stateParams);
                                                        }
                                                        screenResolved(services, $scope.contextState, $scope.blocks);
                                                    }
                                                }
                                            },
                                            data: {
                                                requireLogin: true
                                            },
                                            resolve: {
                                                screenSettings: () => {
                                                    return services.httpService.get(screen.controller).then(result => {
                                                        return result.data;
                                                    })
                                                }
                                            }
                                        };
                                        this.addState(stateName, state);
                                        if (first) {
                                            this.firstState = stateName;
                                            first = false;
                                        }
                                    });
                                }
                            });
                            this.groups = result.data.groups;
                        }
                        if (result.data && result.data.actions && result.data.actions.length > 0) {
                            globalActions = createGlobalActionsByDeclaration(services, result.data.actions);
                        }
                        return true;
                    })
                });
            },

            getFirstState: () => {
                return this.firstState;
            },

            getStates: () => {
                return this.groups;
            },

            getStateByUrl: (url) => {
                return this.urls[url];
            },

            getGlobalActions: () => {
                return this.globalActions;
            }
        }
    }
}

function getStateUrl(screen) {
    let url = `/${screen.name}`;
    if (screen.parameters) {
        url += '?' + screen.parameters.map(p => p.name).join('&');
    }
    return url;
}


