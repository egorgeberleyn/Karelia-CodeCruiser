export default class CodeBehindCodeBehindCarModelWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carModelWizardInitialization, carModelWizardFactory, carModelValidationService) {
		Object.assign(this, {odataService, httpService, carModelWizardInitialization, carModelWizardFactory, carModelValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carModelWizardFactory;
	}

	get template() {
		return 'CarModelWizard';		
	}

	get domainControllerName() {
		return "CarModelApi";
	}

	get wizardInitializationService() {
		return this.carModelWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarModelWizardWizardSettings";
	}

	get validationService(){
		return "carModelValidationService";
	}

	get entityName() {
		return "CarModel"
	}

}

