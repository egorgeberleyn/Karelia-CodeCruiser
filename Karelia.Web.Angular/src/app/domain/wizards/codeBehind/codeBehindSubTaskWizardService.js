export default class CodeBehindCodeBehindSubTaskWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, subTaskWizardInitialization, subTaskWizardFactory, subTaskValidationService) {
		Object.assign(this, {odataService, httpService, subTaskWizardInitialization, subTaskWizardFactory, subTaskValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.subTaskWizardFactory;
	}

	get template() {
		return 'SubTaskWizard';		
	}

	get domainControllerName() {
		return "SubTaskApi";
	}

	get wizardInitializationService() {
		return this.subTaskWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "SubTaskWizardWizardSettings";
	}

	get validationService(){
		return "subTaskValidationService";
	}

	get entityName() {
		return "SubTask"
	}

}

