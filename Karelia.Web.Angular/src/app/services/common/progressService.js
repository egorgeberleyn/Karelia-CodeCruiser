class ProgressService {
    constructor() {
        this.listenerCallbacks = [];
    }

    show() {
        this.showSpinner = true;
        this._raiseChanged();
    }

    hide() {
        this.showSpinner = false;
        this._raiseChanged();
    };

    _raiseChanged() {
        this.listenerCallbacks.forEach((callback) => {
            callback(this.showSpinner);
        });
    };

    addListener(callback) {
        this.listenerCallbacks.push(callback);
    }
}

export default new ProgressService();
