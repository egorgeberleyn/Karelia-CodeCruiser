class GridService{
    autoFitColumns(grid) {
        let set;
        for (let i = 0; i < grid.columns.length; i++) {
            if (!grid.columns[i].width) {
                set = true;
                grid.autoFitColumn(i);
            }
        }
        // Strange behavior of kendo grid, but in another first column becomes very big and has wrong resize behavior
        if (!set) {
            grid.autoFitColumn(0);
        }
    }
    exportToExcel (grid) {
        grid.saveAsExcel();
    }

    resizeGrid (gridName) {
        const gridElement = angular.element("div[kendo-grid='" + gridName + "']");
        if (gridElement && gridElement.length > 0) {

            const parent = gridElement.closest('grid');
            const toolBar = gridElement.parent().find("toolbar");
            let parentHeight = parent.outerHeight(true);
            if (toolBar && toolBar.length > 0) {
                const toolbarChildren = toolBar.children(); //I don't know why, but toolbar has length 0 in chrome =(
                if (toolbarChildren && toolbarChildren.length > 0) {
                    parentHeight -= toolbarChildren.outerHeight(true);
                } else {
                    parentHeight -= toolBar.outerHeight(true);
                }
            }
            let combinedElementHeight = 0;
            //Calculate all Grid elements height except the content
            const otherGridElements = gridElement.children().not(".k-grid-content").not('.k-grid-content-locked'); //This is anything other than the Grid it's lf like header, commands, etc
            otherGridElements.each(function () {
                combinedElementHeight += angular.element(this).outerHeight(true);
            });

            if (parentHeight !== 0) {
                const dataArea = gridElement.find(".k-grid-content");
                gridElement.height(parentHeight);
                dataArea.height(parentHeight - combinedElementHeight);
                const lockedDataArea = gridElement.find(".k-grid-content-locked");
                if (lockedDataArea && lockedDataArea.length > 0)
                    lockedDataArea.height(parentHeight - combinedElementHeight);
            }
        }
    }
}

export default new GridService();

