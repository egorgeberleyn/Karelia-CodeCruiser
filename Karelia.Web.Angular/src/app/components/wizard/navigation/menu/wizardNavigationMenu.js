import template from "./wizard-navigation-menu.html"
class WizardNavigationMenuController{
    constructor($scope){
        "ngInject";
        this.$scope = $scope;
        this._selectedIndex = -1;
    }

    $doCheck(){
        if (this.$scope.panelBar) {
            this.updatePanelBarState();
            if (this._selectedIndex != this.selectedIndex){
                this.selectItem(this.selectedIndex);
            }
        }

    }

    $onInit(){
        const self = this;
        self._selectedIndex
        this.navigationWizardMenuOptions = {
            dataSource: this.menuSections,
            select: function (e) {
                let item = angular.element(e.item),
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
                var section = dataItem;
                self._selectedIndex = section.index;
                self.onSectionSelect({index: section.index});
            }
        };

        this.$scope.$on("kendoWidgetCreated", (event, widget) => {
            if (widget.options.name === 'PanelBar') {
                this.selectItem(0);
                this.updatePanelBarState();
            }
        });

    }
    updatePanelBarState() {
        for (let i = 0; i < this.menuLinkStates.length; i++) {
            let linkState = this.menuLinkStates[i];
            let item = this.$scope.panelBar.element.children("li").eq(i);
            if (!linkState.visible) {
                item.hide();
            } else {
                item.show();
            }
            if (linkState.disable) {
                this.$scope.panelBar.disable(item);
            } else {
                this.$scope.panelBar.enable(item);
            }
        }
    }
    selectItem(index) {
        const items = this.$scope.panelBar.element.children('li');
        this.$scope.panelBar.select(items[index]);
    }

}
export default {
    template: template,
    bindings: {
        menuSections: "=",
        menuLinkStates: "=",
        selectedIndex: "=",
        onSectionSelect: "&"
    },
    controller: WizardNavigationMenuController
}

