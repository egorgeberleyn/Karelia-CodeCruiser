const testPathFolder = 'e2e';
const testConfig = require(`./${testPathFolder}/screenTestsMetadata.json`);
const Jasmine2HtmlReporter = require('protractor-jasmine2-html-reporter');

exports.config = {
  capabilities: {
    'browserName': 'chrome'
  },

  framework: 'jasmine2',

  specs: [`${testPathFolder}/**/*.js`],

  jasmineNodeOpts: {
    showColors: true,
    defaultTimeoutInterval: 30000
  },

  params: {
    stateCount: null,
    captions: []
  },

  plugins: [{
    package: 'protractor-console-plugin',
    failOnWarning: false,
    failOnError: true,
    logWarnings: true
  }],

  rootElement: '[ng-app="app"]',

  onPrepare: function () {
    if (this.process.env.URL) {
      browser.baseUrl = this.process.env.URL;
    }
    browser.get('index.html#/welcome');
    element(by.model('$ctrl.model.name')).sendKeys('Admin');
    element(by.model('$ctrl.model.password')).sendKeys('cc');
    element(by.css('.k-primary')).click();

    jasmine.getEnv().addReporter(
      new Jasmine2HtmlReporter({
        savePath: 'testresults/',
        filePrefix: 'testresults_' + new Date().getTime().toString(),
        takeScreenshots: true,
        takeScreenshotsOnlyOnFailures: true
      })
    );

    browser.params.testConfig = testConfig;
    return element(by.tagName("main-layout")).isPresent();
  },

  onCompelete: function () {
    browser.executeScript('window.localStorage.clear();');
  }
}
