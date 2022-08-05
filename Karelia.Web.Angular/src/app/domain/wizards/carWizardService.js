import CodeBehindCarWizardService from './codeBehind/codeBehindCarWizardService';

export default class CarWizardService extends CodeBehindCarWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carWizardInitialization, carWizardFactory, carValidationService) {
		"ngInject";
		super(odataService, httpService, carWizardInitialization, carWizardFactory, carValidationService);
	}
}

