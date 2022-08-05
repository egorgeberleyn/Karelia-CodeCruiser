export default class CodeBehindCodeBehindCarServiceWorkWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServiceWorkWizardInitialization, carServiceWorkWizardFactory, carServiceWorkValidationService) {
		Object.assign(this, {odataService, httpService, carServiceWorkWizardInitialization, carServiceWorkWizardFactory, carServiceWorkValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carServiceWorkWizardFactory;
	}

	get template() {
		return 'CarServiceWorkWizard';		
	}

	get domainControllerName() {
		return "CarServiceWorkApi";
	}

	get wizardInitializationService() {
		return this.carServiceWorkWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarServiceWorkWizardWizardSettings";
	}

	get validationService(){
		return "carServiceWorkValidationService";
	}

	get entityName() {
		return "CarServiceWork"
	}

   carServiceWorkPage_CarWorkTypeIdData(wizardState) {
	
	    return 'CarWorkType?$select=Id,Name';	    
	}
	get carServiceWorkPage_CarWorkTypeIdDataDependsOn(){
		return [];
	}
}

