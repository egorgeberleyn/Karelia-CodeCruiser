export default class CodeBehindCodeBehindCarModelPartWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carModelPartWizardInitialization, carModelPartWizardFactory, carModelPartValidationService) {
		Object.assign(this, {odataService, httpService, carModelPartWizardInitialization, carModelPartWizardFactory, carModelPartValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carModelPartWizardFactory;
	}

	get template() {
		return 'CarModelPartWizard';		
	}

	get domainControllerName() {
		return "CarModelPartApi";
	}

	get wizardInitializationService() {
		return this.carModelPartWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarModelPartWizardWizardSettings";
	}

	get validationService(){
		return "carModelPartValidationService";
	}

	get entityName() {
		return "CarModelPart"
	}

}

