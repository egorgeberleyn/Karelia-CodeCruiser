import CodeBehindCarModelsService from './codeBehind/codeBehindCarModelsService';

export default class CarModelsService extends CodeBehindCarModelsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carModelPartWizardService, carModelWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, carModelPartWizardService, carModelWizardService, domainManagementService, wizardManagementService);
    }
}
