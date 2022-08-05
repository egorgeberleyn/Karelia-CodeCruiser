import template from "./toolbar.html"
import controller from "./toolbarController"

export default {
    template: template,
    bindings: {
        actions: "<",
        showQuickSearch: "<",
        quickSearchFields: "<",
        onQuickSearch: "&"
    },
    controller: controller
}
