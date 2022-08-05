import CodeBehindCarModelPartWizardInitialization from './codeBehind/codeBehindCarModelPartWizardInitialization';

export default class CarModelPartWizardInitialization extends CodeBehindCarModelPartWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

