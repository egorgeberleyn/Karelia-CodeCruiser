import angular from "angular"

import template from "./wizardFileupload.html"
import "./wizardFileupload.scss"
import dataTypeHelperService from './../../../../services/helpers/dataTypeHelperService'
import { getFileExtension } from "../../../../services/helpers/pathHelper";
import { BaseWizardElement, getWizardElementDeclaration } from "../base/baseWizardElement";

class WizardFileuploadController extends BaseWizardElement{
    constructor($element, $timeout, $scope, $compile, $translate, httpService, $window, downloadHelpers) {
        "ngInject";
        super();
        this.$window = $window;
        this.httpService = httpService;
        this.$compile = $compile;
        this.$scope = $scope;
        this.$translate = $translate;
        this.$element = $element;
        this.$timeout = $timeout;
        this.downloadHelpers = downloadHelpers;
        this.preview = $element.find('.file-upload-preview-image');
    }

    addFileLink(){
        const fileNameSpan = this.$element.find('.k-file-name');
        const text = fileNameSpan.text();
        if (text) {
            fileNameSpan.html("");
            this.$compile(angular.element(`<a href="" ng-click="$ctrl.fileLinkClicked()">${text}</a>`))(this.$scope).appendTo(fileNameSpan);
        }
    }

    hidePreview(){
        if (this.field.type === 'picture') {
            this.preview.hide();
        }
    }

    onSelected(e) {
        const field = this.field;
        if (field.type === 'picture') {
            const fileReader = new FileReader();
            fileReader.onload = (event) => {
                const mapImage = event.target.result;
                const base64 = this.$window.btoa(mapImage);
                this.preview.attr('src', `data:image;base64,${base64}`);
                if (this.isBinary()) {
                    this.model[field.name] = base64;
                }
                this.preview.show();
            };
            fileReader.readAsBinaryString(e.files[0].rawFile);
            if (!this.isBinary()) {
                this.model[field.name] = e.files[0].rawFile;
            }
        }
    }

    isBinary() {
        return dataTypeHelperService.isBinary(this.field.dataType);
    }

    fileLinkClicked(){
        const model = this.model[this.field.name];
        if (this.model[this.field.name] instanceof File) {
            const file = this.model[this.field.name];
            this.downloadHelpers.downloadFileAsFileObject(file, file.name);
        } else if (this.isBinary()) {
            this.downloadHelpers.downloadFileAsBase64(this.model[this.field.name], this.files[0].name);
        }  else {
            this.httpService.downloadFile(model.Id, model.FileName);
        }
    }

    onInitValue() {
        const field = this.field;
        const model = this.model[field.name];
        if (this.isBinary()) {
            this.files = [{
                name: this.$translate.instant('wizard_file_upload_download'),
                size: model.length,
                extension: ''
            }];
            this.preview.attr('src', "data:image;base64," + encodeURIComponent(model));
        } else {
            this.files = [{
                name: model.FileName,
                size: model.Length,
                extension: getFileExtension(model.FileName)
            }];
            this.httpService.downloadFileAsUrl(model.Id).then((body) => {
                this.preview.attr('src', body);
            });
        }
    }

    $onInit() {
        this.init();
        if (this.model[this.field.name]) {
            this.onInitValue(this);
        }
        const upload = this.$element.find('input');
        upload.kendoUpload({
            multiple: true,
            files: this.files,
            async: {
                saveUrl: "Save",
                removeUrl: "Remove",
                autoUpload: false
            },
            remove: (e) => {
                e.sender.clearAllFiles();
                this.model[this.field.name] = null;
                this.hidePreview(this);
            },
            select: (e) => {
                if (e.files && e.files.length > 0) {
                    this.hidePreview(this);
                    e.sender.clearAllFiles();
                    e.sender.wrapper.hide();
                    this.model[this.field.name] = e.files[0].rawFile;
                    this.onSelected(e);
                    this.$timeout(() => {
                        e.sender.wrapper.hide();
                        e.sender.wrapper.find(".k-clear-selected").hide();
                        e.sender.wrapper.find(".k-upload-selected").hide();
                        this.addFileLink();
                        e.sender.wrapper.show();
                    });
                }
            }
        });

        if (this.field.readonly) {
            upload.data("kendoUpload").enable(false);
            upload.on('drop', function (event) {
                event.preventDefault();
            });
        }

        this.addFileLink();
    }
}
export default getWizardElementDeclaration(template, WizardFileuploadController);


