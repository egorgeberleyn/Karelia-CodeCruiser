import CodeBehindOfficeService from './codeBehind/codeBehindOfficeService';

export default class OfficeService extends CodeBehindOfficeService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, officeEmployeeWizardService, officeEquipmentWizardService, officeWizardService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, domainManagementService, officeEmployeeWizardService, officeEquipmentWizardService, officeWizardService, wizardManagementService);
    }
}
