var path = require('path');
var webpack = require('webpack');
var VueLoaderPlugin = require('vue-loader/lib/plugin');
const bundleOutputDir = path.resolve(__dirname, './wwwroot/');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: ['./VueComponents/registerVue.js','./SCSS/site.scss'],
    output: {
        path: bundleOutputDir,
        filename: 'js/site.bundle.js',
        // chunkFilename: "js/modules.site.bundle.js"
    },
    watch : true,
    module: {
        rules: [
            {
                test: /\.css$/,
                use: [
                  'vue-style-loader',
                  'css-loader'
                ],
            },
            // {
            //     test: /\.scss$/,
            //     use: [
            //         'vue-style-loader',
            //         'css-loader',
            //         'sass-loader'
            //     ],
            // },
            // {
            //     test: /\.sass$/,
            //     use: [
            //         'vue-style-loader',
            //         'css-loader',
            //         'sass-loader?indentedSyntax'
            //     ],
            // },
            {
                test: /\.vue$/,
                loader: 'vue-loader',
                options: {
                    loaders: {
                    // Since sass-loader (weirdly) has SCSS as its default parse mode, we map
                    // the "scss" and "sass" values for the lang attribute to the right configs here.
                    // other preprocessors should work out of the box, no loader config like this necessary.
                    'scss': [
                        'vue-style-loader',
                        'css-loader',
                        'sass-loader'
                    ],
                    'sass': [
                        'vue-style-loader',
                        'css-loader',
                        'sass-loader?indentedSyntax'
                    ]
                    }
                    // other vue-loader options go here
                }
            },
            {
                test: /\.js$/,
                loader: 'babel-loader',
                exclude: /node_modules/
            },
            {
                test: /\.(png|jpg|gif|svg)$/,
                loader: 'file-loader',
                options: {
                    name: '[name].[ext]?[hash]'
                }
            },
            {
                test: /\.scss$/,
                use: [
                    { loader: MiniCssExtractPlugin.loader },
                    { loader: "css-loader" },
                    { loader: "sass-loader" }
                ]
            }
        ]
    },
    plugins : [
        new VueLoaderPlugin(),
        new MiniCssExtractPlugin({
            filename: "./css/site.bundle.css",
            publicPath: "./wwwroot/css"
        }),
    ],
    resolve: {
        alias: {
            'vue$': 'vue/dist/vue.esm.js'
        },
        extensions: ['*', '.js', '.vue', '.json']
    },
    performance: {
        hints: false
    },
    devtool: '#eval-source-map'
};