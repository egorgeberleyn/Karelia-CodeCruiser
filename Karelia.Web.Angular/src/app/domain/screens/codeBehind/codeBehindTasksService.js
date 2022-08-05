import { restoreDefaultCanExecute, disableAll } from '../../../services/actions/actionConstructor';
export default class CodeBehindTasksService{
	constructor(
		//--  custom dependencies
		//-- /custom dependencies
		$translate, stringFormat, enumsService, domainManagementService, mainTaskWizardService, subTaskWizardService, wizardManagementService) {
		"ngInject";
		Object.assign(this, {$translate, stringFormat, enumsService, domainManagementService, mainTaskWizardService, subTaskWizardService, wizardManagementService});
    }

	//CreateNew
	mainTaskGridCreateMainTask (declaration, contextState) {
        const options = {
            service: this.mainTaskWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.mainTaskGridCreateMainTaskOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.mainTaskGridCreateMainTaskOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        return this.wizardManagementService.createNew(options);
	}

	mainTaskGridCreateMainTaskOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	mainTaskGridCreateMainTaskOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	mainTaskGridCreateMainTaskPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["mainTaskGrid"]);
	}

	//Edit
	mainTaskGridEditMainTask (declaration, contextState) {
        const options = {
            service: this.mainTaskWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.mainTaskGridEditMainTaskOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.mainTaskGridEditMainTaskOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.mainTaskGrid.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	mainTaskGridEditMainTaskOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	mainTaskGridEditMainTaskOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	mainTaskGridEditMainTaskPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("mainTaskGrid", result);
	}

	mainTaskGridEditMainTaskCanExecute (contextState) {	
	   return contextState.mainTaskGrid && contextState.mainTaskGrid.activeItem;
	}
		
	get mainTaskGridEditMainTaskCanExecuteDependsOn() {
		return ['mainTaskGrid'];
	}
    //Delete
	mainTaskGridDeleteMainTask (declaration, contextState) {

       var keys = [contextState.mainTaskGrid.activeItem.Id];
	   
	   return this.domainManagementService.delete('MainTaskApi', keys);
	}
	mainTaskGridDeleteMainTaskPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["mainTaskGrid"]);
	}

	mainTaskGridDeleteMainTaskCanExecute (contextState) {	
	   return contextState.mainTaskGrid && contextState.mainTaskGrid.activeItem;
	}
		
	get mainTaskGridDeleteMainTaskCanExecuteDependsOn () {
	 return ['mainTaskGrid'];
	}


    //Refresh
	mainTaskGridRefreshMainTask (declaration, contextState) {
	    return contextState.refresh([ 'mainTaskGrid' ]);
	}


	//CreateNew
	subTaskGridCreateSubTask (declaration, contextState) {
        const options = {
            service: this.subTaskWizardService,
            commitOnClose: true,
			onAfterOpen: () => {
				this.subTaskGridCreateSubTaskOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.subTaskGridCreateSubTaskOnBeforeOpen(contextState);
			},
            contextParameters: { 
            }
		};
        options.setContextDefaults = (model) => {
            model.TaskId = contextState.mainTaskGrid.activeItem.Id;
        };
        return this.wizardManagementService.createNew(options);
	}

	subTaskGridCreateSubTaskOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	subTaskGridCreateSubTaskOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}
	subTaskGridCreateSubTaskPostExecute (result, declaration, contextState) {	
        return contextState.refresh(["subTaskGrid"]);
	}
	subTaskGridCreateSubTaskCanExecute (contextState) {	
        return contextState.mainTaskGrid && contextState.mainTaskGrid.activeItem;
	}

	get subTaskGridCreateSubTaskCanExecuteDependsOn (){
        return  ['mainTaskGrid'];
	}

	//Edit
	subTaskGridEditSubTask (declaration, contextState) {
        const options = {
            service: this.subTaskWizardService,
			commitOnClose: true,
			onAfterOpen: () => {
				this.subTaskGridEditSubTaskOnAfterOpen(contextState);
			},
			onBeforeOpen: () => {
				this.subTaskGridEditSubTaskOnBeforeOpen(contextState);
			},
			contextParameters: {
			},
			entityKey: [contextState.subTaskGrid.activeItem.Id]
        }
        return this.wizardManagementService.edit(options);
	}
	subTaskGridEditSubTaskOnAfterOpen (contextState) {	
		restoreDefaultCanExecute(contextState.actions);
	}

	subTaskGridEditSubTaskOnBeforeOpen (contextState) {	
		disableAll(contextState.actions);
	}

	subTaskGridEditSubTaskPostExecute (result, declaration, contextState) {	
		return contextState.refreshItem("subTaskGrid", result);
	}

	subTaskGridEditSubTaskCanExecute (contextState) {	
	   return contextState.subTaskGrid && contextState.subTaskGrid.activeItem;
	}
		
	get subTaskGridEditSubTaskCanExecuteDependsOn() {
		return ['subTaskGrid'];
	}
    //Delete
	subTaskGridDeleteSubTask (declaration, contextState) {

       var keys = [contextState.subTaskGrid.activeItem.Id];
	   
	   return this.domainManagementService.delete('SubTaskApi', keys);
	}
	subTaskGridDeleteSubTaskPostExecute (result, declaration, contextState) {	
		return contextState.refresh(["subTaskGrid"]);
	}

	subTaskGridDeleteSubTaskCanExecute (contextState) {	
	   return contextState.subTaskGrid && contextState.subTaskGrid.activeItem;
	}
		
	get subTaskGridDeleteSubTaskCanExecuteDependsOn () {
	 return ['subTaskGrid'];
	}


    //Refresh
	subTaskGridRefreshSubTask (declaration, contextState) {
	    return contextState.refresh([ 'subTaskGrid' ]);
	}


}
