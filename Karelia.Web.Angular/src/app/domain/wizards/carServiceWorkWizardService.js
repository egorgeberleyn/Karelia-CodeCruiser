import CodeBehindCarServiceWorkWizardService from './codeBehind/codeBehindCarServiceWorkWizardService';

export default class CarServiceWorkWizardService extends CodeBehindCarServiceWorkWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServiceWorkWizardInitialization, carServiceWorkWizardFactory, carServiceWorkValidationService) {
		"ngInject";
		super(odataService, httpService, carServiceWorkWizardInitialization, carServiceWorkWizardFactory, carServiceWorkValidationService);
	}
}

