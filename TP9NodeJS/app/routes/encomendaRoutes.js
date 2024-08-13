const express = require('express');
const router = express.Router();
const { celebrate, Joi, Segments } = require('celebrate');
const encomendaController = require('../controllers/encomendaController');

const encomendaIdSchema = Joi.object({
  id: Joi.string().hex().length(24).required()
});

router.post(
  '/',
  celebrate({
    [Segments.BODY]: Joi.object().keys({
      codProduto: Joi.string().required(),
      quantidade: Joi.number().integer().min(1).required(),
      nifCliente: Joi.string().required(),
    }),
  }),
  encomendaController.criarEncomenda
);

// GET: http://localhost:8080/api/encomenda
router.get('/', encomendaController.getAllEncomendas);

// GET: http://localhost:8080/api/encomenda/1
router.get('/:id', celebrate({
  [Segments.PARAMS]: encomendaIdSchema
}), encomendaController.getEncomendaById);

module.exports = router;