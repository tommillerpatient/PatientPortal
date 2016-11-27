var fs = require('fs');
var path = require('path');
var webpack = require('webpack');
var postcss = require("postcss");
var handlebars = require('handlebars');
var customProperties = require("postcss-custom-properties")
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');

const DEBUG = !process.argv.includes('--release');

var CONTENT_URL;
var SERVICE_URL;

if(DEBUG){
    SERVICE_URL = 'http://localhost:28507/';
    CONTENT_URL = '/';
}else {
    SERVICE_URL = 'http://patientportal.enode.org/';
    CONTENT_URL = 'http://patientportal.enode.org/';
}

var pageContext = {
    contentUrl: CONTENT_URL
};

var variables = {
    "--content-url": CONTENT_URL,
};

function render(url){
    var page = fs.readFileSync(url, "utf8");
    if(/\.hbs$/.test(url)) {
        var template = handlebars.compile(page);
        return template(pageContext);
    }
    return page;
}

function cssTransform(content, path) {
    var plugin = customProperties();
    plugin.setVariables(variables);
    return postcss()
        .use(plugin)
        .process(content)
        .css;
}

module.exports = {
    entry: {
        "patient/login": './src/patient/login/app.js',
        "patient/update/password": './src/patient/update/password/app.js',
        "patient/update/profile": './src/patient/update/profile/app.js',
        "patient/journey": './src/patient/journey/app.js',
        "patient/register": './src/patient/register/app.js',
        "patient/logoff": './src/patient/logoff/app.js'
    },
    output: {
        publicPath: "/",
        filename: '[name]/app.js',
        path: __dirname + '/public'
    },
    //watch: DEBUG,
    devtool: DEBUG ? "cheap-module-inline-source-map" : null,
    module: {
        loaders: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'babel',
                query: {
                    presets: ['stage-0', 'es2015']
                }
            },
            {
                test: /\.css/,
                exclude: /node_modules/,
                loader: 'style!css'
            },
            { test: /\.html$/, loader: "raw" },
            { test: /\.hbs$/, loader: "handlebars" },
            {
                test: /\.(png|jpg)$/,
                loader: "file"
            }
        ]
    },
    plugins: [
        new webpack.DefinePlugin({
            DEBUG: DEBUG,
            SERVICE_URL: JSON.stringify(SERVICE_URL),
            CONTENT_URL: JSON.stringify(CONTENT_URL),
        }),
        new CopyWebpackPlugin([
            { from: './src/style.css', to: './style.css', transform: cssTransform },
            { from: './src/images', to: './images'  }
        ]),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/login/index.html',
            render: render('./src/patient/login/index.hbs')
        }),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/update/password/index.html',
            render: render('./src/patient/update/password/index.hbs')
        }),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/update/profile/index.html',
            render: render('./src/patient/update/profile/index.hbs')
        }),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/journey/index.html',
            render: render('./src/patient/journey/index.hbs')
        }),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/register/index.html',
            render: render('./src/patient/register/index.hbs')
        }),
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/logoff/index.html',
            render: render('./src/patient/logoff/index.hbs')
        })
    ]
};

if(!DEBUG){

    module.exports.plugins.push(
        new webpack.optimize.UglifyJsPlugin({
            compress:{
                warnings: false,
                drop_console: true,
                unsafe: true
            }
        })
    );
}

