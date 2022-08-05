import CodeBehindSubTaskWizardService from './codeBehind/codeBehindSubTaskWizardService';

export default class SubTaskWizardService extends CodeBehindSubTaskWizardService {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		odataService, httpService, subTaskWizardInitialization, subTaskWizardFactory, subTaskValidationService) {
		"ngInject";
		super(odataService, httpService, subTaskWizardInitialization, subTaskWizardFactory, subTaskValidationService);
	}
}

