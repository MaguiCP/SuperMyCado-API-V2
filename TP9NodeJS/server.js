const express = require('express');

var app = express();
var bodyParser = require('body-parser');
var cors = require('cors');

const { errors } = require('celebrate');

var mongoObj = require('mongoose');

mongoObj.connect('');

var db = mongoObj.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function () {
    console.log("connected to mongo database");
});

mongoObj.Promise = global.Promise;

app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());

var port = process.env.PORT || 8080;

var mWare = require('./middleware');
app.use(mWare);

var corsOptions = {
    "origin": "*",
    "methods": "GET,HEAD,PUT,PATCH,POST,DELETE",
    "preflightContinue": false,
    "optionsSuccessStatus": 204
}

app.use(cors(corsOptions));

var EncomendaRoutes = require('./app/routes/EncomendaRoutes');
app.use('/api/encomenda', EncomendaRoutes);

var ClienteRoutes = require('./app/routes/ClienteRoutes');
app.use('/api/cliente', ClienteRoutes);

app.use(errors());
app.listen(port);
console.log('------------------');
console.log('Using port ' + port);
console.log('------------------');