class ScreenComponentController {
    $onDestroy() {
        for (let key of Object.keys(this.contextState.actionDependencies)) {
            this.contextState.actionDependencies[key].watcher();
        }
    }
}

export default {
    template: '<div class="screen" ng-transclude></div>',
    bindings: {
        contextState: '=',
        blocks: "="
    },
    transclude: true,
    controller: ScreenComponentController
}
