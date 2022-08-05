import template from "./wizard-navigation-buttons.html"
class WizardNavigationButtonsController{
    finishVisible() {
        if (this.alwaysShowFinishButton) {
            return true;
        }
        if (this.state.selectedSection) {
            for (var i = this.state.menuLinkStates.length - 1; i >= 0; i--) {
                if (this.state.menuLinkStates[i].visible) {
                    return this.state.selectedSection.index === i;
                }
            }
        }
        return false;
    }

    finishDisabled() {
        if (this.state.selectedSection) {
            return this.state.menuLinkStates[this.state.selectedSection.index].finishDisable || this.state.saving;
        }
    }
    backVisible() {
        if (this.state.selectedSection) {
            for (let i = this.state.selectedSection.index - 1; i >= 0; i--) {
                if (this.state.menuLinkStates[i].visible) {
                    return true;
                }
            }
        }
    }
    nextVisible() {
        if (this.state.selectedSection) {
            for (let i = this.state.selectedSection.index + 1; i < this.state.menuLinkStates.length; i++) {
                if (this.state.menuLinkStates[i].visible) {
                    return true;
                }
            }
        }
        return false;
    }
    nextDisabled() {
        if (this.state.selectedSection) {
            for (let i = this.state.selectedSection.index + 1; i < this.state.menuLinkStates.length; i++) {
                if (this.state.menuLinkStates[i].visible) {
                    return this.state.menuLinkStates[i].disable;
                }
            }
        }
        return false;
    }
    setSelectedSectionByIndex(index) {
        this.onSelectSection({index: index});
    }
    backClicked () {
        for (let i = this.state.selectedSection.index - 1; i >= 0; i--) {
            let menuState = this.state.menuLinkStates[i];
            if (menuState.visible) {
                this.setSelectedSectionByIndex(i);
                break;
            }
        }
    }
    nextClicked() {
        for (let i = this.state.selectedSection.index + 1; i < this.state.menuLinkStates.length; i++) {
            let menuState = this.state.menuLinkStates[i];
            if (menuState.visible) {
                this.setSelectedSectionByIndex(i);
                break;
            }
        }
    }
}

export default {
    template: template,
    bindings: {
        alwaysShowFinishButton: "=",
        hideFinishButton: "=",
        state: "=",
        onSelectSection: "&",
        finishClicked: "&",
        closeClicked: "&"
    },
    controller: WizardNavigationButtonsController
}
