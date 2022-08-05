export default class CodeBehindCodeBehindCarServicePartWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServicePartWizardInitialization, carServicePartWizardFactory, carServicePartValidationService) {
		Object.assign(this, {odataService, httpService, carServicePartWizardInitialization, carServicePartWizardFactory, carServicePartValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carServicePartWizardFactory;
	}

	get template() {
		return 'CarServicePartWizard';		
	}

	get domainControllerName() {
		return "CarServicePartApi";
	}

	get wizardInitializationService() {
		return this.carServicePartWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarServicePartWizardWizardSettings";
	}

	get validationService(){
		return "carServicePartValidationService";
	}

	get entityName() {
		return "CarServicePart"
	}

   carServicePartPage_CarModelPartIdData(wizardState) {
	
	    return 'CarModelPart?$select=Id,Name';	    
	}
	get carServicePartPage_CarModelPartIdDataDependsOn(){
		return [];
	}
}

