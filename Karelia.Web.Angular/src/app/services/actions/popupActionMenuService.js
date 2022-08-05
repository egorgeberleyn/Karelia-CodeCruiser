export default class PopupActionMenuService{
    constructor($rootScope, $compile, $document, $timeout){
        "ngInject";
        Object.assign(this, {$rootScope, $compile, $document, $timeout});
    }

    createMenu (items) {
        var menu = {
            isShowing: false
        };
        var scope = this.$rootScope.$new();
        var popup = angular.element("<div style='position: absolute; display: none' class='k-list-container k-popup k-group k-reset'></div>");
        var menuElement = angular.element('<ul class="k-list k-reset"></ul>');
        menuElement.appendTo(popup);
        for (var i = 0; i < items.length; i++) {
            var action = items[i];
            var menuItem = angular.element(`<li 
                ng-mouseenter="action${i}Hovered = action${i}Hovered + 1"
                ng-mouseleave="action${i}Hovered = action${i}Hovered - 1"
                class="k-link context-action k-item popup-menu-item ${action.className}" 
                ng-class="{'k-state-focused': action${i}Hovered > 0 }">
                <a ng-class="{'k-state-disabled': !actionCanExecute(${i})}" ng-click="actionInvoke(${i})">
                ${action.icon ? '<img src="' + action.icon + '" />' : ''}
                <span>${action.name}</span></a></li>`);
            menuItem.appendTo(menuElement);
        }
        scope.actionInvoke = (i) => {
            if (items[i].canInvoke) {
                items[i].invoke();
            }
        };
        scope.actionCanExecute = (i) => {
            return items[i].canInvoke;
        }
        var element = this.$compile(popup[0].outerHTML)(scope);
        var body = this.$document.find('body').eq(0);
        element.appendTo(body);
        var closeMenuHandler = () => {
            element.hide();
            menu.isShowing = false;
        }

        menu.element = element;
        menu.show = (event) => {
            let x = event.originalEvent.clientX;
            let y = event.originalEvent.clientY;
            if (menu.isShowing){
                menu.isShowing = false;
                element.hide();
                this.$document.off("click", closeMenuHandler);
            }
            if (y + element.outerHeight(true) > body.outerHeight(true)) {
                y = body.outerHeight(true) - element.outerHeight(true);
            }
            if (x + element.outerWidth(true) > body.outerWidth(true)) {
                x = body.outerWidth(true) - element.outerWidth(true);
            }
            element.css("top", y).css("left", x);

            if (!menu.isShowing) {
                element.show();
                menu.isShowing = true;
                //Timeout here b/c event which is show menu will close it =)
                this.$timeout(() => {
                    this.$document.one("click", closeMenuHandler);
                });
            }
        };

        menu.destroy = () => {
            element.remove();
            scope.$destroy();
        };

        return menu;
    }
}

