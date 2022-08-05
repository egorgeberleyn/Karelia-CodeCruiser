export default class CodeBehindCodeBehindMainTaskWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, mainTaskWizardInitialization, mainTaskWizardFactory, mainTaskValidationService) {
		Object.assign(this, {odataService, httpService, mainTaskWizardInitialization, mainTaskWizardFactory, mainTaskValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.mainTaskWizardFactory;
	}

	get template() {
		return 'MainTaskWizard';		
	}

	get domainControllerName() {
		return "MainTaskApi";
	}

	get wizardInitializationService() {
		return this.mainTaskWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "MainTaskWizardWizardSettings";
	}

	get validationService(){
		return "mainTaskValidationService";
	}

	get entityName() {
		return "MainTask"
	}

   mainTaskPage_EmployeeIdData(wizardState) {
	
	    return 'OfiiceEmployee?$select=Id,Name';	    
	}
	get mainTaskPage_EmployeeIdDataDependsOn(){
		return [];
	}
}

