import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindModelEquipmentsService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, officeEquipmentModelWizardService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, domainManagementService, officeEquipmentModelWizardService, wizardManagementService});
    }

	//CreateNew
	modelEquipmentGridCreateEquipmentModel (declaration, contextState) {
        const options = {
            service: this.officeEquipmentModelWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.modelEquipmentGridCreateEquipmentModelOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.modelEquipmentGridCreateEquipmentModelOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	modelEquipmentGridCreateEquipmentModelOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	modelEquipmentGridCreateEquipmentModelOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	modelEquipmentGridCreateEquipmentModelPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["modelEquipmentGrid"]);
	}

	//Edit
	modelEquipmentGridEditEquipmentModel (declaration, contextState) {
        const options = {
            service: this.officeEquipmentModelWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.modelEquipmentGridEditEquipmentModelOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.modelEquipmentGridEditEquipmentModelOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.modelEquipmentGrid.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	modelEquipmentGridEditEquipmentModelOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	modelEquipmentGridEditEquipmentModelOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	modelEquipmentGridEditEquipmentModelPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("modelEquipmentGrid", result);
	}

	modelEquipmentGridEditEquipmentModelCanExecute (contextState) {	
	   return contextState.modelEquipmentGrid && contextState.modelEquipmentGrid.activeItem;
	}
		
	get modelEquipmentGridEditEquipmentModelCanExecuteDependsOn() {
		return ['modelEquipmentGrid'];
	}
    //Delete
	modelEquipmentGridDeleteEquipmentModel (declaration, contextState) {

       var keys = [contextState.modelEquipmentGrid.activeItem.Id];
	   
	   return this.domainManagementService.delete('OfficeEquipmentModelApi', keys);
	}
	modelEquipmentGridDeleteEquipmentModelPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["modelEquipmentGrid"]);
	}

	modelEquipmentGridDeleteEquipmentModelCanExecute (contextState) {	
	   return contextState.modelEquipmentGrid && contextState.modelEquipmentGrid.activeItem;
	}
		
	get modelEquipmentGridDeleteEquipmentModelCanExecuteDependsOn () {
	 return ['modelEquipmentGrid'];
	}


    //Refresh
	modelEquipmentGridRefreshEquipmentModel (declaration, contextState) {
	    return contextState.refresh([ 'modelEquipmentGrid' ]);
	}


}
