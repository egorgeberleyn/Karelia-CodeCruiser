import mainLayoutTemplate from "./main-layout.html";
import config from '../../services/config/config';
import settingsService from './../../services/common/settingsService';
import screenSizeService from "../../services/helpers/screenSizeService";
import mainMenuService from "../../services/mainLayout/mainMenuService";

 
class MainLayoutComponentController {
    constructor($rootScope, $state, $timeout, mainToolbarService, rightMenuService,
                messageBoxService, checkServerVersionService, $translate, runtimeStates) {
                    'ngInject';
        Object.assign(this, {
            rightMenuService,
            $rootScope,
            $state,
            $timeout,
            mainToolbarService,
            messageBoxService,
            checkServerVersionService,
            $translate,
            runtimeStates
        });
        this.appTitle = config.appTitle;
    }

    $onInit(){
        this.caption = "";
        this.mainToolbarActions = this.mainToolbarService.currentActions;

        this.mainToolbarService.addChangeListener(() => {
            this.caption = this.mainToolbarService.caption;
            this.mainToolbarActions = this.mainToolbarService.currentActions;
        });

        /*Populate right menu*/
        this.rightMenu = this.rightMenuService.getRightMenuActions(this.mainToolbarActions);

        this.isMenuOpened = settingsService.loadMenuState();

        const self = this;
        this.mainMenuPanelOptions = {
            dataSource: mainMenuService.getMainMenu(this.runtimeStates, this.$state),
            select: function (e) {
                var item = angular.element(e.item),
                    panelElement = item.closest(".k-panelbar"),
                    dataItem = this.options.dataSource,
                    index = item.parentsUntil(panelElement, ".k-item").map(function () {
                        return angular.element(this).index();
                    }).get().reverse();

                index.push(item.index());

                for (var i = -1, len = index.length; ++i < len;) {
                    dataItem = dataItem[index[i]];
                    dataItem = i < len - 1 ? dataItem.items : dataItem;
                }

                if (!screenSizeService.isBig() && !dataItem.items) {
                    self.isMenuOpened = false;
                }

                if (dataItem.state) {
                    self.$state.go(dataItem.state);
                }
            }
        };

        this.$timeout(() => {
            this.updateMenus = true;
            //If we have selected state we should to show it in the menu bar.
            if (this.$state.current.name !== 'app') {
                var itemToSelect = null;
                var groupForSelect = null;
                var panelBar = angular.element("#mainMenuPanelBar").data("kendoPanelBar");
                for (var i = 0; i < panelBar.options.dataSource.length; i++) {
                    if (itemToSelect !== null)
                        break;
                    var group = panelBar.options.dataSource[i];
                    for (var j = 0; j < group.items.length; j++) {
                        if (this.$state.current.name === group.items[j].state) {
                            itemToSelect = j;
                            groupForSelect = i;
                            break;
                        }
                    }
                }
                var items = panelBar.element.children('li');
                panelBar.expand(items[groupForSelect]);
                var subItems = angular.element(items[groupForSelect]).children('ul').children('li');
                panelBar.select(subItems[itemToSelect]);
            }
        });

        this.mainMenuClassChangesCallback = (screenName,  className) => {
            const classesToAdd = className.split(' ');
            const item = angular.element(`.name-${screenName}`);
            if (item && item.length > 0) {
                const classList = item[0].classList;
                for (let i = 0; i < classList.length; i++) {
                    const classListItem = classList[i];
                    if (!classListItem.startsWith('ng-') && !classListItem.startsWith('k-') && !classListItem.startsWith('name-')) {
                        classList.remove(classListItem);
                        i--;
                    }
                }
                classesToAdd.forEach(classToAdd => {
                    if (classToAdd && classToAdd !== '')
                        classList.add(classToAdd);
                });
            }
        }
        mainMenuService.registerCallback(this.mainMenuClassChangesCallback);
    }

    menuClicked () {
        this.isMenuOpened = !this.isMenuOpened;
        if (screenSizeService.isBig()) {
            settingsService.saveMenuState(this.isMenuOpened);
        }
        this.$timeout(() => { 
            screenSizeService.raiseResizeEvent();
        });
    }

    $onDestroy() {
        if (this.screenSizeCleaner)
            this.screenSizeCleaner();
        if(this.mainMenuClassChangesCallback)
            mainMenuService.unregisterCallback(this.mainMenuClassChangesCallback);
    }
}

export default {
    template: mainLayoutTemplate,
    controller: MainLayoutComponentController
}
