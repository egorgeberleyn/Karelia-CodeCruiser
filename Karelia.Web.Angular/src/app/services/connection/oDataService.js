export default class OdataService{
    constructor(){
    }
    normalize(value) {
        if (value || value === false) {
            return value;
        }
        return "null";
    }
    toString(value) {
        if (value) {
            return encodeURI("'" + value.replace(/'/g, "''") + "'");
        }
        return "null";
    }
    toDateTime(value) {
        //TODO: check it, for detail of dateTime format see https://msdn.microsoft.com/en-us/library/hh169248(v=nav.90).aspx
        if (value) {
            return encodeURI("datetime'" + value + "'");
        }
        return "null";
    }
}

