
var express = require('express')
  , http = require('http')
  , path = require('path')
  , fs = require('fs');

var app = express();

app.set('port', process.env.PORT || 3020);
app.use(express.static(path.join(__dirname, 'public')));


app.get('/',  function(req, res){
  res.redirect('/patient/login/index.html');
});

http.createServer(app).listen(app.get('port'), function(){
  console.log("Express server listening on port " + app.get('port'));
});
