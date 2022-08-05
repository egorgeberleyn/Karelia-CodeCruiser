export default class CodeBehindCodeBehindCarWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carWizardInitialization, carWizardFactory, carValidationService) {
		Object.assign(this, {odataService, httpService, carWizardInitialization, carWizardFactory, carValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carWizardFactory;
	}

	get template() {
		return 'CarWizard';		
	}

	get domainControllerName() {
		return "CarApi";
	}

	get wizardInitializationService() {
		return this.carWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarWizardWizardSettings";
	}

	get validationService(){
		return "carValidationService";
	}

	get entityName() {
		return "Car"
	}

   carPage_CarModelIdData(wizardState) {
	
	    return 'CarModel?$select=Id,Name';	    
	}
	get carPage_CarModelIdDataDependsOn(){
		return [];
	}
}

