const router = require('express').Router();
const clientsModel = require('../../models/clients.model');
const { body, validationResult } = require('express-validator');


// Recuperamos un todos los clientes
router.get('/', async (req, res) => {
  try {
    const arrClients = await clientsModel.getAllClients();

    res.status(200).json(arrClients);
  }
  catch (error) {
    res.send({ error: error.message })
  }
});

// Recuperamos un cliente por su id , retorna 404 y mensaje de error si el cliente no exite en la BBDD
router.get('/:clientId', async (req, res) => {
  try {
    const client = await clientsModel.getOneClientById(req.params.clientId);
    if (!client) {
      res.status(404).json({ error: 'No existe el cliente solicitado ' })
    } else {
      res.status(200).json(client)
    }
  }
  catch (error) {
    res.send({ error: error.message });
  }
});

//Peticiones PUT //----------------------------------------------------
// Recueramos un  cliente por id para editarlo y devolvemos los datos del cliente actualizado, verificamos que todos los campos

router.put('/edit/:clientId',
  body('nombre').exists().withMessage('El campo nombre es obligatorio'),
  body('apellidos').exists().withMessage('El campo apellidos es obligatorio'),
  body('direccion').exists().withMessage('El campo direccion es obligatorio'),
  body('telefono').exists().withMessage('El campo telefono es obligatorio'),
  body('fecha_nacimiento').exists().withMessage('El campo fecha de nacimiento es obligatorio'),
  body('dni').exists().withMessage('El campo dni es obligatorio'),
  body('email').exists().isEmail().withMessage('El campo email es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    let id = req.params.clientId
    try {
      await clientsModel.updateClient(id, req.body);
      const updatedClient = await clientsModel.getOneClientById(id);
      res.status(200).json(updatedClient);
    } catch (error) {
      res.json({ error: error.message });
    };

  });


//Peticiones POST //---------------------------------------------------
// Creamos un cliente, verificamos los campos.
router.post('/',
  body('nombre').exists().withMessage('El campo nombre es obligatorio'),
  body('apellidos').exists().withMessage('El campo apellidos es obligatorio'),
  body('direccion').exists().withMessage('El campo direccion es obligatorio'),
  body('telefono').exists().withMessage('El campo telefono es obligatorio'),
  body('fecha_nacimiento').exists().withMessage('El campo fecha de nacimiento es obligatorio'),
  body('dni').exists().withMessage('El campo dni es obligatorio'),
  body('email').exists().isEmail().withMessage('El campo email es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    try {
      const response = await clientsModel.createNewClient(req.body);
      if (response.affectedRows === 1) {
        res.status(200).json({ succes: 'Cliente añadido a BBDD' })
      }
    } catch (error) {
      res.json({ error: error.message });
    };
  });

//Peticiones DELETE //--------------------------------------------------

// Eliminamos un cliente por su id 
router.delete('/:clientsId', async (req, res) => {
  try {
    await clientsModel.deleteClient(req.params.clientsId);
    res.status(200).json({ mensaje: 'Cliente Eliminado' })
  } catch (error) {
    res.json({ error: error.message });
  };
});



module.exports = router;