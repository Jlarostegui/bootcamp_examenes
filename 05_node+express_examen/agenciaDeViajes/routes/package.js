const router = require('express').Router();
const packageModel = require('../models/packages.model');

router.get('/', async (req, res) => {
  const arrPackage = await packageModel.getAllPackages();
  res.render('packages/listaPackage', { arrPackage });
});

router.get('/newPackage', (req, res) => {
  res.render('packages/newPackage')
});

router.get('/update/:packageId', async (req, res) => {
  const package = await packageModel.getOnePackageById(req.params.packageId)
  res.render('packages/editPackage', { package });
});


router.get('/delete/:packageId', async (req, res) => {
  await packageModel.deletePackage(req.params.packageId);
  res.redirect('/lista');
});


router.post('/create', async (req, res) => {
  await packageModel.createNewPackage(req.body)
  res.redirect('/lista');
});

router.post('/update', async (req, res) => {
  await packageModel.updatedPackage(req.body.id, req.body);
  res.redirect('/lista');
});





module.exports = router;