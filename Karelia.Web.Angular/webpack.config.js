const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const CopyWebpackPlugin = require('copy-webpack-plugin');
const HtmlWebpackExternalsPlugin = require('html-webpack-externals-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const UglifyJsPlugin = require('uglifyjs-webpack-plugin');

let cdnConfig = false;
try {
    cdnConfig = require('./libraryCdnList.json');
} catch (e) {
    console.log("No cdn information provided. Use local packages.");
}

module.exports = (env, argv) => {
    return {
        optimization: {
            splitChunks: {
                chunks: 'all'
            },
            minimizer: [
                new UglifyJsPlugin({
                    cache: true,
                    parallel: true
                }),
                new OptimizeCSSAssetsPlugin({})
            ]
        },
        context: path.resolve(__dirname, 'src'),
        output: {
            path: path.join(__dirname, '/dist'),
            filename: '[name].bundle-[hash].js',
        },
        entry: [
            path.join(__dirname, 'src/app/domain/domain.module.js'),
            path.join(__dirname, 'src/app/components/wizard/wizard.module.js'),
            path.join(__dirname, 'src/app/registration/registration.module.js'),
            path.join(__dirname, 'src/app/index.module.js'),
            path.join(__dirname, 'src/app/services/services.module.js')
        ],
        module: {
            rules: [{
                test: /\.scss$|\.css$/,
                use: getSassLoaders(argv.mode !== 'production')
            }, {
                test: /\.(eot|woff|woff2|ttf|png|svg|jpg|gif)$/,
                loader: 'url-loader?limit=300'
            }, {
                test: /\.html$/,
                exclude: /index(_cdn)?\.html/,
                loader: 'ng-cache-loader?prefix=[dir]/[dir]'
            }, {
                parser: { amd: false },
                test: /\.js$/,
                include: [path.resolve(__dirname, "src/app/")],
                exclude: /(node_modules|lib)/,
                loader: 'babel-loader',
                query: {
                    presets: ['latest'],
                    plugins: ["angularjs-annotate", "syntax-dynamic-import", "transform-runtime"]
                }
            }]
        },
        plugins: [
            new MiniCssExtractPlugin({
                filename: argv.mode !== 'production' ? '[name].css' : '[name]-[contenthash].css',
                chunkFilename: argv.mode !== 'production' ? '[id].css' : '[id]-[contenthash].css',
            }),
            new CleanWebpackPlugin(['dist'], {
                root: __dirname,
                verbose: true,
                dry: false,
                exclude: ['dll']
            }),
            new HtmlWebpackPlugin({
                inject: true,
                template: path.resolve(__dirname, cdnConfig ? 'src/index_cdn.html' : 'src/index.html'),
                filename: "index.html",
                path: 'dist'
            }),
            cdnConfig ?
                new HtmlWebpackExternalsPlugin(cdnConfig) :
                new webpack.DllReferencePlugin({
                    context: '.',
                    manifest: require('./dist/dll/vendor-manifest.json')
                }),
            new webpack.ProvidePlugin({
                $: "jquery",
                jQuery: "jquery",
                "window.jQuery": "jquery",
                "angular": "angular"
            }),
            new CopyWebpackPlugin(getCopyList()),
            new webpack.WatchIgnorePlugin([
                path.resolve(__dirname, 'src/index.html'),
                "index.html"
            ])
        ]
    }
}

function getCopyList() {
    const list = [];
    list.push({ from: path.resolve(__dirname, 'src/favicon.ico'), to: "" });
    list.push({ from: path.resolve(__dirname, 'src/config.json'), to: "" });
    list.push({ from: path.resolve(__dirname, 'src/app/domain/templates'), to: "templates" });
    list.push({ from: path.resolve(__dirname, 'src/assets'), to: "assets" });
    list.push({ from: path.resolve(__dirname, 'src/themes'), to: "themes" });
    if (!cdnConfig) {
        list.push({ from: path.resolve(__dirname, 'src/lib'), to: "" });
    }
    return list;
}

function getSassLoaders(devMode) {
    const sassLoaders = []
    if (devMode) {
        sassLoaders.push('css-hot-loader');

    }
    sassLoaders.push(MiniCssExtractPlugin.loader);
    sassLoaders.push('css-loader');
    sassLoaders.push('sass-loader');
    return sassLoaders;
}