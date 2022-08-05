import dataTypeHelperService from "../helpers/dataTypeHelperService";

function createChild(parent, settings) {
    if (settings) {
        const element = document.createElement(`div`);
        element.className = settings.name;
        switch (settings.type) {
            case 6:
                createChild(element, settings.panel1);
                createChild(element, settings.panel2);
                break;
            case 3:
            case 8:
                for (let i = 0; i < settings.children.length; i++) {
                    const child = settings.children[i];
                    createChild(element, child.content);
                }
                break;
        }
        parent.appendChild(element);
    }
    return;
}

export function getScreenHtmlTemplate(settings) {
    const root = document.createElement('div');
    root.className = "root";
    createChild(root, settings.content);
    return root.outerHTML;
}

function getChildBlocks(settings, blocks) {
    blocks = Object.assign({}, blocks);
    if (blocks && settings) {
        blocks[settings.name] = settings;
        if (settings.type === 6) { // Split
            blocks = getChildBlocks(settings.panel1, blocks);
            blocks = getChildBlocks(settings.panel2, blocks);
        } else if (settings.type === 3)  { // Tab
            for (let i = 0; i < settings.children.length; i++) {
                const child = settings.children[i];
                blocks = getChildBlocks(child.content, blocks);
            }
        } else if (settings.type === 2) { // GridLayout
            for (let i = 0; i < settings.children.length; i++) {
                const child = settings.children[i];
                blocks = getChildBlocks(child, blocks);
            }
        }
    }
    return blocks;
}

export function getBlocks(settings) {
    return getChildBlocks(settings.content, {});
}

export function getWizardHtmlTemplate(settings) {
    const element = document.createElement('wizard-content');
    settings.items.forEach((pageDescr, index) => {
        const page = document.createElement('page');
        page.setAttribute('name', pageDescr.name);
        const form = document.createElement('form');
        form.setAttribute('name', `pageForm${index}`);
        pageDescr.editors.forEach(editorDescr => {
            const editor = document.createElement(getEditor(dataTypeHelperService.getEditorTypeById(editorDescr.type)));
            editor.setAttribute('name', editorDescr.field.name);
            form.appendChild(editor);
        });
        page.appendChild(form);
        element.appendChild(page);
    });
    return element.outerHTML;
}

function getEditor(type) {
    switch (type) {
        case "autocomplete":
            return "wizard-autocomplete";
        case "dropdownlist":
            return "wizard-drop-down-list";
        case "combobox":
            return "wizard-combobox";
        case "checkbox":
            return "wizard-checkbox";
        case "numeric":
            return "wizard-numeric";
        case "date":
            return "wizard-date-picker";
        case "picture":
            return "wizard-fileupload";
        case "multiline":
            return "wizard-multiline";
        default:
            return "wizard-input";

    }
}