import CodeBehindOfficeWizardService from './codeBehind/codeBehindOfficeWizardService';

export default class OfficeWizardService extends CodeBehindOfficeWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeWizardInitialization, officeWizardFactory, officeValidationService) {
		"ngInject";
		super(odataService, httpService, officeWizardInitialization, officeWizardFactory, officeValidationService);
	}
}

