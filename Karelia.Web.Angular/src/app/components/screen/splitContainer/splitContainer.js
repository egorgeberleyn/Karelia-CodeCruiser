import template from "./splitContainer.html"
import screenSizeService from "../../../services/helpers/screenSizeService";

class SplitContainerController{
    constructor($timeout, $rootScope, $element){
        "ngInject";
        Object.assign(this, {$timeout, $rootScope, $element});
        this.showCollapseButton = false;
        this.collapsed = false;
    }

    collapseClicked() {
        const splitter = this.$element.find('.split-control').data('kendoSplitter');
        const panes = splitter.element.find('.k-pane');
        const collapsingPanel = panes[this.settings.collapsingPanel - 1];
        if (this.collapsed) {
            splitter.expand(collapsingPanel);
        } else {
            splitter.collapse(collapsingPanel);
        }
        this.collapsed = !this.collapsed;
        
    }

    collapse(e){
        e.sender.$angular_scope.$ctrl.collapsed = true;
    }

    expand(e){
        e.sender.$angular_scope.$ctrl.collapsed = false;
    }

    $onInit(){
        this.contextState = this.screenCtrl.contextState;
        this.settings = this.screenCtrl.blocks[this.name];
        this.showCollapseButton = !this.contextState.firstSplitterCreated && this.settings.collapsingPanel;
        this.contextState.firstSplitterCreated = true;
        this.orientation = this.settings.orientation === 0 ? 'vertical' : 'horizontal';
        this.panes = "[";
        let first = true;
        for (let i = 1; i <= 2; i++) {
            if (!first) {
                this.panes += ", ";
            }
            const ratio = i === 1 ? this.settings.panelsRatio : 1 - this.settings.panelsRatio;
            this.panes += "{ size : '" + (ratio * 100) + "%' ";
            this.panes += ', collapsible: ' + (this.settings.collapsingPanel === i ? 'true' : 'false');
            this.panes += ', resizable: true';
            this.panes += "}";
            first = false;
        }
        this.panes += "]";
        this.$timeout(() => {
            this.created = true;
        });
    }

    onResize(e){
        e.sender.$angular_scope.$ctrl.$timeout(() => {
            screenSizeService.raiseResizeEvent();
        }, 10);

    }
}
export default {
    template: template,
    bindings: {
        name: "@"
    },
    require: { 
        screenCtrl: '^screen' 
    },
    transclude: {
        'panel1': 'splitPanel1',
        'panel2': 'splitPanel2'
    },
    controller: SplitContainerController
}
