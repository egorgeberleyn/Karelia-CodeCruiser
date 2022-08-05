import CodeBehindOfficeEquipmentModelWizardService from './codeBehind/codeBehindOfficeEquipmentModelWizardService';

export default class OfficeEquipmentModelWizardService extends CodeBehindOfficeEquipmentModelWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEquipmentModelWizardInitialization, officeEquipmentModelWizardFactory, officeEquipmentModelValidationService) {
		"ngInject";
		super(odataService, httpService, officeEquipmentModelWizardInitialization, officeEquipmentModelWizardFactory, officeEquipmentModelValidationService);
	}
}

