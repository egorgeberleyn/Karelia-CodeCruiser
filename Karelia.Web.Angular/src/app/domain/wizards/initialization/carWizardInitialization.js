import CodeBehindCarWizardInitialization from './codeBehind/codeBehindCarWizardInitialization';

export default class CarWizardInitialization extends CodeBehindCarWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

