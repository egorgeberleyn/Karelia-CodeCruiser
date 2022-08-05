import CodeBehindCarModelWizardInitialization from './codeBehind/codeBehindCarModelWizardInitialization';

export default class CarModelWizardInitialization extends CodeBehindCarModelWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

