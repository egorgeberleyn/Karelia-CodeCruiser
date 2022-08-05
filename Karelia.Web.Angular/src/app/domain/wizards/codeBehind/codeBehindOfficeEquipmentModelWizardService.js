export default class CodeBehindCodeBehindOfficeEquipmentModelWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEquipmentModelWizardInitialization, officeEquipmentModelWizardFactory, officeEquipmentModelValidationService) {
		Object.assign(this, {odataService, httpService, officeEquipmentModelWizardInitialization, officeEquipmentModelWizardFactory, officeEquipmentModelValidationService});
	}

	customizeField(field, wizardContext) {
	}

	get objectFactory() {
		return this.officeEquipmentModelWizardFactory;
	}

	get template() {
		return 'OfficeEquipmentModelWizard';		
	}

	get domainControllerName() {
		return "OfficeEquipmentModelApi";
	}

	get wizardInitializationService() {
		return this.officeEquipmentModelWizardInitialization;
	}

	get wizardSettingsControllerName() {
		return "OfficeEquipmentModelWizardWizardSettings";
	}

	get validationService(){
		return "officeEquipmentModelValidationService";
	}

	get entityName() {
		return "OfficeEquipmentModel"
	}

}

