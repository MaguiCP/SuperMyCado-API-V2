const express = require('express');
const { celebrate, Joi, Segments } = require('celebrate');
const clienteController = require('../controllers/clienteController');
const router = express.Router();

const clienteIdSchema = Joi.object({
    id: Joi.string().hex().length(24).required()
});

// POST: http://localhost:8080/api/cliente
router.post('/', celebrate({
    [Segments.BODY]: {
        nome: Joi.string().required(),
        nif: Joi.string().required()
    }
}), clienteController.CreateCliente);

// GET: http://localhost:8080/api/cliente
router.get('/', clienteController.GetAllClientes);

// GET: http://localhost:8080/api/cliente/1
router.get('/:id', celebrate({
    [Segments.PARAMS]: clienteIdSchema
}), clienteController.GetClienteByCod);

// DELETE: http://localhost:8080/api/cliente/5f882eb6371fe437985b31a2
router.delete('/:id', celebrate({
    [Segments.PARAMS]: clienteIdSchema
}), clienteController.DeleteClienteByCod);

// PUT http://localhost:8080/api/cliente/5f882eb6371fe437985b31a2
router.put('/:id', celebrate({
    [Segments.PARAMS]: clienteIdSchema,
    [Segments.BODY]: {
        nome: Joi.string(),
        nif: Joi.string()
    }
}), clienteController.UpdateClienteByCod);

module.exports = router;