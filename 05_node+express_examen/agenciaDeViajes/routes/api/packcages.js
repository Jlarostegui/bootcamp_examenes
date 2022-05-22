const router = require('express').Router();
const packagesModel = require('../../models/packages.model');
const { body, validationResult } = require('express-validator');


// Peticiones GET // -----------------------------------

// Recuperamos todos los paquetes 
router.get('/', async (req, res) => {
  try {
    const listPackages = await packagesModel.getAllPackages();
    res.status(200).json(listPackages)
  }
  catch (error) {
    res.json({ error: error.message })
  }
});


// Recuperamos un paquete por su id 
router.get('/:idPackage', async (req, res) => {
  try {
    const package = await packagesModel.getOnePackageById(req.params.idPackage);
    res.status(200).json(package['insertId'])
  } catch (error) {
    res.json({ error: error.message })
  }
});


// Peticiones POST //------------------------------------

router.post('/new',
  body('ciudad').exists().withMessage('El campo nombre es obligatorio'),
  body('latitud').exists().isNumeric().withMessage('El campo latitud es obligatorio'),
  body('longitud').exists().isNumeric().withMessage('El campo longitud es obligatorio'),
  body('pais').exists().withMessage('El campo pais es obligatorio'),
  body('presentacion').exists().withMessage('El campo presentacion es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }

    try {
      const response = await packagesModel.createNewPackage(req.body);
      res.status(201).json(response['insertId']);
    }
    catch (error) {
      res.json({ error: error.message })
    }
  });


//Peticiones PUT --------------------------------------------------

router.put('/edit/:paqueteId',

  body('ciudad').exists().withMessage('El campo nombre es obligatorio'),
  body('latitud').exists().isNumeric().withMessage('El campo latitud es obligatorio'),
  body('longitud').exists().isNumeric().withMessage('El campo longitud es obligatorio'),
  body('pais').exists().withMessage('El campo pais es obligatorio'),
  body('presentacion').exists().withMessage('El campo presentacion es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    let id = req.params.paqueteId
    try {
      await packagesModel.updatedPackage(id, req.body);
      const updatedPackage = await packagesModel.getOnePackageById(id);
      res.status(200).json(updatedPackage);
    } catch (error) {
      res.json({ error: error.message });
    };

  });


// Peticiones Delete -------------------------------------------

router.delete('/:paqueteId', async (req, res) => {
  try {
    await packagesModel.deletePackage(req.params.paqueteId)
    res.status(200).json({ mensaje: 'Paquete Eliminado' });
  } catch (error) {
    res.json({ error: error.message })
  };

});


module.exports = router;