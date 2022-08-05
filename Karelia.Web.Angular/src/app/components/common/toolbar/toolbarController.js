import { visibilityChecker } from "../../../services/screens/visibilityChecker";
import screenSizeService from "../../../services/helpers/screenSizeService";

export default class ToolbarController{
    constructor($timeout, $window, popupActionMenuService, $element, $scope) {
        "ngInject";
        Object.assign(this, {$timeout, $window, popupActionMenuService, $element, $scope});

        this.leftToolbarActions = [];
        this.rightToolbarActions = [];
        this.showMenuButton = false;
        this.showText = true;
        this.leftToolbarActionsWithTextWidth = 0;
        this.leftToolbarActionsWithoutTextWidth = 0;
        this.leftPart = $element.find('.left-toolbar-part');
        this.leftToolbar = this.leftPart.find('.left-toolbar');
    }

    createItems() {
        this.actionMenu = this.popupActionMenuService.createMenu(this.actions);
    }

    toolbarWidth() {
        let width = 0,
            leftToolbarActions = this.leftToolbar.children();
        for (let i = 0; i < leftToolbarActions.length; i++) {
            width += angular.element(leftToolbarActions[i]).outerWidth(true);
        }
        return width;
    }

    setShowText() {
        const isOverflow = this.isOverflow();
        if (isOverflow && this.showText && !this.leftToolbarActionsWithoutTextWidth) {
            this.showText = false;
            this.$timeout(() => {
                this.leftToolbarActionsWithoutTextWidth = this.toolbarWidth();
                this.updateMenuButtonVisibility();
            });
        } else {
            this.showText = !isOverflow;
        }
        this.updateMenuButtonVisibility();
    }

    init() {
        //Timeout here b/c ng-repeat for actions needs it
        this.$timeout(() => {
            this.leftToolbarActionsWithTextWidth = this.toolbarWidth();
            this.setShowText();
        });

        this.screenSizeCleaner = screenSizeService.addChangeScreenSizeListener(c => {
            this.$timeout(() => {
                this.setShowText();
            });
        })
    }

    isOverflow () {
        return this.leftToolbarActionsWithTextWidth > this.leftPart.outerWidth(true);
    }

    updateMenuButtonVisibility() {
        this.showMenuButton = !this.showText && this.leftToolbarActionsWithoutTextWidth > this.leftPart.outerWidth(true);
    }

    $onInit(){
        if (this.actions && this.actions.length > 0) {
            this.createItems();
        }
        const checker = visibilityChecker(this.$scope, this.$element, () => {
            this.init();
        });
        
        if (checker()) {
            this.init();
        }
    }

    $onDestroy(){
        if (this.screenSizeCleaner)
            this.screenSizeCleaner();
    }

    menuButtonClicked($event) {
        if (this.actionMenu !== null){
            this.actionMenu.show($event);
        }
    }

    quickSearchTextChanged(text, selectedField) {
        this.onQuickSearch({text: text, selectedField: selectedField});
    }

    actionDisabled(i) {
        const action = this.actions[i];
        const disabled = angular.isDefined(action.canInvoke) && !action.canInvoke;
        const items = this.actionMenuButton.element.find('li');
        if (disabled) {
            this.actionMenuButton.enable(items[i], false);
        } else {
            this.actionMenuButton.enable(items[i], true);
        }
        return disabled;
    }
}
