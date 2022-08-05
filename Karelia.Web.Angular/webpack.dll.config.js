const webpack = require('webpack');
const path = require('path');

module.exports = {
    entry: {
        vendor: [path.join(__dirname, "src/lib/", "vendors.js")],
    },
    output: {
        filename: '[name].bundle.js',
        path: __dirname + '/dist/dll',
        library: '[name]'
    },
    optimization: {
        minimize: false
    },
    module: {
        rules: [{
            test: require.resolve('jquery'),
            use: [{
                loader: 'expose-loader',
                options: '$'
            }, {
                loader: 'expose-loader',
                options: 'jQuery'
            }]
        }, {
            test: require.resolve('angular'),
            use: [{
                loader: 'expose-loader',
                options: 'angular'
            }]
        }, {
            test: require.resolve('moment'),
            use: [{
                loader: 'expose-loader',
                options: 'moment'
            }]
        }, {
            test: require.resolve('./src/lib/kendo-2017-1-223/js/kendo.all.min'),
            use: [{
                loader: 'expose-loader',
                options: 'kendo'
            }]
        }]
    },
    plugins: [
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery",
            "window.jQuery": "jquery",
            "angular": "angular"
        }),
        new webpack.DllPlugin({
            path: __dirname + '/dist/dll/[name]-manifest.json',
            name: '[name]'
        })
    ]
};
