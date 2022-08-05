import CodeBehindCarServiceWizardService from './codeBehind/codeBehindCarServiceWizardService';

export default class CarServiceWizardService extends CodeBehindCarServiceWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServiceWizardInitialization, carServiceWizardFactory, carServiceValidationService) {
		"ngInject";
		super(odataService, httpService, carServiceWizardInitialization, carServiceWizardFactory, carServiceValidationService);
	}
}

