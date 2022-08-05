import dataTypeHelperService from '../../../services/helpers/dataTypeHelperService'

const VALIDATOR_TYPES = {
    NONE: 0,
    REQUIRED: 1,
    REGEX: 2,
    UNIQUE: 3
};

function getPageFields(editors, domainService, wizardContext) {
    return editors.map(editor => {
        const field = {
            name: editor.field.name,
            title: editor.title,
            type: dataTypeHelperService.getEditorTypeById(editor.type),
            dataType: editor.field.dataType,
            readonly: wizardContext.readonly || editor.readOnly
        };

        if (field.type === "text" && editor.isMultiline) {
            field.type = "multiline";
            field.lineCount = editor.lineCount;
        }

			if (field.type === 'numeric') {
            field.step = editor.step;
        }

        if (field.type === "combobox") {
            field.displayField = editor.displayField;
            field.valueField = editor.valueField;

            const dataExtractorName = editor.name + 'Data';
            field.dataSourcePath = domainService[dataExtractorName](wizardContext);
						field.serverFiltering = false;
						
						const dataSourceFilter = editor.name + 'SourceFilter';
						if (domainService[dataSourceFilter]) {
							field.sourceFilter = () => domainService[dataSourceFilter](wizardContext);
						}
            const depends = domainService[editor.name + 'DataDependsOn'];
            if (depends && depends.length > 0) {
							field.dataSourcePathRefresher = function() {
										field.dataSourcePath = domainService[dataExtractorName](wizardContext);
                };
                field.sourceDependencies = depends;
            }
        }
        if (editor.validators && editor.validators.length > 0) {
            field.validators = [];
            for (let i = 0; i < editor.validators.length; i++) {
                const validatorDeclar = editor.validators[i];
                const validator = {
                    name: validatorDeclar.handler,
                    method: domainService[domainService.validationService][validatorDeclar.handler],
                    message: validatorDeclar.message,
                    context: domainService[domainService.validationService],
                    async: validatorDeclar.handler.lastIndexOf('Async') >= 0
                };

                if (validatorDeclar.type === VALIDATOR_TYPES.REQUIRED) {
                    field.required = true;
                }

                field.validators.push(validator);
            }
        }
        if (domainService.customizeField) {
            domainService.customizeField(field, wizardContext);
        }
        return field;
    });
}

function createPage(title, name, index, validate, bannerTitle, bannerDescription, fields) {
    return {
        title: title,
        name: name,
        index: index,
        noValidate: !validate,
        bannerTitle: bannerTitle,
        bannerDescription: bannerDescription,
        fields: fields
    };
}

export function getWizardFields (pages) {
    const fields = {};
    pages.forEach(page => {
        if (page.fields && page.fields.length > 0) {
            page.fields.forEach(field => {
                fields[field.name] = field;
            }) 
        }
    });
    return fields;
}

export function createWizardPages(wizardSettings, readonly, wizardContext, service) {
    const pages = [];
    let index = 0;
    if (wizardSettings.items) {
        wizardSettings.items.forEach(pageDescr => {
            const fields = getPageFields(pageDescr.editors, service, wizardContext);
            pages.push(createPage(pageDescr.title, pageDescr.name, index++, !readonly, pageDescr.bannerTitle, pageDescr.bannerDescription, fields));
        });
    }
    return pages;
}




