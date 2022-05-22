const router = require('express').Router();

const apiClientsRouter = require('./api/clients');
const apiPaquetesRouter = require('./api/packcages');
const apiViajesRouter = require('./api/travel');

router.use('/clients', apiClientsRouter);
router.use('/packages', apiPaquetesRouter);
router.use('/travel', apiViajesRouter);

module.exports = router;
