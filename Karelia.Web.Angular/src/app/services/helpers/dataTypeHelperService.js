class DataTypeHelperService{
    getEditorTypeById(typeId) {
        switch (typeId) {
            case 1:
                return "text";
            case 2:
                return "combobox";
            case 3:
                return "autocomplete";
            case 4:
                return "date";
            case 5:
                return "numeric";
            case 6:
                return "color";
            case 7:
                return "checkbox";
            case 8:
                return "picture";
            case 99:
                return "subentity";
            case 100:
                return "cutomsingle";
            case 101:
                return "custommulti";
            default:
                return "";
        }
    }
    isBool(dataTypeId) {
        return this.toJSType(dataTypeId) === 'boolean';
    }
    toJSType(dataTypeId) {
        switch (dataTypeId) {
            case 0:
                return "none";
            case 1:
                return "boolean";
            case 2:
                return "string";
            case 3:
            case 4:
            case 5:
                return "number";
            case 6:
            case 7:
                return "date";
            case 8:
                return "string";
            //case 10:
            //    return "Image";
            default:
                return "string";
        }
    }
    getDataTypeById (dataTypeId) {
        switch (dataTypeId) {
            case 1:
                return "Bool";
            case 2:
                return "String";
            case 3:
                return "Integer";
            case 4:
                return "Float";
            case 5:
                return "Decimal";
            case 6:
                return "DateTime";
            case 7:
                return "DateTimeOffset";
            case 8:
                return "Guid";
            case 10:
                return "Image";
            default:
                return "";
        }
    }
    isImage(type) {
        return type === 10;
    }
    isDate(type) {
        return type === 6;
    }
    isBinary(type) {
        return type === 10;
    }
    isFileLink(type) {
        return type === 0;
    }
}

export default new DataTypeHelperService();
