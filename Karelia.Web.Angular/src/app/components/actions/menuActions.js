class MenuActionsController {
    constructor($scope, $compile, $element) {
        "ngInject";
        this.scope = $scope;
        this.compile = $compile;
        this.element = $element;
    }

    $onInit() {
        this.menu = angular.element('<ul></ul>');
        this.allActions = [];

        var mainAction = angular.element(`<li>${this.root.name}</li>`);
        mainAction.appendTo(this.menu);
        var subMenu = angular.element('<ul class="action-group-menu-list"></ul>');
        subMenu.appendTo(mainAction);

        this.createActions(this.root.items, subMenu);

        this.menu.attr('kendo-menu', '');
        this.compile(this.menu[0].outerHTML)(this.scope).appendTo(this.element);
    }

    createActions(actions, parent) {
        for (var i = 0; i < actions.length; i++) {
            var action = actions[i];
            if (action.items && action.items.length > 0) {
                var menuWrapper = angular.element(`<li>${action.name}</li>`);
                var subMenu = angular.element('<ul></ul>');
                if (action.css) {
                    menuWrapper.attr('class', action.css);
                }
                subMenu.appendTo(menuWrapper);
                menuWrapper.appendTo(parent);
                this.createActions(action.items, subMenu);
            } else {
                var actionMenuItem = angular.element(`<li ng-click="$ctrl.actionClicked(${this.allActions.length})">${action.name}</li>`);
                if (action.css) {
                    actionMenuItem.attr('class', action.css);
                }
                actionMenuItem.appendTo(parent);
                this.allActions.push(action);
            }
        }
    }

    actionClicked(i) {
        this.allActions[i].invoke();
    }
}

export default {
    bindings: {
        root: '='
    },
    controller: MenuActionsController
}

