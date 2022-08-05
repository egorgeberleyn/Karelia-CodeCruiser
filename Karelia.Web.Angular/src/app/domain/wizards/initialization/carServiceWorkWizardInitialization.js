import CodeBehindCarServiceWorkWizardInitialization from './codeBehind/codeBehindCarServiceWorkWizardInitialization';

export default class CarServiceWorkWizardInitialization extends CodeBehindCarServiceWorkWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

