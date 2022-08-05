const webpack = require('webpack');
const _ = require('lodash');
const commonConfig = require('./webpack.config.js')(null, {mode: 'development'});

const config = {
    cache: true,
    output: {
        pathinfo: true
    },
    devtool: "cheap-module-eval-source-map",
    devServer: {
        host: 'localhost',
        port: 8080,
        historyApiFallback: true,
        contentBase: './dist',
        hot: true,
        open: true,
        openPage: ''
      },
    watchOptions: {
        aggregateTimeout: 600,
        poll: 1000
    },
    watch: true
};

commonConfig.entry.unshift('webpack/hot/only-dev-server');
commonConfig.entry.unshift('webpack-dev-server/client?http://localhost:8080');

const devConfig = _.merge(commonConfig, config);
devConfig.plugins = devConfig.plugins.concat([
    new webpack.NamedModulesPlugin(),
    new webpack.HotModuleReplacementPlugin()
]);
module.exports = devConfig;

