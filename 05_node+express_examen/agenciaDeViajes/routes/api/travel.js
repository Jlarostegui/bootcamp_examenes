const router = require('express').Router();
const travelModel = require('../../models/travel.model');
const { body, validationResult } = require('express-validator');


// Peticiones GET // -----------------------------------

router.get('/', async (req, res) => {
  try {
    const listTravel = await travelModel.getAllTravel();
    res.status(200).json(listTravel)
  }
  catch (error) {
    res.json({ error: error.message })
  }
});


router.get('/:idTravel', async (req, res) => {
  try {
    const travel = await travelModel.getOneTravelById(req.params.idTravel);
    res.status(200).json(travel)
  } catch (error) {
    res.json({ error: error.message })
  }
});



router.post('/new',
  body('ida').exists().withMessage('El campo fecha de ida es obligatorio'),
  body('vuelta').exists().withMessage('El campo fecha de vuelta es obligatorio'),
  body('hotel').exists().withMessage('El campo hotel es obligatorio'),
  body('direccion').exists().withMessage('El campo direccion es obligatorio'),
  body('seguro').exists().withMessage('El campo seguro es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    try {
      const response = await travelModel.createNewTravel(req.body);
      res.status(201).json(response['insertId']);
    }
    catch (error) {
      res.json({ error: error.message })
    }
  });


//Peticiones PUT --------------------------------------------------

router.put('/edit/:travelId',
  body('ida').exists().withMessage('El campo fecha de ida es obligatorio'),
  body('vuelta').exists().withMessage('El campo fecha de vuelta es obligatorio'),
  body('hotel').exists().withMessage('El campo hotel es obligatorio'),
  body('direccion').exists().withMessage('El campo direccion es obligatorio'),
  body('seguro').exists().withMessage('El campo seguro es obligatorio'),
  async (req, res) => {
    const errors = validationResult(req);
    if (!errors.isEmpty()) {
      return res.status(400).json(errors.array());
    }
    let id = req.params.travelId
    try {
      await travelModel.updatedTravel(id, req.body);
      const updatedTravel = await travelModel.getOneTravelById(id);
      res.status(200).json(updatedTravel);
    } catch (error) {
      res.json({ error: error.message });
    };
  });


// Peticiones Delete -------------------------------------------

router.delete('/:travelId', async (req, res) => {
  let id = req.params.travelId
  try {
    const response = await travelModel.getOneTravelById(id)
    console.log(response);
    if (!response) {
      res.json({ mensaje: 'No existe el viaje seleccionado' })
    } else {
      await travelModel.deleteTravel(id)
      res.status(200).json({ mensaje: 'Viaje Eliminado' });
    }
  } catch (error) {
    res.json({ error: error.message })
  };

});











module.exports = router;