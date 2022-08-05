import { wrapAction } from './actionInvoker';
import { normalize } from '../helpers/stringHelpers';

function buildClassName(declaration) {
    return `action-${normalize(declaration.actionName)} 
            ${normalize(declaration.image)}
            icon-${normalize(declaration.className)}`;
}

function createAction(declaration, isGlobal, service, contextState, settingsName, messageBoxService) {
    const action = {
        name: declaration.title,
        toolbarAlignment: declaration.toolbarAlligement,
        position: declaration.position,
        className: buildClassName(declaration)
    };

    if (isGlobal) {
        action.invoke = () => {
            return service[declaration.actionName]();
        }
    } else {
        action.invoke = () => {
            return wrapAction(() => {
                return service[declaration.actionName](declaration, contextState);
            }, messageBoxService)
                .then(result => {
                    if (service[declaration.actionName + 'PostExecute']) {
                        return service[declaration.actionName + 'PostExecute'](result, declaration, contextState);
                    }
                });
        };

        const method = service[declaration.actionName + "CanExecute"];
        const canExecuteMethod = () => {
            if (method)
                return method(contextState);
            return true;
        };

        const depends = service[declaration.actionName + "CanExecuteDependsOn"] || [];
        depends.push(settingsName);
        for (let i = 0; i < depends.length; i++) {
            contextState.addDependency(depends[i], () => {
                action.canInvoke = canExecuteMethod();
            });
        }
        action.canInvoke = canExecuteMethod();
        action.canExecute = canExecuteMethod;
    }
    contextState.actions.push(action);
    return action;
}

export function disableAll(actions) {
    actions.forEach((action) => {
        action.canInvoke = false;
    });
}

export function restoreDefaultCanExecute(actions) {
    actions.forEach((action) => {
        action.canInvoke = action.canExecute();
    });
}

export function createGlobalActionsByDeclaration(services, actionDeclarations) {
    return createActionsByDeclaration(services, actionDeclarations, () => { }/*MOCK service*/, true);
}

export function createActionsByDeclaration(services, actionDeclarations, service, isGlobal, contextState, settingsName) {
    let parentItem = { items: [] },
        root = parentItem;
    actionDeclarations.forEach(actionDeclaration => {
        //Action - 0
        //Action group - 1
        if (actionDeclaration.type === 0) {
            const action = createAction(actionDeclaration, isGlobal, service, contextState, settingsName, services.messageBoxService);
            parentItem.items.push(action);
        } else if (actionDeclaration.type === 1) {
            const actionGroup = {
                name: actionDeclaration.title,
                items: []
            };
            parentItem.items.push(actionGroup);
            actionDeclaration.items.forEach(subItemDeclaration => {
                const action = createAction(subItemDeclaration, isGlobal, service, contextState, screenBlockName, services.messageBoxService);
                actionGroup.items.push(action)
            });
        }
    });

    return root.items;
}



