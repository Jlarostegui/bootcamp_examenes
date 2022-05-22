const { query, queryOne } = require('../helpers');


const getAllPackages = () => {
  return query('SELECT * FROM paquetes');
};

const getOnePackageById = (packageId) => {
  return queryOne('SELECT * FROM paquetes WHERE id = ?', [packageId]);
};

const createNewPackage = ({ ciudad, latitud, longitud, pais, presentacion }) => {
  return query('INSERT INTO paquetes (ciudad, latitud, longitud, pais, presentacion) VALUES(?,?,?,?,?)', [ciudad, latitud, longitud, pais, presentacion]);
};

const updatedPackage = (packageId, { ciudad, latitud, longitud, pais, presentacion }) => {
  return queryOne('UPDATE paquetes SET ciudad = ?, latitud = ?, longitud = ?, pais = ?, presentacion = ? WHERE id = ?', [ciudad, latitud, longitud, pais, presentacion, packageId]);
};

const deletePackage = (packageId) => {
  return queryOne('DELETE FROM paquetes WHERE id = ?', [packageId]);
};



module.exports = { getAllPackages, getOnePackageById, createNewPackage, updatedPackage, deletePackage };