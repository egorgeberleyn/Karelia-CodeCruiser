export default class DownloadHelpers {
    constructor(httpService, $window) {
        'ngInject';
        this.httpService = httpService;
        this.$window = $window;
    }

    downloadFileAsBase64(base64Data, name) {
        const byteCharacters = this.$window.atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray]);
        const blobUrl = this.$window.URL.createObjectURL(blob);

        this.httpService.downloadFile(blobUrl, name);
    }

    downloadFileAsFileObject(file, name) {
        const blobUrl = this.$window.URL.createObjectURL(file);
        this.httpService.downloadFile(blobUrl, name);
    }
}
