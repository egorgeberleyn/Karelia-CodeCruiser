import template from "./tabContainer.html";
import angular from 'angular';

class TabContainerController {
    constructor($timeout, $element, $scope, $attrs) {
        'ngInject';
        Object.assign(this, { $timeout, $element, $scope, $attrs });
        this.tabs = [];
    }

    addTab(tab) {
        this.tabs.push(tab);
    }

    $onInit() {
        this.$element.toggle(false);
        this.$timeout(() => {
            const tab = this.$element.find('.tab-control');
            const tabItems = tab.children();

            for (let i = 0; i < tabItems.length; i++) {
                const tabItem = tabItems[i];
                const wrapper = angular.element('<div class="tab-item-wrapper"></div>');
                angular.element(tabItem).appendTo(wrapper);
                wrapper.appendTo(tab);
            }

            const caption = this.$element.find('.tab-caption');
            tab[0].insertBefore(caption[0], tab[0].firstChild);
            tab.kendoTabStrip({
                animation: {
                    open: {
                        effects: "fade"
                    }
                },
                activate: () => {
                    this.$scope.$digest();
                }
            });
            this.$element.toggle(true);
        });
    }
}
export default {
    template: template,
    transclude: true,
    bindings: {
        settings: "=",
        contextState: "="
    },
    controller: TabContainerController
}

