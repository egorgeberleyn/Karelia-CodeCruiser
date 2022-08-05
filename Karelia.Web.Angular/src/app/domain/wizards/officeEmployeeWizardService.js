import CodeBehindOfficeEmployeeWizardService from './codeBehind/codeBehindOfficeEmployeeWizardService';

export default class OfficeEmployeeWizardService extends CodeBehindOfficeEmployeeWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, officeEmployeeWizardInitialization, officeEmployeeWizardFactory, ofiiceEmployeeValidationService) {
		"ngInject";
		super(odataService, httpService, officeEmployeeWizardInitialization, officeEmployeeWizardFactory, ofiiceEmployeeValidationService);
	}
}

