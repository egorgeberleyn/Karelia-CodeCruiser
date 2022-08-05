import CodeBehindOfficeEquipmentWizardService from './codeBehind/codeBehindOfficeEquipmentWizardService';

export default class OfficeEquipmentWizardService extends CodeBehindOfficeEquipmentWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEquipmentWizardInitialization, officeEquipmentWizardFactory, officeEquipmentValidationService) {
		"ngInject";
		super(odataService, httpService, officeEquipmentWizardInitialization, officeEquipmentWizardFactory, officeEquipmentValidationService);
	}
}

