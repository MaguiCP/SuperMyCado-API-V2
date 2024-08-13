const Client = require('node-rest-client').Client;
const Encomenda = require('../models/encomenda');
const Cliente = require('../models/cliente');

const apiClient = new Client({ connection: { rejectUnauthorized: false } });
const produtoApiUrl = 'https://localhost:7272/api/produto';

const obterInformacoesProduto = (codProduto) => {
  return new Promise((resolve, reject) => {
    apiClient.get(`${produtoApiUrl}/${codProduto}`, (data, response) => {
      if (response.statusCode === 200) {
        resolve(data);
      } else {
        reject(`Erro ao obter informações do produto. Status: ${response.statusCode}`);
      }
    });
  });
};

const obterCliente = async (nifCliente) => {
  try {
    const cliente = await Cliente.findOne({ nif: nifCliente });

    if (!cliente) {
      throw new Error('Cliente não encontrado');
    }

    return cliente;
  } catch (error) {
    throw new Error(`Erro ao encontrar cliente: ${error.message}`);
  }
};

criarEncomenda = async (req, res) => {
  try {
    const { codProduto, quantidade, nifCliente } = req.body;

    const produtoApiData = await obterInformacoesProduto(codProduto);

    const precoUnitario = produtoApiData.precoUnitario;
    const precoEncomenda = precoUnitario * quantidade;

    if (quantidade > produtoApiData.quantidadeStock) {
      return res.status(400).json({ message: 'Quantidade em stock insuficiente' });
    }

    const cliente = await obterCliente(nifCliente);

    if (!cliente) {
      return res.status(404).json({ message: 'Cliente não encontrado' });
    }

    const produtoEncomendado = {
      nomeProduto: produtoApiData.nomeProduto,
      precoUnitario: produtoApiData.precoUnitario,
    };

    const encomenda = new Encomenda({
      produtoEncomendado: produtoEncomendado,
      cliente: cliente._id,
      quantidadeEncomendada: quantidade,
      precoEncomenda: precoEncomenda,
    });

    await encomenda.save();
    res.status(201).json({ message: 'Encomenda criada com sucesso', encomenda });
  } catch (error) {
    console.error(error);
    res.status(500).json({ message: 'Erro interno do servidor', error: error.toString() });
  }
};

getAllEncomendas = async (req, res) => {
  try {
    const encomendas = await Encomenda.find().exec();
    res.status(200).json(encomendas);
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: 'Erro interno do servidor' });
  }
};

getEncomendaById = async (req, res) => {
  try {
    const encomenda = await Encomenda.findById(req.params.id).exec();

    if (!encomenda) {
      res.status(404).json({ error: 'Encomenda não encontrada' });
    } else {
      res.status(200).json(encomenda);
    }
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: 'Erro interno do servidor' });
  }
};

module.exports = {
  criarEncomenda,
  getEncomendaById,
  getAllEncomendas,
};
