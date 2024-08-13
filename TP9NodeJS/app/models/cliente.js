const mongoose = require('mongoose');
const Schema = mongoose.Schema;

var ClienteSchema = new Schema({
    nome: {
        type: String,
        required: true
    },
    nif: {
        type: String,
        required: true,
        unique: true
    }
});

module.exports = mongoose.model('Cliente', ClienteSchema);