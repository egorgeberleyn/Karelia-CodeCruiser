import CodeBehindCarsService from './codeBehind/codeBehindCarsService';

export default class CarsService extends CodeBehindCarsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carServicePartWizardService, carServiceWizardService, carServiceWorkWizardService, carWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, carServicePartWizardService, carServiceWizardService, carServiceWorkWizardService, carWizardService, domainManagementService, wizardManagementService);
    }
}
