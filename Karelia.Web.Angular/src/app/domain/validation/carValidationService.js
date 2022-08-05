export default class  CarValidationService{
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

	CarModelId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	Number_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }


}
