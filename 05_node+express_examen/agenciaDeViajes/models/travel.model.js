const { query, queryOne } = require('../helpers');


const getAllTravel = () => {
  return query('SELECT * FROM viajes');
};

const getOneTravelById = (traveId) => {
  return queryOne('SELECT * FROM viajes WHERE id = ?', [traveId]);
};

const createNewTravel = ({ ida, vuelta, hotel, direccion, seguro }) => {
  return query('INSERT INTO viajes (ida, vuelta, hotel, direccion, seguro) VALUES(?,?,?,?,?)', [ida, vuelta, hotel, direccion, seguro]);
};

const updatedTravel = (TravelId, { ida, vuelta, hotel, direccion, seguro }) => {
  return queryOne('UPDATE viajes SET ida = ?, vuelta = ?, hotel = ?, direccion = ?, seguro = ? WHERE id = ?', [ida, vuelta, hotel, direccion, seguro, TravelId]);
};

const deleteTravel = (TravelId) => {
  return queryOne('DELETE FROM viajes WHERE id = ?', [TravelId]);
};



module.exports = { getAllTravel, getOneTravelById, createNewTravel, updatedTravel, deleteTravel };