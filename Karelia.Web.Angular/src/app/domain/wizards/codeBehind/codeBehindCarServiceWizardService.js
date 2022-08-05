export default class CodeBehindCodeBehindCarServiceWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServiceWizardInitialization, carServiceWizardFactory, carServiceValidationService) {
		Object.assign(this, {odataService, httpService, carServiceWizardInitialization, carServiceWizardFactory, carServiceValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.carServiceWizardFactory;
	}

	get template() {
		return 'CarServiceWizard';		
	}

	get domainControllerName() {
		return "CarServiceApi";
	}

	get wizardInitializationService() {
		return this.carServiceWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "CarServiceWizardWizardSettings";
	}

	get validationService(){
		return "carServiceValidationService";
	}

	get entityName() {
		return "CarService"
	}

   carServicePage_CarArrivalReasonTypeIdData(wizardState) {
	
	    return 'CarArrivalReasonType?$select=Id,Name';	    
	}
	get carServicePage_CarArrivalReasonTypeIdDataDependsOn(){
		return [];
	}
}

