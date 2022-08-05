import CodeBehindModelEquipmentsService from './codeBehind/codeBehindModelEquipmentsService';

export default class ModelEquipmentsService extends CodeBehindModelEquipmentsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, officeEquipmentModelWizardService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, domainManagementService, officeEquipmentModelWizardService, wizardManagementService);
    }
}
