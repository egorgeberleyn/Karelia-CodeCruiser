class MainMenuService {
    constructor() {
        this.screenClasses = {};
        this.callbacks = [];
    }

    setScreenClass(screenName, className) {
        this.screenClasses[screenName] = className;
        this.invokeChanges(screenName, className);
    }

    invokeChanges(...args) {
        this.callbacks.forEach(c => c(...args));
    }

    registerCallback(callback){
        this.callbacks.push(callback);
    }

    unregisterCallback(callback){
        const index = this.callbacks.indexOf(callback);
        if (index !== -1){
            this.callbacks.splice(index, 1);
        }
    }

    getMainMenu(runtimeStates, state) {
        const groups = runtimeStates.getStates();
        if (groups && groups.length > 0) {
            var items = [];
            var index = 0;
            groups.forEach(group => {
                var item = {
                    text: group.title,
                    items: []
                };
                group.screens.forEach(screen => {
                    if (!screen.name || screen.name.type !== 1) {
                        var stateName = 'app.' + screen.name;
                        var subItem = {
                            index: index++,
                            encoded: false,
                            text: screen.title,
                            state: stateName,
                            controller: screen.controller,
                            cssClass: `name-${screen.name} ${screen.image} ${this.screenClasses[screen.name]? this.screenClasses[screen.name]: ''}`
                        };
                        item.items.push(subItem);
                    }
                });
                if (item.items.length > 0) {
                    items.push(item);
                }
            });

            return items;
        } else {
            state.go('login');
        }
        return [];
    }
}

export default new MainMenuService();
