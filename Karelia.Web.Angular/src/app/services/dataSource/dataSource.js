import { buildQuery } from './odataBuilder';

export default class DataSource{
    constructor(options, httpService) {
        this.query = options.query;
        this.filtering = options.filtering || {};
        this.paging = options.paging || {};
        this.sorts = options.sorts || [];
        this.httpService = httpService;
        this.data = [];
    }
    getData() {
        const query = buildQuery(this.query, this.paging, this.sorts, this.filtering);
        if (this.filtering.globalFilter && this.filtering.globalFilter.depIsNull) {
            return Promise.resolve({
                value: [],
                count: 0
            });
        }
        return this.httpService.getOdata(query).then(res => {
            return {
                value: res.data.value,
                count: res.data["@odata.count"]
            };
        });
    }
}