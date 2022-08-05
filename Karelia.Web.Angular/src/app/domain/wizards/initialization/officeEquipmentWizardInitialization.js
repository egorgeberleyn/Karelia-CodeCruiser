import CodeBehindOfficeEquipmentWizardInitialization from './codeBehind/codeBehindOfficeEquipmentWizardInitialization';

export default class OfficeEquipmentWizardInitialization extends CodeBehindOfficeEquipmentWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

