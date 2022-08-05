export default class  CarServicePartValidationService{
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

	CarServiceId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	CarModelPartId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	Quantity_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }


}
