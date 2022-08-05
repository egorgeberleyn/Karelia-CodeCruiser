import CodeBehindOfficeEquipmentModelWizardInitialization from './codeBehind/codeBehindOfficeEquipmentModelWizardInitialization';

export default class OfficeEquipmentModelWizardInitialization extends CodeBehindOfficeEquipmentModelWizardInitialization {
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		httpService){
		"ngInject";
		super(httpService);
	}
}

