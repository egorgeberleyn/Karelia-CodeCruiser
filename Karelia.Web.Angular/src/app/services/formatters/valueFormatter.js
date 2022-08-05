import moment from 'moment';
import numeral from 'numeral';
import dataTypeConverter from './dataTypeConverter';
import dataTypeHelperService from '../helpers/dataTypeHelperService';

class ValueFormatter {
    constructor() {
        this.formats = [];
    }

    init(httpService) {
        return httpService.get('ValueFormatting').then(result => {
            this.formats = result.data;
        });
    }

    format(value, format, dataType) {
        value = dataTypeConverter.normalize(value, dataType);
        if (!value) {
            return "";
        }
        const formatter = this.formats.find(f => {
            return f.Key === format;
        });
        if (formatter) {
            if (dataTypeConverter.isDate(dataType)) {
                return moment(value).local().format(formatter.Format);
            }
            if (dataTypeConverter.isNumber(dataType)) {
                return numeral(value).format(formatter.Format)
            }
        }
        return value;
    }

    convertDatesToLocal(fields, data) {
        for(let i = 0; i< fields.length; i++) {
            const field = fields[i].field;
            const value = data[field.name];
            if (dataTypeHelperService.isDate(field.dataType) && value) {
                data[field.name] = moment.utc(value).local().toDate();
            }
        }
        return Promise.resolve(data);
    }
}

export default new ValueFormatter();


