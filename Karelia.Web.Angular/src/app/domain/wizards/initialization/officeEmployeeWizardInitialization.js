import CodeBehindOfficeEmployeeWizardInitialization from './codeBehind/codeBehindOfficeEmployeeWizardInitialization';

export default class OfficeEmployeeWizardInitialization extends CodeBehindOfficeEmployeeWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

