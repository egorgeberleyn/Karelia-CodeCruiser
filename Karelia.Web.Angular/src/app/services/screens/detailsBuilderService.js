import DataSource from './../../services/dataSource/dataSource';
import { buildGlobalFilter } from '../dataSource/filterBuilder';
import dataTypeHelperService from './../helpers/dataTypeHelperService';
import config from './../config/config';
import valueFormatter from '../formatters/valueFormatter';

class DetailsBuilderService {

    getFields(fieldDescriptions) {
        return fieldDescriptions.map(contentField => {
            const field = {
                title: contentField.title,
                field: contentField.field.name,
                value: null,
                format: contentField.format,
                isImage: dataTypeHelperService.isImage(contentField.field.dataType),
                isFileLink: dataTypeHelperService.isFileLink(contentField.field.dataType),
                dataType: contentField.field.dataType,
                isEndLine: contentField.isEndLine,
                isMultiline: contentField.lineCount > 1
            };
            return field;
        });
    }

    getDetails(controller, fieldContainers, contextState, dependencies, dataSourceFilter, httpService, ) {
        const dataSource = new DataSource({
            paging: {
                top: 1
            },
            sorts: {},
            query: controller,
            filtering: {
                dataSourceFilter,
                globalFilter: buildGlobalFilter(dependencies, contextState)
            }
        }, httpService);

        return dataSource.getData().then(res => {
            const data = res.value.length > 0 ? res.value[0] : {};
            fieldContainers.forEach(container => {
                container.fields.forEach(field => {
                    if (data.hasOwnProperty(field.field)) {
                        let value = data[field.field];
                        if (field.format) {
                            value = valueFormatter.format(value, field.format, field.dataType);
                        }
                        field.value = value;
                    }
                });
            });
            return fieldContainers;
        });
    }
}
export default new DetailsBuilderService();