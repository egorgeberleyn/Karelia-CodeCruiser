import valueFormatter from "../formatters/valueFormatter";
import { afterLoginInit, init } from "./../../domain/customStartUpInit"

export default class StartUpInitService {
    constructor(kendoThemeService, languageService, checkServerVersionService, runtimeStates, services) {
        "ngInject";
        this.kendoThemeService = kendoThemeService;
        this.languageService = languageService;
        this.checkServerVersionService = checkServerVersionService;
        this.runtimeStates = runtimeStates;
        this.httpService = services.httpService;
        this.services = services;
    }

    init() {
        this.kendoThemeService.loadDefaultTheme();
        return this.languageService.init()
            .then(() => {
                this.checkServerVersionService.init()
                    .then(() => {
                        return init(this.services);
                    })
            })
    }

    afterLoginInit() {
        return Promise.all([valueFormatter.init(this.httpService), this.runtimeStates.fillStates()])
            .then(() => {
                return afterLoginInit(this.services);
            });
    }
}
