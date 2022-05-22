const { query, queryOne } = require('../helpers')

queryViaje = `SELECT v.*
FROM agencia_de_viajes.tbi_clientes_viajes as tbi 
JOIN agencia_de_viajes.paquetes as p ON p.id = tbi.paquetes_id
JOIN agencia_de_viajes.viajes as v ON v.id = tbi.viaje_id
JOIN agencia_de_viajes.clientes as c ON c.id = tbi.cliente_id
WHERE c.id = ?;`


const getAllClients = () => {
  return query('SELECT * FROM clientes');
};

const getOneClientById = (clientId) => {
  return queryOne('SELECT * FROM clientes WHERE clientes.id = ? ', [clientId]);
};

const createNewClient = ({ nombre, apellidos, direccion, telefono, fecha_nacimiento, dni, email }) => {
  return query('INSERT INTO clientes (nombre, apellidos, direccion, telefono, fecha_nacimiento, dni, email) VALUES(?,?,?,?,?,?,?)', [nombre, apellidos, direccion, telefono, fecha_nacimiento, dni, email]);
};

const updateClient = (clientId, { nombre, apellidos, direccion, telefono, fecha_nacimiento, dni, email }) => {
  return queryOne('UPDATE clientes  SET nombre = ?, apellidos = ?, direccion = ?, telefono = ?, fecha_nacimiento = ?, dni = ?,  email = ?  WHERE id = ?',
    [nombre, apellidos, direccion, telefono, fecha_nacimiento, dni, email, clientId]);
};

const deleteClient = (clientId) => {
  return queryOne('DELETE FROM clientes WHERE id = ?', [clientId]);
};

const detailClient = (clientId) => {
  return queryOne(queryViaje, [clientId])
}







module.exports = { getAllClients, getOneClientById, createNewClient, updateClient, deleteClient, detailClient };