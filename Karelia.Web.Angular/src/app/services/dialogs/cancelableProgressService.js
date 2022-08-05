export default class CancelableProgressService {
    constructor(services, $q, $translate) {
        "ngInject"
        this.modalWindowService = services.modalWindowService;
        this.$q = $q;
        this.translate = $translate;
    }

    show() {
        const cancelButtonText = this.translate.instant('confirmation_cancel_button_text');
        const cancellationToken = this.$q.defer();
        let canceled = false;
        const progress = {
            cancel() {
                cancellationToken.resolve("Canceled");
                canceled = true;
            }
        };
        const options = {
            template: `<cancelable-progress progress="progress" 
                        cancel-text='${cancelButtonText}'>
                        </cancelable-progress>`,
            title: "",
            actions: [],
            width: "600px",
            locals: {
                progress
            }
        };

        const window = this.modalWindowService.show(options);

        return {
            setProgress(value) {
                progress.setProgress(value);
            },
            setCaption(caption) {
                progress.setCaption(caption);
            },
            cancellationToken,
            canceled() {
                return canceled;
            },
            close() {
                window.hide();
            }
        }
    }
}