import CodeBehindCarServiceWizardInitialization from './codeBehind/codeBehindCarServiceWizardInitialization';

export default class CarServiceWizardInitialization extends CodeBehindCarServiceWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

