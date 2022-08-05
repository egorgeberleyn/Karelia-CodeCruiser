import CodeBehindOfficeWizardInitialization from './codeBehind/codeBehindOfficeWizardInitialization';

export default class OfficeWizardInitialization extends CodeBehindOfficeWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

