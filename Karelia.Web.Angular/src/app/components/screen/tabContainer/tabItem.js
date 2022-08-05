import template from './tabItem.html';

class TabItemController {
    constructor($element) {
        'ngInject'
        this.$element = $element;
    }
    $onInit() {
        const tab = this.screenCtrl.blocks[this.tabCtrl.$attrs.name];
        const tabInfo = tab.children.find(t => t.name === this.name);
        this.tabCtrl.addTab({
            title: tabInfo.title
        });
    }
}

export default {
    template,
    transclude: true,
    bindings: {
        name: "@"
    },
    require: {
        tabCtrl: "^tabContainer",
        screenCtrl: "^screen"
    },
    controller: TabItemController
}