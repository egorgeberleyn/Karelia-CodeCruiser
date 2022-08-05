import { ActionStatus } from "./actionEnums";

export function wrapAction(method, messageBoxService) {
    return method()
        .then(result => {
            if (result.data) {
                if (result.data.Type === ActionStatus.FAIL) {
                    return messageBoxService.showMessage('', result.data.Message).then(() => {
												if (result.data.Details) {
													console.error(result.data.Details);
 												}
                        return result;
                    });
                } else if (result.data.Type === ActionStatus.SUCCESS) {
                    if (result.data.Message) {
                        return messageBoxService.showMessage('', result.data.Message).then(() => {
                            return result;
                        });
                    }
                }
            }
            return result;
        });
}

