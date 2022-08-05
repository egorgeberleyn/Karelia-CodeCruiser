export default class WizardSaveService {
    constructor(httpService) {
        "ngInject";
        this.httpService = httpService;
    }

    save(model, controller) {
        let method = model.Id ? "putModel" : "postModel";
        const keys = Object.keys(model);
        for (let i = 0; i < keys.length; i++) {
            const key = keys[i];
            if (model[key] instanceof File) {
                method += 'WithFiles';
                break;
            }
        }
        return this.httpService[method](controller, model)
            .then(response => {
                if (response.status >= 400) {
                    throw response;
                } else {
                    return response;
                }
            });
    }
}
