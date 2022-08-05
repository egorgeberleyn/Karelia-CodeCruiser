import CodeBehindMainTaskWizardService from './codeBehind/codeBehindMainTaskWizardService';

export default class MainTaskWizardService extends CodeBehindMainTaskWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, mainTaskWizardInitialization, mainTaskWizardFactory, mainTaskValidationService) {
		"ngInject";
		super(odataService, httpService, mainTaskWizardInitialization, mainTaskWizardFactory, mainTaskValidationService);
	}
}

