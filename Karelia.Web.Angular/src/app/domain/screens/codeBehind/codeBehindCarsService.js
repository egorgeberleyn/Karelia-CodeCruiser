import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindCarsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carServicePartWizardService, carServiceWizardService, carServiceWorkWizardService, carWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, carServicePartWizardService, carServiceWizardService, carServiceWorkWizardService, carWizardService, domainManagementService, wizardManagementService});
    }

	//CreateNew
	carsGridBlockCreateCar (declaration, contextState) {
        const options = {
            service: this.carWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carsGridBlockCreateCarOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carsGridBlockCreateCarOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	carsGridBlockCreateCarOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carsGridBlockCreateCarOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carsGridBlockCreateCarPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carsGridBlock"]);
	}

	//Edit
	carsGridBlockEditCar (declaration, contextState) {
        const options = {
            service: this.carWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carsGridBlockEditCarOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carsGridBlockEditCarOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carsGridBlock.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carsGridBlockEditCarOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carsGridBlockEditCarOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carsGridBlockEditCarPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carsGridBlock", result);
	}

	carsGridBlockEditCarCanExecute (contextState) {	
	   return contextState.carsGridBlock && contextState.carsGridBlock.activeItem;
	}
		
	get carsGridBlockEditCarCanExecuteDependsOn() {
		return ['carsGridBlock'];
	}
    //Delete
	carsGridBlockDeleteCar (declaration, contextState) {

       var keys = [contextState.carsGridBlock.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarApi', keys);
	}
	carsGridBlockDeleteCarPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carsGridBlock"]);
	}

	carsGridBlockDeleteCarCanExecute (contextState) {	
	   return contextState.carsGridBlock && contextState.carsGridBlock.activeItem;
	}
		
	get carsGridBlockDeleteCarCanExecuteDependsOn () {
	 return ['carsGridBlock'];
	}


    //Refresh
	carsGridBlockRefreshCar (declaration, contextState) {
	    return contextState.refresh([ 'carsGridBlock' ]);
	}


	//CreateNew
	carServiceDataGridCreateCarService (declaration, contextState) {
        const options = {
            service: this.carServiceWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carServiceDataGridCreateCarServiceOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServiceDataGridCreateCarServiceOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.CarId = contextState.carsGridBlock.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	carServiceDataGridCreateCarServiceOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServiceDataGridCreateCarServiceOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carServiceDataGridCreateCarServicePostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carServiceDataGrid"]);
	}
	carServiceDataGridCreateCarServiceCanExecute (contextState) {	
        return contextState.carsGridBlock && contextState.carsGridBlock.activeItem;
	}

	get carServiceDataGridCreateCarServiceCanExecuteDependsOn (){
        return  ['carsGridBlock'];
	}

	//Edit
	carServiceDataGridEditCarService (declaration, contextState) {
        const options = {
            service: this.carServiceWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carServiceDataGridEditCarServiceOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServiceDataGridEditCarServiceOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carServiceDataGrid.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carServiceDataGridEditCarServiceOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServiceDataGridEditCarServiceOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carServiceDataGridEditCarServicePostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carServiceDataGrid", result);
	}

	carServiceDataGridEditCarServiceCanExecute (contextState) {	
	   return contextState.carServiceDataGrid && contextState.carServiceDataGrid.activeItem;
	}
		
	get carServiceDataGridEditCarServiceCanExecuteDependsOn() {
		return ['carServiceDataGrid'];
	}
    //Delete
	carServiceDataGridDeleteCarService (declaration, contextState) {

       var keys = [contextState.carServiceDataGrid.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarServiceApi', keys);
	}
	carServiceDataGridDeleteCarServicePostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carServiceDataGrid"]);
	}

	carServiceDataGridDeleteCarServiceCanExecute (contextState) {	
	   return contextState.carServiceDataGrid && contextState.carServiceDataGrid.activeItem;
	}
		
	get carServiceDataGridDeleteCarServiceCanExecuteDependsOn () {
	 return ['carServiceDataGrid'];
	}


    //Refresh
	carServiceDataGridRefreshCarService (declaration, contextState) {
	    return contextState.refresh([ 'carServiceDataGrid' ]);
	}


	//CreateNew
	carServicePartCreateCarServicePart (declaration, contextState) {
        const options = {
            service: this.carServicePartWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carServicePartCreateCarServicePartOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServicePartCreateCarServicePartOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.CarServiceId = contextState.carServiceDataGrid.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	carServicePartCreateCarServicePartOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServicePartCreateCarServicePartOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carServicePartCreateCarServicePartPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carServicePart"]);
	}
	carServicePartCreateCarServicePartCanExecute (contextState) {	
        return contextState.carServiceDataGrid && contextState.carServiceDataGrid.activeItem;
	}

	get carServicePartCreateCarServicePartCanExecuteDependsOn (){
        return  ['carServiceDataGrid'];
	}

	//Edit
	carServicePartEditCarServicePart (declaration, contextState) {
        const options = {
            service: this.carServicePartWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carServicePartEditCarServicePartOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServicePartEditCarServicePartOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carServicePart.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carServicePartEditCarServicePartOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServicePartEditCarServicePartOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carServicePartEditCarServicePartPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carServicePart", result);
	}

	carServicePartEditCarServicePartCanExecute (contextState) {	
	   return contextState.carServicePart && contextState.carServicePart.activeItem;
	}
		
	get carServicePartEditCarServicePartCanExecuteDependsOn() {
		return ['carServicePart'];
	}
    //Delete
	carServicePartDeleteCarServicePart (declaration, contextState) {

       var keys = [contextState.carServicePart.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarServicePartApi', keys);
	}
	carServicePartDeleteCarServicePartPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carServicePart"]);
	}

	carServicePartDeleteCarServicePartCanExecute (contextState) {	
	   return contextState.carServicePart && contextState.carServicePart.activeItem;
	}
		
	get carServicePartDeleteCarServicePartCanExecuteDependsOn () {
	 return ['carServicePart'];
	}


    //Refresh
	carServicePartRefreshCarServicePart (declaration, contextState) {
	    return contextState.refresh([ 'carServicePart' ]);
	}


	//CreateNew
	carServiceWorkCreateCarServiceWork (declaration, contextState) {
        const options = {
            service: this.carServiceWorkWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carServiceWorkCreateCarServiceWorkOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServiceWorkCreateCarServiceWorkOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.CarServiceId = contextState.carServiceDataGrid.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	carServiceWorkCreateCarServiceWorkOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServiceWorkCreateCarServiceWorkOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carServiceWorkCreateCarServiceWorkPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carServiceWork"]);
	}
	carServiceWorkCreateCarServiceWorkCanExecute (contextState) {	
        return contextState.carServiceDataGrid && contextState.carServiceDataGrid.activeItem;
	}

	get carServiceWorkCreateCarServiceWorkCanExecuteDependsOn (){
        return  ['carServiceDataGrid'];
	}

	//Edit
	carServiceWorkEditCarServiceWork (declaration, contextState) {
        const options = {
            service: this.carServiceWorkWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carServiceWorkEditCarServiceWorkOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carServiceWorkEditCarServiceWorkOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carServiceWork.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carServiceWorkEditCarServiceWorkOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carServiceWorkEditCarServiceWorkOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carServiceWorkEditCarServiceWorkPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carServiceWork", result);
	}

	carServiceWorkEditCarServiceWorkCanExecute (contextState) {	
	   return contextState.carServiceWork && contextState.carServiceWork.activeItem;
	}
		
	get carServiceWorkEditCarServiceWorkCanExecuteDependsOn() {
		return ['carServiceWork'];
	}
    //Delete
	carServiceWorkDeleteCarServiceWork (declaration, contextState) {

       var keys = [contextState.carServiceWork.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarServiceWorkApi', keys);
	}
	carServiceWorkDeleteCarServiceWorkPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carServiceWork"]);
	}

	carServiceWorkDeleteCarServiceWorkCanExecute (contextState) {	
	   return contextState.carServiceWork && contextState.carServiceWork.activeItem;
	}
		
	get carServiceWorkDeleteCarServiceWorkCanExecuteDependsOn () {
	 return ['carServiceWork'];
	}


    //Refresh
	carServiceWorkRefreshCarServiceWork (declaration, contextState) {
	    return contextState.refresh([ 'carServiceWork' ]);
	}


}
