import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindOfficeService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, officeEmployeeWizardService, officeEquipmentWizardService, officeWizardService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, domainManagementService, officeEmployeeWizardService, officeEquipmentWizardService, officeWizardService, wizardManagementService});
    }

	//CreateNew
	officeDataGridCreateAdress (declaration, contextState) {
        const options = {
            service: this.officeWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.officeDataGridCreateAdressOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeDataGridCreateAdressOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	officeDataGridCreateAdressOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeDataGridCreateAdressOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	officeDataGridCreateAdressPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["officeDataGrid"]);
	}

	//Edit
	officeDataGridEditAdress (declaration, contextState) {
        const options = {
            service: this.officeWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.officeDataGridEditAdressOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeDataGridEditAdressOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.officeDataGrid.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	officeDataGridEditAdressOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeDataGridEditAdressOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	officeDataGridEditAdressPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("officeDataGrid", result);
	}

	officeDataGridEditAdressCanExecute (contextState) {	
	   return contextState.officeDataGrid && contextState.officeDataGrid.activeItem;
	}
		
	get officeDataGridEditAdressCanExecuteDependsOn() {
		return ['officeDataGrid'];
	}
    //Delete
	officeDataGridDeleteAdress (declaration, contextState) {

       var keys = [contextState.officeDataGrid.activeItem.Id];
	   
	   return this.domainManagementService.delete('OfficeApi', keys);
	}
	officeDataGridDeleteAdressPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["officeDataGrid"]);
	}

	officeDataGridDeleteAdressCanExecute (contextState) {	
	   return contextState.officeDataGrid && contextState.officeDataGrid.activeItem;
	}
		
	get officeDataGridDeleteAdressCanExecuteDependsOn () {
	 return ['officeDataGrid'];
	}


    //Refresh
	officeDataGridRefreshAdress (declaration, contextState) {
	    return contextState.refresh([ 'officeDataGrid' ]);
	}


	//CreateNew
	officeEquipmentGridBlockCreateOfficeEquipment (declaration, contextState) {
        const options = {
            service: this.officeEquipmentWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.officeEquipmentGridBlockCreateOfficeEquipmentOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeEquipmentGridBlockCreateOfficeEquipmentOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.OfficeId = contextState.officeDataGrid.activeItem.Id;
            model.OfficeEmployeeId = contextState.officeEmployees.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	officeEquipmentGridBlockCreateOfficeEquipmentOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeEquipmentGridBlockCreateOfficeEquipmentOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	officeEquipmentGridBlockCreateOfficeEquipmentPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["officeEquipmentGridBlock"]);
	}
	officeEquipmentGridBlockCreateOfficeEquipmentCanExecute (contextState) {	
        return contextState.officeDataGrid && contextState.officeDataGrid.activeItem && contextState.officeEmployees && contextState.officeEmployees.activeItem;
	}

	get officeEquipmentGridBlockCreateOfficeEquipmentCanExecuteDependsOn (){
        return  ['officeDataGrid', 'officeEmployees'];
	}

	//Edit
	officeEquipmentGridBlockEditOfficeEquipment (declaration, contextState) {
        const options = {
            service: this.officeEquipmentWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.officeEquipmentGridBlockEditOfficeEquipmentOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeEquipmentGridBlockEditOfficeEquipmentOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.officeEquipmentGridBlock.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	officeEquipmentGridBlockEditOfficeEquipmentOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeEquipmentGridBlockEditOfficeEquipmentOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	officeEquipmentGridBlockEditOfficeEquipmentPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("officeEquipmentGridBlock", result);
	}

	officeEquipmentGridBlockEditOfficeEquipmentCanExecute (contextState) {	
	   return contextState.officeEquipmentGridBlock && contextState.officeEquipmentGridBlock.activeItem;
	}
		
	get officeEquipmentGridBlockEditOfficeEquipmentCanExecuteDependsOn() {
		return ['officeEquipmentGridBlock'];
	}
    //Delete
	officeEquipmentGridBlockDeleteOfficeEquipment (declaration, contextState) {

       var keys = [contextState.officeEquipmentGridBlock.activeItem.Id];
	   
	   return this.domainManagementService.delete('OfficeEquipmentApi', keys);
	}
	officeEquipmentGridBlockDeleteOfficeEquipmentPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["officeEquipmentGridBlock"]);
	}

	officeEquipmentGridBlockDeleteOfficeEquipmentCanExecute (contextState) {	
	   return contextState.officeEquipmentGridBlock && contextState.officeEquipmentGridBlock.activeItem;
	}
		
	get officeEquipmentGridBlockDeleteOfficeEquipmentCanExecuteDependsOn () {
	 return ['officeEquipmentGridBlock'];
	}


    //Refresh
	officeEquipmentGridBlockRefreshOfficeEquipment (declaration, contextState) {
	    return contextState.refresh([ 'officeEquipmentGridBlock' ]);
	}


	//CreateNew
	officeEmployeesCreateOfficeEmployee (declaration, contextState) {
        const options = {
            service: this.officeEmployeeWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.officeEmployeesCreateOfficeEmployeeOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeEmployeesCreateOfficeEmployeeOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.OfficeId = contextState.officeDataGrid.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	officeEmployeesCreateOfficeEmployeeOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeEmployeesCreateOfficeEmployeeOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	officeEmployeesCreateOfficeEmployeePostExecute (result, declaration, contextState) {	
        return contextState.refresh(["officeEmployees"]);
	}
	officeEmployeesCreateOfficeEmployeeCanExecute (contextState) {	
        return contextState.officeDataGrid && contextState.officeDataGrid.activeItem;
	}

	get officeEmployeesCreateOfficeEmployeeCanExecuteDependsOn (){
        return  ['officeDataGrid'];
	}

	//Edit
	officeEmployeesEditOfficeEmployee (declaration, contextState) {
        const options = {
            service: this.officeEmployeeWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.officeEmployeesEditOfficeEmployeeOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.officeEmployeesEditOfficeEmployeeOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.officeEmployees.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	officeEmployeesEditOfficeEmployeeOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	officeEmployeesEditOfficeEmployeeOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	officeEmployeesEditOfficeEmployeePostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("officeEmployees", result);
	}

	officeEmployeesEditOfficeEmployeeCanExecute (contextState) {	
	   return contextState.officeEmployees && contextState.officeEmployees.activeItem;
	}
		
	get officeEmployeesEditOfficeEmployeeCanExecuteDependsOn() {
		return ['officeEmployees'];
	}
    //Delete
	officeEmployeesDeleteOfficeEmployee (declaration, contextState) {

       var keys = [contextState.officeEmployees.activeItem.Id];
	   
	   return this.domainManagementService.delete('OfiiceEmployeeApi', keys);
	}
	officeEmployeesDeleteOfficeEmployeePostExecute (result, declaration, contextState) {	
		return contextState.refresh(["officeEmployees"]);
	}

	officeEmployeesDeleteOfficeEmployeeCanExecute (contextState) {	
	   return contextState.officeEmployees && contextState.officeEmployees.activeItem;
	}
		
	get officeEmployeesDeleteOfficeEmployeeCanExecuteDependsOn () {
	 return ['officeEmployees'];
	}


    //Refresh
	officeEmployeesRefreshOfficeEmployee (declaration, contextState) {
	    return contextState.refresh([ 'officeEmployees' ]);
	}


}
