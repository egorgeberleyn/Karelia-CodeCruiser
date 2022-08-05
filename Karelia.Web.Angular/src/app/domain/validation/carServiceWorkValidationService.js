export default class  CarServiceWorkValidationService{
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

	CarWorkTypeId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }


}
