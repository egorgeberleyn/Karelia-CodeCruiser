import CodeBehindCarModelWizardService from './codeBehind/codeBehindCarModelWizardService';

export default class CarModelWizardService extends CodeBehindCarModelWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, carModelWizardInitialization, carModelWizardFactory, carModelValidationService) {
		"ngInject";
		super(odataService, httpService, carModelWizardInitialization, carModelWizardFactory, carModelValidationService);
	}
}

