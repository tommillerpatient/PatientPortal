var fs = require('fs');
var path = require('path');
var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var CopyWebpackPlugin = require('copy-webpack-plugin');

const DEBUG = !process.argv.includes('--release');

var WEB_URL;
var SERVICE_URL;

if(DEBUG){
    WEB_URL = '/';
    SERVICE_URL = 'http://localhost:28507';
}else {
    WEB_URL = '/';
    SERVICE_URL = 'http://patientportal.enode.org';

}


function render(page){
    return fs.readFileSync(page);
}

module.exports = {
    entry: {
        "patient/login": './src/patient/login/app.js',
        "patient/update/password": './src/patient/update/password/app.js',
        "patient/update/profile": './src/patient/update/profile/app.js',
        "patient/journey": './src/patient/journey/app.js'
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
            WEB_URL: JSON.stringify(WEB_URL),
            SERVICE_URL: JSON.stringify(SERVICE_URL)
        })
    ]
};

if(DEBUG){

    module.exports.plugins.push(
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/login/index.html',
            render: render('./src/patient/login/index.html')
        })
    );

    module.exports.plugins.push(
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/update/password/index.html',
            render: render('./src/patient/update/password/index.html')
        })
    );

    module.exports.plugins.push(
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/update/profile/index.html',
            render: render('./src/patient/update/profile/index.html')
        })
    );

    module.exports.plugins.push(
        new HtmlWebpackPlugin({
            inject: false,
            template: './src/template.hbs',
            filename: './patient/journey/index.html',
            render: render('./src/patient/journey/index.html')
        })
    );

    module.exports.plugins.push(
        new CopyWebpackPlugin([

            { from: './src/style.css', to: './style.css' },

        ])
    );

}else {

    module.exports.plugins.push(
        new CopyWebpackPlugin([

            { from: './src/patient/login/index.html', to: './patient/login/index.html' },
            { from: './src/patient/update/password/index.html', to: './patient/update/password/index.html' },
            { from: './src/patient/update/profile/index.html', to: './patient/update/profile/index.html' },
            { from: './src/patient/journey/index.html', to: './patient/journey/index.html' },

            { from: './src/style.css', to: './style.css' },

        ])
    );

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

