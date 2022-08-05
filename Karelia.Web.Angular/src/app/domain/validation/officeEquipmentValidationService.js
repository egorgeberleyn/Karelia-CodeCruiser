export default class  OfficeEquipmentValidationService{
	constructor($q, odataService, httpService){
		"ngInject";
		Object.assign(this, {$q, odataService, httpService});
	}

	Id_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	OfficeId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	OfficeEquipmentModelId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	InventoryNumber_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	OfficeEmployeeId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }


}
