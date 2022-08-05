import CodeBehindTasksService from './codeBehind/codeBehindTasksService';

export default class TasksService extends CodeBehindTasksService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, mainTaskWizardService, subTaskWizardService, wizardManagementService) {
		"ngInject";
		super($translate, stringFormat, enumsService, domainManagementService, mainTaskWizardService, subTaskWizardService, wizardManagementService);
    }
}
