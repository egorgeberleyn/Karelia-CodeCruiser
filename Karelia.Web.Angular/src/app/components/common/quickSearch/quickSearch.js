import template from './quick-search.html';
class QuickSearchController {
    constructor($scope, $timeout, $translate) {
        "ngInject";
        Object.assign(this, {$scope, $timeout, $translate});
        this.currentTimeout = null;
    }

    textChanged() {
        this.raiseUpdateEvent(false);
    }

    selectedFieldChanged() {
        if (this.value) {
            this.raiseUpdateEvent(true);
        }
    }

    raiseUpdateEvent(immediately) {
        if (this.currentTimeout) {
            this.$timeout.cancel(this.currentTimeout);
        }
        this.currentTimeout = this.$timeout(() => {
            this.onSearchableTextChanged({text: this.value, selectedField: this.selectedField});
            this.currentTimeout = null;
        }, immediately ? 0 : 2000);
    }

    keyPressed(keyEvent) {
        if (keyEvent.which === 13) {
            this.raiseUpdateEvent(true);
        }
    }

    clearClicked() {
        this.value = '';
        this.raiseUpdateEvent(true);
    }

    $onInit() {
        this.options = {
            dataSource: this.fields,
            optionLabel: this.$translate.instant('quick_search_all_column'),
            dataTextField: "name",
            dataValueField: "id",
            valuePrimitive: true,
            change: () => { this.selectedFieldChanged() }
        }
    }
}
export default {
    template: template,
    bindings: {
        fields: "=",
        onSearchableTextChanged: "&"
    },
    controller: QuickSearchController
}
