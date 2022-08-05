export default class CodeBehindCodeBehindOfficeEmployeeWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEmployeeWizardInitialization, officeEmployeeWizardFactory, ofiiceEmployeeValidationService) {
		Object.assign(this, {odataService, httpService, officeEmployeeWizardInitialization, officeEmployeeWizardFactory, ofiiceEmployeeValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.officeEmployeeWizardFactory;
	}

	get template() {
		return 'OfficeEmployeeWizard';		
	}

	get domainControllerName() {
		return "OfiiceEmployeeApi";
	}

	get wizardInitializationService() {
		return this.officeEmployeeWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "OfficeEmployeeWizardWizardSettings";
	}

	get validationService(){
		return "ofiiceEmployeeValidationService";
	}

	get entityName() {
		return "OfiiceEmployee"
	}

}

