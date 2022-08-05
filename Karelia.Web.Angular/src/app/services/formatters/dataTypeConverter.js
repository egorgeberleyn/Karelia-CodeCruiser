class DataTypeConverter {
    normalize(value, dataType) {
        /*
         None = 0,
         Bool = 1,
         String = 2,
         Integer = 3,
         Float = 4,
         Decimal = 5,
         DateTime = 6,
         DateTimeOffset = 7,
         Guid = 8,
         Image = 10,
         */
        switch (dataType) {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 10:
            case 'long':
            case 'double':
            case 'bool':
            case 'string':
            case 'int':
            case 'DateTime':
            case 'FileLink':
                return value;
            default:
                throw new TypeError('Unsupported datatype');
        }
    }

    isDate(dataType) {
        return dataType === 6 || dataType === 7 || dataType === 'DateTime';
    }

    isNumber(dataType) {
        return dataType === 3 ||
            dataType === 4 ||
            dataType === 5 ||
            dataType === 'long' ||
            dataType === 'double' ||
            dataType === 'int';
    }

    isImage(dataType) {
        return dataType === 10;
    }
}

export default new DataTypeConverter();