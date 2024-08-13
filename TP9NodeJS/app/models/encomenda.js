const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const ProdutoSchema = new Schema({
  nomeProduto: String,
  precoUnitario: Number,
});

const EncomendaSchema = new Schema({
  cliente: {
    type: Schema.Types.ObjectId,
    ref: 'Cliente',
    required: true,
  },
  dataEncomenda: {
    type: Date,
    default: Date.now,
  },
  produtoEncomendado: {
    type: ProdutoSchema,
    required: true,
  },
  quantidadeEncomendada: {
    type: Number,
    required: true,
  },
  precoEncomenda: {
    type: Number,
    required: true,
  },
});

const Encomenda = mongoose.model('Encomenda', EncomendaSchema);

module.exports = Encomenda;
