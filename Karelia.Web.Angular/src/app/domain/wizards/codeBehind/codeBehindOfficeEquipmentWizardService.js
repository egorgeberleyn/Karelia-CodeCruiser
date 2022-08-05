export default class CodeBehindCodeBehindOfficeEquipmentWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEquipmentWizardInitialization, officeEquipmentWizardFactory, officeEquipmentValidationService) {
		Object.assign(this, {odataService, httpService, officeEquipmentWizardInitialization, officeEquipmentWizardFactory, officeEquipmentValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.officeEquipmentWizardFactory;
	}

	get template() {
		return 'OfficeEquipmentWizard';		
	}

	get domainControllerName() {
		return "OfficeEquipmentApi";
	}

	get wizardInitializationService() {
		return this.officeEquipmentWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "OfficeEquipmentWizardWizardSettings";
	}

	get validationService(){
		return "officeEquipmentValidationService";
	}

	get entityName() {
		return "OfficeEquipment"
	}

   officeEquipmentPage_OfficeEquipmentModelIdData(wizardState) {
	
	    return 'OfficeEquipmentModel?$select=Id,Name';	    
	}
	get officeEquipmentPage_OfficeEquipmentModelIdDataDependsOn(){
		return [];
	}
   officeEquipmentPage_OfficeEmployeeIdData(wizardState) {
	
	    return 'OfiiceEmployee?$select=Id,Name';	    
	}
	get officeEquipmentPage_OfficeEmployeeIdDataDependsOn(){
		return [];
	}
}

