const router = require('express').Router();
const clientsModel = require('../models/clients.model');
const dayjs = require('dayjs');
const alert = require('alert')



router.get('/', async (req, res) => {
  const arrClients = await clientsModel.getAllClients();
  res.render('clients/listaClients', { arrClients });
});

router.get('/newClient', (req, res) => {
  res.render('clients/newClient')
});

router.get('/update/:clientId', async (req, res) => {
  const client = await clientsModel.getOneClientById(req.params.clientId)
  client.fecha_nacimiento = dayjs(client.fecha_nacimiento).format('YYYY-MM-DD')
  console.log(client);
  res.render('clients/update', { client });
});

router.get('/delete/:clientId', async (req, res) => {
  await clientsModel.deleteClient(req.params.clientId);
  res.redirect('/clients');
});

router.get('/data/:clientId', async (req, res) => {
  id = req.params.clientId
  const travel = await clientsModel.detailClient(id);
  const client = await clientsModel.getOneClientById(id)
  if (travel) {
    travel.ida = dayjs(travel.ida).format('YYYY-MM-DD')
    travel.vuelta = dayjs(travel.vuelta).format('YYYY-MM-DD')
    res.render('clients/travel', { travel, client })
  } else {
    alert('Este cliente no tiene ningún viaje contratado');
  }

});

router.post('/create', async (req, res) => {
  await clientsModel.createNewClient(req.body)
  res.redirect('/clients');
});


router.post('/update', async (req, res) => {
  await clientsModel.updateClient(req.body.id, req.body);
  res.redirect('/clients');
});






module.exports = router;