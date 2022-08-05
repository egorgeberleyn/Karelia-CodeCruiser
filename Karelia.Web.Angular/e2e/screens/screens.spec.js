describe('Screens', function() {
    var screens = browser.params.testConfig.screens;
    for (var screen in screens) {
        (function (screenName, text) {
            it('Menu item: ' + text, function () {
                browser.get("#!/app/" + screenName);
                browser.waitForAngular();
            });
        })(screen, screens[screen].displayName);
    }
});
