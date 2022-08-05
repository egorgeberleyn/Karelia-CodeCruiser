import $ from 'jquery';

class ScreenSizeService {
    constructor() {
        this.changeScreenSizeListeners = [];
        window.addEventListener('resize', () => {
            this.raiseResizeEvent();
        });
    }

    raiseResizeEvent() {
        this.changeScreenSizeListeners.forEach(c => {
            c();
        });
        $(window).trigger('resize'); //It's for all kendo controls.
    }

    addChangeScreenSizeListener(callback) {
        this.changeScreenSizeListeners.push(callback);
        return () => {
            const indexOfCallback = this.changeScreenSizeListeners.indexOf(callback);
            this.changeScreenSizeListeners.splice(indexOfCallback, 1);
        }
    }

    getScreenSize() {
        const wind = $(window);

        return {
            height: wind.height(),
            width: wind.width()
        };
    }

    isBig() {
        return this.getScreenSize().width >= 700;
    }

    isMedium() {
        const size = this.getScreenSize();
        return size.width >= 480 && size.width < 700;
    }

    isSmall() {
        return this.getScreenSize().width <= 480;
    }
}

export default new ScreenSizeService();
