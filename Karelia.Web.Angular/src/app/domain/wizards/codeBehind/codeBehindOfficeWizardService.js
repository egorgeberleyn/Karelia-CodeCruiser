export default class CodeBehindCodeBehindOfficeWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeWizardInitialization, officeWizardFactory, officeValidationService) {
		Object.assign(this, {odataService, httpService, officeWizardInitialization, officeWizardFactory, officeValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.officeWizardFactory;
	}

	get template() {
		return 'OfficeWizard';		
	}

	get domainControllerName() {
		return "OfficeApi";
	}

	get wizardInitializationService() {
		return this.officeWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "OfficeWizardWizardSettings";
	}

	get validationService(){
		return "officeValidationService";
	}

	get entityName() {
		return "Office"
	}

}

