import CodeBehindCarServicePartWizardService from './codeBehind/codeBehindCarServicePartWizardService';

export default class CarServicePartWizardService extends CodeBehindCarServicePartWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carServicePartWizardInitialization, carServicePartWizardFactory, carServicePartValidationService) {
		"ngInject";
		super(odataService, httpService, carServicePartWizardInitialization, carServicePartWizardFactory, carServicePartValidationService);
	}
}

