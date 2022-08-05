import angular from "angular";
import 'file-saver';
import connectionSettings from './../config/connectionSettings';
import settingsService from './../common/settingsService';

export default class HttpService {
    constructor($http, $state) {
        "ngInject";
        this.http = $http;
        this.state = $state;
    }

    _http(req) {
        return this.http(req).then(result => {
            if (result.status === 403) {
                return this.refreshToken().then(() => {
                    return this.http(req);
                })
            }
            else {
                return new Promise(resolve => {
                    resolve(result);
                });
            }
        }).catch(r => {
            var q = 1;
        });
    }

    _sendModelWithFiles(method, relativeUrl, model) {
        let fd = new FormData(),
            content = {},
            files = {},
            index = 0;
        for (let field in model) {
            if (model[field] instanceof File) {
                files[field] = (model[field]);
                content[field] = {
                    fileName: model[field].name,
                    length: model[field].size,
                    uploadLink: '"ul' + index + '"'
                };
                index++;
            } else {
                content[field] = model[field];
            }
        }
        if (content && Object.keys(content).length > 0)
            fd.append('#data#', angular.toJson(content));
        index = 0;
        for (var file in files) {
            fd.append('ul' + index, files[file]);
            index++;
        }
        const req = {
            method: method,
            url: connectionSettings.baseApiPath + relativeUrl,
            data: fd
        };
        return this._http(req);
    }

    _sendModel(method, relativeUrl, model) {
        return this._sendRequest(false, method, relativeUrl, model);
    }

    _sendRequest(odata, method, relativeUrl, model) {
        const basePath = odata ? connectionSettings.baseApiOdataPath : connectionSettings.baseApiPath,
            path = basePath + relativeUrl,
            req = {
                method: method,
                url: path,
                headers: {
                    'Content-Type': 'application/json'
                }
            };
        if (model) {
            req.data = angular.toJson(model);
        }
        return this._http(req).then(result => {
            return result;
        });
    }

    putModel(relativeUrl, model) {
        return this._sendModel("PUT", relativeUrl + '/' + model.Id, model);
    }

    postModel(relativeUrl, model) {
        return this._sendModel("POST", relativeUrl, model);
    }

    postModelWithFiles(relativeUrl, model) {
        return this._sendModelWithFiles('POST', relativeUrl, model);
    }

    putModelWithFiles(relativeUrl, model) {
        return this._sendModelWithFiles('PUT', relativeUrl, model);
    }

    get(relativeUrl) {
        return this._sendRequest(false, "GET", relativeUrl);
    }

    post(relativeUrl) {
        return this._sendRequest(false, "POST", relativeUrl);
    }

    getOdata(relativeUrl) {
        return this._sendRequest(true, "GET", relativeUrl);
    }

    delete(relativeUrl, id) {
        const req = {
            method: 'DELETE',
            url: connectionSettings.baseApiPath + relativeUrl + '?key=' + this.urlEncodeParameter(id),
            headers: {
                'Content-Type': 'application/json'
            }
        };
        return this._http(req);
    }

    getFileUrl(fileId) {
        return connectionSettings.baseApiPath + 'Files?key=' + fileId;
    }

    downloadFileAsBlob(fileId, progressCallback) {
        const req = {
            method: "GET",
            url: this.getFileUrl(fileId),
            headers: {
                'Content-Type': 'application/json'
            },
            eventHandlers: {
                progress: (e) => {
                    if (progressCallback) {
                        if (e.lengthComputable) {
                            progressCallback.setProgress(e.loaded / e.total)
                        } else {
                            progressCallback.setProgress(-1);
                        }
                    }
                }
            },
            timeout: progressCallback && progressCallback.cancellationToken.promise,
            responseType: 'arraybuffer'
        };
        return this._http(req).then((result) => {
            return new Promise((resolve, reject) => {
                if (progressCallback && progressCallback.canceled()) {
                    reject("Cancelled");
                } else {
                    resolve(new Blob([result.data]));
                }
            });
        });
    }

    downloadFileAsUrl(fileId) {
        return new Promise((resolve, reject) => {
            this.downloadFileAsBlob(fileId).then(blob => {
                const fr = new FileReader();
                fr.onloadend = function () {
                    resolve(fr.result);
                };
                fr.readAsDataURL(blob);
            }).catch(error => {
                reject(error);
            });
        })
    }

    downloadFile(fileId, fileName, progressCallback) {
        return this.downloadFileAsBlob(fileId, progressCallback).then(blob => {
            saveAs(blob, fileName);
            return;
        }).catch(error => {
            console.log(error);
            throw error;
        });
    }

    downloadFileViaLink(fileUrl, name) {
        const a = document.createElement('a');
        a.href = fileUrl;
        a.download = name;
        a.target = '_blank';
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
    }

    getReport(url, model) {
        const req = {
            method: 'POST',
            url: connectionSettings.baseApiPath + url,
            responseType: 'arraybuffer',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
            },
        };
        if (model) {
            const keys = Object.keys(model);
            req.url += '?';
            let first = true;
            for (let key of keys) {
                if (!first) {
                    req.url += '&';
                }
                req.url += `${encodeURIComponent(key)}=${encodeURIComponent(model[key])}`;
                first = false;
            }
        }
        return this._http(req).then(result => {
            return {
                fileName: result.headers('fullfilename'),
                data: result.data
            }
        });
    }

    getToken(login, password) {
        const data = `grant_type=password&username=${login}&password=${password}&client_id=${settingsService.getClientId()}`;
        return this.http.post(connectionSettings.baseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
    }

    refreshToken() {
        const userInfo = settingsService.getUserInformation();
        if (!userInfo.refreshToken || userInfo.refreshToken === undefined) {
            return this.state.go('login');
        }
        const url = connectionSettings.baseUrl + 'token';
        const body = `grant_type=refresh_token&refresh_token=${userInfo.refreshToken}&client_id=${settingsService.getClientId()}`;
        const headers = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };
        return this.http.post(url, body, { headers }).then(result => {
            if (result.status === 200) {
                const { access_token, refresh_token, expires_in } = result.data;
                settingsService.saveUserInformation(userInfo.userName, access_token, refresh_token, expires_in);
                return new Promise(resolve => {
                    resolve();
                });
            } else {
                if (userInfo.token === settingsService.getUserInformation().token) {
                    return this.state.go('login');
                } else {
                    return new Promise(resolve => {
                        resolve();
                    });
                }
            }
        });
    }

    authorizationCode(code) {
        const data = `grant_type=authorization_code&code=${code}&client_id=${settingsService.getClientId()}`;
        return this.http.post(connectionSettings.baseUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } });
    }

    registerUser(email, username, password, confirmPassword) {
        return this.postModel('register', {
            userName: username,
            email: email,
            password: password,
            confirmPassword: confirmPassword
        });
    }

    urlEncodeParameter(parameter) {
        if (typeof (parameter) !== 'object')
            return parameter;

        if (Array.isArray(parameter))
            return this.urlEncodeParameter(parameter[0]);

        let encoded = '';
        JSON.stringify(parameter).split('').map(c => c.charCodeAt(0)).forEach(function (charCode) {
            encoded +=
                (charCode & 0xFF).toString(16).padStart(2, '0') +
                (charCode >>> 8).toString(16).padStart(2, '0');
        })

        return encoded;
    }
}
