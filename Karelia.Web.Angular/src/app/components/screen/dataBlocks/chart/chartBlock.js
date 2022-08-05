import template from './chart-block.html';
import DataSource from '../../../../services/dataSource/dataSource';
import screenSizeService from '../../../../services/helpers/screenSizeService';
import { getChartType } from '../../../../services/screens/chartService';
import dataTypeHelperService from '../../../../services/helpers/dataTypeHelperService';
import valueFormatter from '../../../../services/formatters/valueFormatter';
import BaseDataBlock from '../base/baseDataBlock';

class ChartBlockController extends BaseDataBlock {
    constructor(services, $element, $timeout) {
        'ngInject';
        super();
        this.services = services;
        this.$element = $element;
        this.$timeout = $timeout;
    }

    $onInit() {
        this.contextState = this.screenCtrl.contextState;
        this.options = this.screenCtrl.blocks[this.name];

        const category = this.options.content.category;
        this.seriesDefaults = {
            type: getChartType(this.options.content.chartType)
        };
        
        if (this.seriesDefaults.type === 'pie') {
            this.seriesDefaults.labels = {
                template: (e) => {
                    const value = e.dataItem[category.field.name];
                    if (category.format) {
                        return valueFormatter.format(value, category.format, category.field.dataType);
                    }
                    return value;
                },
                position: "center",
                visible: true
            };
        }
        this.series = this.options.content.series.map(s => {
            const serie = {
                field: s.field.name,
                name: s.title,
                type: dataTypeHelperService.isDate(s.field.dataType) ? 'date' : undefined,
            };
            return serie;
        });

        this.categoryAxis = {
            field: category.field.name,
            labels: {
                template: (e) => {
                    if (category.format) {
                        return valueFormatter.format(e.value, category.format, category.field.dataType);
                    }
                    return e.value;
                }
            }
        };

        new DataSource({
            query: this.options.controller,
            paging: {
                count: true
            },
        }, this.services.httpService).getData().then(data => {
            this.chartDataSource = {
                data: data.value
            }
        });

        this.screenCleaner = screenSizeService.addChangeScreenSizeListener(() => {
            this.chartRefresh();
        });

        this.$timeout(() => {
            this.chartRefresh();
        });
    }

    chartRefresh() {
        const chart = this.$element.find('.chart').data("kendoChart");
        if (chart)
            chart.refresh();
    }

    $onDestroy() {
        if (this.screenCleaner) {
            this.screenCleaner();
        }
    }
}

export default {
    template: template,
    require: {
        screenCtrl: "^screen"
    },
    bindings: {
        name: "@"
    },
    controller: ChartBlockController
}