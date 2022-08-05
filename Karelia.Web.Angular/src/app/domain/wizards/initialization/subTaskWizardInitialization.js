import CodeBehindSubTaskWizardInitialization from './codeBehind/codeBehindSubTaskWizardInitialization';

export default class SubTaskWizardInitialization extends CodeBehindSubTaskWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

