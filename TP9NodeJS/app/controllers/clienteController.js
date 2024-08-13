const ClienteModel = require('../models/cliente');

GetAllClientes = async (req, res) => {
    try {
        const existingClientes = await ClienteModel.find().exec();

        const cList = existingClientes.map(c => ({ 'id': c._id, 'nome': c.nome, 'nif': c.nif }));

        res.status(200).send(cList);
    } catch (error) {
        console.error(error);
        res.status(500).send({ error: 'Erro interno do servidor' });
    }
}

GetClienteByCod = async (req, res) => {
    try {
        const query = { _id: req.params.id };
        const theCliente = await ClienteModel.findOne(query).exec();

        if (!theCliente) {
            res.status(404).send({ error: 'Cliente não encontrado' });
        } else {
            res.json(theCliente);
        }
    } catch (error) {
        res.status(500).send({ error: 'Erro interno do servidor' });
    }
}

DeleteClienteByCod = async (req, res) => {
    try {
        const result = await ClienteModel.deleteOne({ _id: req.params.id }).exec();
        if (result.deletedCount === 0) {
            res.status(404).send({ error: 'Cliente não encontrado' });
        } else {
            res.json({ mensagem: 'O cliente foi apagado com sucesso' });
        }
    } catch (error) {
        res.status(500).send({ error: 'Erro interno do servidor' });
    }
};

UpdateClienteByCod = async (req, res) => {
    try {
        const query = { _id: req.params.id };
        const theCliente = await ClienteModel.findOne(query).exec();

        if (!theCliente) {
            res.status(404).send({ error: 'Cliente não encontrado' });
            return;
        }

        if (req.body.nome) {
            theCliente.nome = req.body.nome;
        }
        if (req.body.nif) {
            theCliente.nif = req.body.nif;
        }

        await theCliente.save();
        res.status(200).send({ 'id': theCliente._id, 'nome': theCliente.nome, 'nif': theCliente.nif });
    } catch (error) {
        res.status(500).send({ error: 'Erro interno do servidor' });
    }
}

CreateCliente = async (req, res) => {
    try {
        const newCliente = new ClienteModel({
            nome: req.body.nome,
            nif: req.body.nif
        });

        await newCliente.save();
        res.status(201).send({ mensagem: 'O cliente foi criado com sucesso.' });
    } catch (error) {
        console.error(error);
        res.status(500).send({ error: 'Erro interno do servidor' });
    }
}

module.exports = {
    GetAllClientes,
    GetClienteByCod,
    DeleteClienteByCod,
    UpdateClienteByCod,
    CreateCliente
}