import CodeBehindCarServicePartWizardInitialization from './codeBehind/codeBehindCarServicePartWizardInitialization';

export default class CarServicePartWizardInitialization extends CodeBehindCarServicePartWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

