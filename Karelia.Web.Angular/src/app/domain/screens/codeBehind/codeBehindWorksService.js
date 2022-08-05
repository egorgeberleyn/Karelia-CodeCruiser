import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindWorksService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carServiceWizardService, carWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, carServiceWizardService, carWizardService, domainManagementService, wizardManagementService});
    }

	//CreateNew
	carsCreateCar (declaration, contextState) {
        const options = {
            service: this.carWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carsCreateCarOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carsCreateCarOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	carsCreateCarOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carsCreateCarOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carsCreateCarPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["cars"]);
	}

	//Edit
	carsEditCar (declaration, contextState) {
        const options = {
            service: this.carWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carsEditCarOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carsEditCarOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.cars.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carsEditCarOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carsEditCarOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carsEditCarPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("cars", result);
	}

	carsEditCarCanExecute (contextState) {	
	   return contextState.cars && contextState.cars.activeItem;
	}
		
	get carsEditCarCanExecuteDependsOn() {
		return ['cars'];
	}
    //Delete
	carsDeleteCar (declaration, contextState) {

       var keys = [contextState.cars.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarApi', keys);
	}
	carsDeleteCarPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["cars"]);
	}

	carsDeleteCarCanExecute (contextState) {	
	   return contextState.cars && contextState.cars.activeItem;
	}
		
	get carsDeleteCarCanExecuteDependsOn () {
	 return ['cars'];
	}


    //Refresh
	carsRefreshCar (declaration, contextState) {
	    return contextState.refresh([ 'cars' ]);
	}


	//CreateNew
	servicesCreateService (declaration, contextState) {
        const options = {
            service: this.carServiceWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.servicesCreateServiceOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.servicesCreateServiceOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.CarId = contextState.cars.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	servicesCreateServiceOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	servicesCreateServiceOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	servicesCreateServicePostExecute (result, declaration, contextState) {	
        return contextState.refresh(["services"]);
	}
	servicesCreateServiceCanExecute (contextState) {	
        return contextState.cars && contextState.cars.activeItem;
	}

	get servicesCreateServiceCanExecuteDependsOn (){
        return  ['cars'];
	}

	//Edit
	servicesEditService (declaration, contextState) {
        const options = {
            service: this.carServiceWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.servicesEditServiceOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.servicesEditServiceOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.services.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	servicesEditServiceOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	servicesEditServiceOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	servicesEditServicePostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("services", result);
	}

	servicesEditServiceCanExecute (contextState) {	
	   return contextState.services && contextState.services.activeItem;
	}
		
	get servicesEditServiceCanExecuteDependsOn() {
		return ['services'];
	}
    //Delete
	servicesDeleteService (declaration, contextState) {

       var keys = [contextState.services.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarServiceApi', keys);
	}
	servicesDeleteServicePostExecute (result, declaration, contextState) {	
		return contextState.refresh(["services"]);
	}

	servicesDeleteServiceCanExecute (contextState) {	
	   return contextState.services && contextState.services.activeItem;
	}
		
	get servicesDeleteServiceCanExecuteDependsOn () {
	 return ['services'];
	}


    //Refresh
	servicesRefreshService (declaration, contextState) {
	    return contextState.refresh([ 'services' ]);
	}


}
