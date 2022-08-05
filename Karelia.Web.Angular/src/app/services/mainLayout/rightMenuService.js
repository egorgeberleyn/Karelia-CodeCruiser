import settingsService from './../common/settingsService';
export default class RightMenuService {

    constructor($translate, downloadClientService, languageService, kendoThemeService, messageBoxService, checkServerVersionService, $rootScope, $state) {
        "ngInject";
        Object.assign(this, {
            $translate,
            downloadClientService,
            languageService,
            kendoThemeService,
            checkServerVersionService,
            messageBoxService,
            settingsService,
            $rootScope,
            $state
        });
    }

    getRightMenuActions(mainToolbarActions) {
        /*Populate right menu*/
        const rightMenu = {
            name: this.$rootScope.currentUser,
            items: [
                {
                    name: this.$translate.instant('right_menu_languages'),
                    items: this.languageService.getAvaliableLanguages().map(lang => {
                        return {
                            name: lang.nativeDescription,
                            invoke: () => {
                                this.languageService.setCurrentLanguage(lang.locale);
                            }
                        }
                    })
                },
                {
                    name: this.$translate.instant('right_menu_themes'),
                    items: this.kendoThemeService.getSkins().map(skin => {
                        return {
                            name: skin.name,
                            invoke: () => {
                                this.kendoThemeService.changeSkin(skin);
                            }
                        }
                    })
                }
            ]
        };

        for (let i = 0; i < mainToolbarActions.length; i++) {
            const action = mainToolbarActions[i];
            const item = {name: action.name, css: 'right-toolbar-mobile-screen-action'};
            if (action.items.length > 0) {
                item.items = action.items.map(actionItem => {
                    return {
                        name: actionItem.name,
                        invoke: () => {
                            actionItem.invoke();
                        }
                    };
                });
                rightMenu.items.push(item);
            }
        }
        if (this.downloadClientService.showDownloadClientLink) {
            rightMenu.items.push({
                name: this.$translate.instant('download_client_button'),
                invoke: () => {
                    this.downloadClientService.downloadClient();
                }
            });
        }
        rightMenu.items.push({
            name: this.$translate.instant('right_menu_about'),
            invoke: () => {
                const version = this.checkServerVersionService.serverVersion;
                this.messageBoxService.show(
                    this.$translate.instant('form_about_caption'),
                    this.$translate.instant('form_about_message') + version,
                    this.$translate.instant('form_about_button_text'));
            }
        });
        rightMenu.items.push({
            name: this.$translate.instant('right_menu_logout'),
            invoke: () => {
                this.$rootScope.currentUser = undefined;
                settingsService.clearCurrentUserInfo();
                this.$state.go('login');
            }
        });
        return rightMenu;
    }
}
