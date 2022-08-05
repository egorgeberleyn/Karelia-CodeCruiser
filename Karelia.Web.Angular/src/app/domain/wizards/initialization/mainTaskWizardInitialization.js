import CodeBehindMainTaskWizardInitialization from './codeBehind/codeBehindMainTaskWizardInitialization';

export default class MainTaskWizardInitialization extends CodeBehindMainTaskWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

