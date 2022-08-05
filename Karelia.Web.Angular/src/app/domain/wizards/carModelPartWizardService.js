import CodeBehindCarModelPartWizardService from './codeBehind/codeBehindCarModelPartWizardService';

export default class CarModelPartWizardService extends CodeBehindCarModelPartWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carModelPartWizardInitialization, carModelPartWizardFactory, carModelPartValidationService) {
		"ngInject";
		super(odataService, httpService, carModelPartWizardInitialization, carModelPartWizardFactory, carModelPartValidationService);
	}
}

