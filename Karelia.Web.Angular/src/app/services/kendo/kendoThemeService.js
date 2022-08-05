import config from './../config/config';
import settingsService from './../common/settingsService';

export default class KendoThemeService {
    constructor($css) {
        "ngInject";
        this.css = $css;
        this.SKIN_SETTING_NAME = "SKIN_SETTING_NAME";
    }

    _init() {
        const kendoSkinPath = config.useCDN ?
            "https://kendo.cdn.telerik.com/2017.1.223/styles/" :
            "kendo-2017-1-223/styles/";
        this.skins = [
            { name: "Bootstrap", value: [kendoSkinPath + "kendo.bootstrap.min.css"] },
            { name: "Black", value: [kendoSkinPath + "kendo.black.min.css"] },
            { name: "Flat", value: [kendoSkinPath + "kendo.flat.min.css"] },
            { name: "Blue Opal", value: [kendoSkinPath + "kendo.blueopal.min.css"] },
            { name: "Fiori", value: [kendoSkinPath + "kendo.fiori.min.css"] },
            { name: "High Contrast", value: [kendoSkinPath + "kendo.highcontrast.min.css"] },
            { name: "Material", value: [kendoSkinPath + "kendo.material.min.css"] },
            { name: "Material Black", value: [kendoSkinPath + "kendo.materialblack.min.css"] },
            { name: "Metro", value: [kendoSkinPath + "kendo.metro.min.css"] },
            { name: "Metro Black", value: [kendoSkinPath + "kendo.metroblack.min.css"] },
            { name: "Moonlight", value: [kendoSkinPath + "kendo.moonlight.min.css"] },
            { name: "Nova", value: [kendoSkinPath + "kendo.nova.min.css"] },
            { name: "Office 365", value: [kendoSkinPath + "kendo.office365.min.css"] },
            { name: "Silver", value: [kendoSkinPath + "kendo.silver.min.css"] },
            { name: "Uniform", value: [kendoSkinPath + "kendo.uniform.min.css"] },
            { name: "Future", value: [kendoSkinPath + "kendo.material.min.css", "themes/future.css"] },
            { name: "Empty", value: [] }
        ];
        this.skins.forEach(s => {
            s.value.push("https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css");
        });
    }

    _loadSkin(skin) {
        skin.value.forEach(value => {
            this.css.add(value);
        });
    }

    _removeSkin(skin) {
        skin.value.forEach(value => {
            this.css.remove(value);
        });
    }

    _getSkinByName(name) {
        return this.getSkins().filter(s => s.name === name)[0];
    }

    getSkins() {
        if (!this.skins)
            this._init();
        return this.skins;
    }

    loadDefaultTheme() {
        var skinName = settingsService.getSetting(this.SKIN_SETTING_NAME);
        if (!skinName) {
            skinName = config.defaultSkinName;
            settingsService.saveSetting(this.SKIN_SETTING_NAME, skinName);
        }
        this._loadSkin(this._getSkinByName(skinName));
    }

    changeSkin(skin) {
        var currentSkinName = settingsService.getSetting(this.SKIN_SETTING_NAME);
        this._removeSkin(this._getSkinByName(currentSkinName));
        this._loadSkin(skin);
        settingsService.saveSetting(this.SKIN_SETTING_NAME, skin.name);
    }
}
