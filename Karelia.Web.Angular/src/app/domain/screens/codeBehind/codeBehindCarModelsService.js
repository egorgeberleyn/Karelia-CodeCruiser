import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindCarModelsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, carModelPartWizardService, carModelWizardService, domainManagementService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, carModelPartWizardService, carModelWizardService, domainManagementService, wizardManagementService});
    }

	//CreateNew
	carModelsCreateCarModel (declaration, contextState) {
        const options = {
            service: this.carModelWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carModelsCreateCarModelOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carModelsCreateCarModelOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	carModelsCreateCarModelOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carModelsCreateCarModelOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carModelsCreateCarModelPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carModels"]);
	}

	//Edit
	carModelsEditCarModel (declaration, contextState) {
        const options = {
            service: this.carModelWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carModelsEditCarModelOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carModelsEditCarModelOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carModels.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carModelsEditCarModelOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carModelsEditCarModelOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carModelsEditCarModelPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carModels", result);
	}

	carModelsEditCarModelCanExecute (contextState) {	
	   return contextState.carModels && contextState.carModels.activeItem;
	}
		
	get carModelsEditCarModelCanExecuteDependsOn() {
		return ['carModels'];
	}
    //Delete
	carModelsDeleteCarModel (declaration, contextState) {

       var keys = [contextState.carModels.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarModelApi', keys);
	}
	carModelsDeleteCarModelPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carModels"]);
	}

	carModelsDeleteCarModelCanExecute (contextState) {	
	   return contextState.carModels && contextState.carModels.activeItem;
	}
		
	get carModelsDeleteCarModelCanExecuteDependsOn () {
	 return ['carModels'];
	}


    //Refresh
	carModelsRefreshCarModel (declaration, contextState) {
	    return contextState.refresh([ 'carModels' ]);
	}


	//CreateNew
	carModelPartCreateCarModelPart (declaration, contextState) {
        const options = {
            service: this.carModelPartWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.carModelPartCreateCarModelPartOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carModelPartCreateCarModelPartOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.CarModelId = contextState.carModels.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	carModelPartCreateCarModelPartOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carModelPartCreateCarModelPartOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	carModelPartCreateCarModelPartPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["carModelPart"]);
	}
	carModelPartCreateCarModelPartCanExecute (contextState) {	
        return contextState.carModels && contextState.carModels.activeItem;
	}

	get carModelPartCreateCarModelPartCanExecuteDependsOn (){
        return  ['carModels'];
	}

	//Edit
	carModelPartEditCarModelPart (declaration, contextState) {
        const options = {
            service: this.carModelPartWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.carModelPartEditCarModelPartOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.carModelPartEditCarModelPartOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.carModelPart.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	carModelPartEditCarModelPartOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	carModelPartEditCarModelPartOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	carModelPartEditCarModelPartPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("carModelPart", result);
	}

	carModelPartEditCarModelPartCanExecute (contextState) {	
	   return contextState.carModelPart && contextState.carModelPart.activeItem;
	}
		
	get carModelPartEditCarModelPartCanExecuteDependsOn() {
		return ['carModelPart'];
	}
    //Delete
	carModelPartDeleteCarModelPart (declaration, contextState) {

       var keys = [contextState.carModelPart.activeItem.Id];
	   
	   return this.domainManagementService.delete('CarModelPartApi', keys);
	}
	carModelPartDeleteCarModelPartPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["carModelPart"]);
	}

	carModelPartDeleteCarModelPartCanExecute (contextState) {	
	   return contextState.carModelPart && contextState.carModelPart.activeItem;
	}
		
	get carModelPartDeleteCarModelPartCanExecuteDependsOn () {
	 return ['carModelPart'];
	}


    //Refresh
	carModelPartRefreshCarModelPart (declaration, contextState) {
	    return contextState.refresh([ 'carModelPart' ]);
	}


}
