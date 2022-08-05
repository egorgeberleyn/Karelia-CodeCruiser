import {ActionStatus} from "./actionEnums";

export default class ServerErrorProcessor {
    constructor(messageBoxService) {
        "ngInject";
        this.messageBoxService = messageBoxService;
    }
    process(actionPromise) {
        return actionPromise.then((result) => {
					if (result && result.data && result.data.Type === ActionStatus.FAIL) {
						const message = result.data.Message;
						const details = result.data.Details;
						if (message) {
							return this.messageBoxService.showMessage('', message).then(() => {
									if (details) {
										console.error(details);
									}								
							    result.showed = true;
								throw result;
						});	
					}
				}
				return result;
				}).catch(error => {
            let message;
            let details;
            if (error && error.message) {
                message = error.message;
                details = error.stack;
            } else if (error && error.data) {
                message = error.data.Message;
            }
            if (message && !error.showed)
                return this.messageBoxService.showMessage('', message).then(() => {
									if (details) {
										console.error(details);
									}
									throw error;
                });
            throw error;
        });
    }
	}
