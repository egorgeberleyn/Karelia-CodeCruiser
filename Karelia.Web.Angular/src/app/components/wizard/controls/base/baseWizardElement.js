export class BaseWizardElement {
    init() {
        this.field = this.wizard.wizardContext.fields[this.name];
        this.model = this.wizard.wizardContext.model;
    }
}

export function getWizardElementDeclaration(template, controller) {
    return {
        require: {
            wizard: "^wizard",
            page: "^wizardPage",
            parentForm: "^form",
        },
        template,
        controller,
        bindings: {
            name: '@'
        }
    }
}