
function createMenuLink(title, name, index) {
    return {
        text: title,
        name: name,
        index: index
    };
}
export function createNavigationMenu(wizardSettings) {
    const sections = [];
    let index = 0;
    const addMenuLink = (pageDescr, parentSection) => {
        const link = createMenuLink(pageDescr.title, pageDescr.name, index++)
        if (parentSection) {
            parentSection.items.push(link);
        } else {
            sections.push(link);
        }
    };

    if (wizardSettings.items && wizardSettings.items.length > 0) {
        wizardSettings.items.forEach(item => {
            if (item.type === 1) { // Simple page
                var parent = null;
                if (item.parent) { //Has page group
                    //parent =
                }
                addMenuLink(item, parent);
            }
        });
    }
    return sections;
}

