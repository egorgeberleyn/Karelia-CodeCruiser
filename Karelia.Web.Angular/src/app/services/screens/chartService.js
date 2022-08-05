export function getChartType(type) {
    switch (type) {
        case 1:
            return "line";
        case 2:
            return "area";
        case 3:
            return "bar";
        case 4:
            return "pie";
        case 5:
            return "doughnut";
        case 6:
            return "profit";
        default: 
            throw new Error("Unsupported chart type");
    }
}
