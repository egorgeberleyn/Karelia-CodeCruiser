export default class  MainTaskValidationService{
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

	Name_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	EmployeeId_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }

	IsCompleted_Required (value, model) {
    if (angular.isDefined(value)){
	    return true;
    }
	return false;
    }


}
