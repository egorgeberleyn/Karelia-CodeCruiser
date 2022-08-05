import angular from 'angular'

export default class ModalWindowService {
    constructor($q, $rootScope, $document, $templateCache, $templateRequest, $compile, $controller, $timeout) {
        'ngInject';
        this.currentWindows = [];

        this.q = $q;
        this.root = $rootScope;
        this.$templateCache = $templateCache;
        this.$templateRequest = $templateRequest;
        this.$compile = $compile;
        this.$controller = $controller;
        this.$timeout = $timeout;
        this.$document = $document;
    }

    _internalHide(id, reject) {
        if (this.currentWindows[id]) {
            if (this.currentWindows[id].element) {
                this.currentWindows[id].element.parent().remove();
            }
            this.currentWindows[id].scope.$destroy();
            if (reject) {
                this.currentWindows[id].promise.reject();
            }
            delete this.currentWindows[id];

        }
    }

    _closeWindow(id) {
        const kendoWindow = angular.element('#kendoWindow' + id).data('kendoWindow');
        if (kendoWindow) {
            kendoWindow.close();
        }
    }

    _showModalWindow(options, template, scope, defer) {
        if (!options.locals) {
            options.locals = {};
        }
        options.locals.$scope = scope;

        if (options.controller) {
            const controllerAlias = options.controllerAs ? options.controllerAs : options.controller;
            scope[controllerAlias] = this.$controller(options.controller, options.locals);
        } else if (options.locals){
            scope = angular.extend(scope, options.locals);
        }

        const popup = angular.element("<div id='kendoWindow" + scope.$id + "'></div>");
        const compiledContent = this.$compile(angular.element(template))(scope);
        compiledContent.appendTo(popup);
        const body = this.$document.find('body').eq(0);
        body.append(popup);

        const kendoOptions = {visible: false};
        if (options.actions) {
            kendoOptions.actions = options.actions;
        }
        if (options.title) {
            kendoOptions.title = options.title;
        }
        if (options.width){
            kendoOptions.width = options.width;
        }
        if (options.height){
            kendoOptions.height = options.height;
        }
        kendoOptions.close = () => {
            this._internalHide(scope.$id, true);
        };
        kendoOptions.open = () => {
            if (options.opened) {
                options.opened();
            }
        }

        const kendoWindow = popup.kendoWindow(kendoOptions).data('kendoWindow');

        if (options.cssClass) {
            kendoWindow.wrapper.addClass(options.cssClass);
        }

        this.currentWindows[scope.$id] = {
            promise: defer,
            element: popup,
            scope: scope
        };

        if (options.resizeCallback) {
            this.$timeout(() => {
                const kendoWindow = angular.element('#kendoWindow' + scope.$id).data('kendoWindow');
                const size = options.resizeCallback(kendoWindow.element);
                kendoWindow.wrapper.css(size);
                kendoWindow.center().open();
                if (options.maximize)
                    kendoWindow.maximize();
            }, 1000);
        } else {
            this.$timeout(() => {
                kendoWindow.center().open();
                if (options.maximize)
                    kendoWindow.maximize();
            });
        }
    }

    hide(id, model) {
        if (this.currentWindows[id]) {
            this.currentWindows[id].promise.reject(model);
        }
        this._closeWindow(id);
    }

    confirm(id, model) {
        if (this.currentWindows[id]) {
            this.currentWindows[id].promise.resolve(model);
        }
        this._closeWindow(id);
    }

    show(options) {
        const defer = this.q.defer(),
            scope = this.root.$new();

        const template = options.templateUrl ? this.$templateCache.get(options.templateUrl) : options.template;
        if (!template) {
            this.$templateRequest(options.templateUrl).then(template => {
                this.$templateCache.put(options.templateUrl, template);
                this._showModalWindow(options, template, scope, defer);
            });
        } else {
            this._showModalWindow(options, template, scope, defer);
        }
        return {
            promise: defer.promise,
            hide: () => {
                this._closeWindow(scope.$id);
            }
        };
    }
}
