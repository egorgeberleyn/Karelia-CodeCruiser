export default class MainToolbarService {
    constructor(runtimeStates) {
        "ngInject";
        this.runtimeStates = runtimeStates;

        this.currentActions = runtimeStates.getGlobalActions();
        this.caption = '';
        this.listeners = [];
    }
    _notifyChanged() {
        this.listeners.forEach(listener => {
            listener();
        });
    }
    setCurrentActions(actions) {
        this.currentActions = actions;
        this._notifyChanged();
    }
    setCaption(caption) {
        this.caption = caption;
        this._notifyChanged();
    }
    addChangeListener(callBack) {
        this.listeners.push(callBack);
    }
}

