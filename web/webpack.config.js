var fs = require('fs');
var path = require('path');
var webpack = require('webpack');
var postcss = require("postcss");
var handlebars = require('handlebars');
var customProperties = require("postcss-custom-properties")
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');


const CMS = process.argv.includes('--cms');
const RELEASE = process.argv.includes('--release');

const DEBUG = !CMS && !RELEASE;

var WEB_URL;
var CONTENT_URL;
var SERVICE_URL;

if(CMS){
    WEB_URL = '/';
    SERVICE_URL = 'https://sequenceapi.tenethealth.com/';
    CONTENT_URL = 'https://sequenceapi.tenethealth.com/content/';
}else if(RELEASE){
    WEB_URL = '/';
    SERVICE_URL = 'https://sequenceapi.tenethealth.com/';
    CONTENT_URL = 'https://sequenceapi.tenethealth.com/content/';
}else {
    WEB_URL = '/';
    CONTENT_URL = '/';
    SERVICE_URL = 'http://localhost:28507/';
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

var cssPlugin = customProperties();
cssPlugin.setVariables(variables);

function cssTransform(content, path) {
    return postcss()
        .use(cssPlugin)
        .process(content)
        .css;
}

var htmlWebpackOptions = {
    inject: false,
    contentUrl: CONTENT_URL,
    template: './src/template.hbs'
};

module.exports = {
    entry: {
        "patient/login": './src/patient/login/app.js',
        "patient/register": './src/patient/register/app.js',
        "patient/logoff": './src/patient/logoff/app.js',

        "patient/update/password": './src/patient/update/password/app.js',
        "patient/update/profile": './src/patient/update/profile/app.js',

        "patient/journey": './src/patient/journey/app.js',
        "patient/journey/root": './src/patient/journey/root/app.js',
        "patient/journey/blood-work": './src/patient/journey/blood-work/app.js'
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
            CMS: CMS,
            RELEASE: RELEASE,
            DEBUG: DEBUG,
            WEB_URL: JSON.stringify(WEB_URL),
            SERVICE_URL: JSON.stringify(SERVICE_URL),
            CONTENT_URL: JSON.stringify(CONTENT_URL),
        }),
        new CopyWebpackPlugin([
            { from: './src/main.css', to: './main.css' },
            { from: './src/app-fix.js', to: './app-fix.js' },
            { from: './src/style.css', to: './style.css', transform: cssTransform },
            { from: './src/custom.css', to: './custom.css', transform: cssTransform },
            { from: './src/images', to: './images'  },
            { from: './src/vendors', to: './vendors'  }
        ]),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/login/index.html',
            render: render('./src/patient/login/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/update/password/index.html',
            render: render('./src/patient/update/password/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/update/profile/index.html',
            render: render('./src/patient/update/profile/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/journey/index.html',
            render: render('./src/patient/journey/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/register/index.html',
            render: render('./src/patient/register/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/logoff/index.html',
            render: render('./src/patient/logoff/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/journey/root/index.html',
            render: render('./src/patient/journey/root/index.hbs')
        }),
        new HtmlWebpackPlugin({
            ...htmlWebpackOptions,
            filename: './patient/journey/blood-work/index.html',
            render: render('./src/patient/journey/blood-work/index.hbs')
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

