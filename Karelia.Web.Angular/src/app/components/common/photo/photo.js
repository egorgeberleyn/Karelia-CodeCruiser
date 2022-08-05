import template from './photo.html';
class PhotoController {
    constructor(httpService) {
        'ngInject';
        this.httpService = httpService;
    }

    $onInit(){
        if (this.id || this.fileLink || this.data) {
            this._loadPhoto();
        }
    }

    _loadPhoto(){
        if (this.data) {
            this.photo = this.data;
        } else if (this.id || (this.fileLink && this.fileLink.Id)) {
            this.httpService.downloadFileAsUrl(this.id || this.fileLink.Id).then(photo => {
                this.photo = photo;
                this.loading = false;
            });
        }
    }

    $onChanges(changesObj){
        if (changesObj.id || changesObj.fileLink || changesObj.data) {
            this._loadPhoto();
        }
    }
}

export default {
    template: template,
    bindings: {
        id: '=?',
        fileLink: '=?',
        data: '@?'
    },
    controller: PhotoController
}

/*
angular.module('acsys').directive('photo', ($compile) => {
    'ngInject';

    return {
        templateUrl: "app/components/photo/photo.html",
        transclude: true,
        replace: true,
        scope: {
            id: "=",
            defaultPhoto: "@"
        },
        link(scope, element, attrs, ctrl, transclude) {
            return element.find('.replace-transclude').replaceWith($compile(transclude())(scope));
        },
        controller: PhotoController
    };
});*/
