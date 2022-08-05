import CodeBehindWorksService from './codeBehind/codeBehindWorksService';

export default class WorksService extends CodeBehindWorksService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carServiceWizardService, carWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, carServiceWizardService, carWizardService, domainManagementService, wizardManagementService);
    }
}
