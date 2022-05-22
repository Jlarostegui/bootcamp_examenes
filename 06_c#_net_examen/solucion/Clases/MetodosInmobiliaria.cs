using examen.Entidades;

namespace examen.Clases
{
    public class MetodosInmobiliaria
    {

        #region Carga Listados
        public List<Municipio> ListadoDeMunicipios = Municipio.GetMunicipios();
        public List<Piso> ListadoPisos = Piso.GetPisos();
        public List<Adosado> ListadoAdosados = Adosado.GetAdosados();
        #endregion

        #region QueryPisos
        private List<PisoExtendido> queryPisos(string? filterText = null, int? filterHab = null, int? filterSize = null)
        {
            var query =
                from piso in ListadoPisos
                join municipio in ListadoDeMunicipios on piso.MunicipioId equals municipio.Id
                where filterText == null || municipio.Nombre.Contains(filterText)
                where filterHab == null || piso.NumRooms >= filterHab
                where filterSize == null || piso.Size >= filterSize
                orderby piso.NumRooms ascending
                select new PisoExtendido
                {
                    Nombre = piso.Name,
                    Localidad = municipio.Nombre,
                    Habitaciones = piso.NumRooms,
                    Tamaño = piso.Size
                };
            List<PisoExtendido> result = query.ToList();
            if(result.Count <= 0)
                    Console.WriteLine($"No disponemos ningún piso");
            return result;
        }
        #endregion

        #region QueryAdosados
        private List<AdosadoExtendido> queryAdosados(string? filterText = null, int? filterHab = null, bool piscina = false,int? filterSize = null)
        {
            var query =
                from adosado in ListadoAdosados
                join municipio in ListadoDeMunicipios on adosado.MunicipioId equals municipio.Id
                where filterText == null || municipio.Nombre.Contains(filterText)
                where filterHab == null || adosado.NumRooms >= filterHab
                where piscina == false || adosado.Piscina.Equals(piscina)
                where filterSize == null || adosado.Size >= filterSize

                select new AdosadoExtendido
                {
                    Nombre = adosado.Name,
                    Localidad = municipio.Nombre,
                    Habitaciones = adosado.NumRooms,
                    Piscina = adosado.Piscina,
                    Size = adosado.Size
                };
            List<AdosadoExtendido> result = query.ToList();
            if (result.Count <= 0)
                Console.WriteLine($"No disponemos ningún adosado");
            return result;
        }
        #endregion

        #region MetodosMunicipios
        public void PrintMunicipios()
        {

            foreach (Municipio municipio in ListadoDeMunicipios)
            {
                Console.WriteLine($"{municipio.Nombre}");
            }
        }
        #endregion

        #region Metodos Pisos
        public void PrintListMunicipioPisos(string? filter = null)
        {
            if (filter == "")
            {
                Console.WriteLine("Debes de incluir un parametro de busqueda");
                return;
            }

            List<PisoExtendido> listadopisosfiltrado = queryPisos(filter);

       

            if (filter == null)
            {
                foreach (PisoExtendido piso in listadopisosfiltrado)
                {
                    Console.WriteLine($"El {piso.Nombre} esta situado en {piso.Localidad} ");
                }

            }
            else
            {
                foreach (PisoExtendido piso in listadopisosfiltrado)
                {
                    Console.WriteLine($"En {filter} Tenemos el {piso.Nombre} ");
                }

            }

        }

        public void PrintListPisosRooms(int? filterHab = 3)
        {
            List<PisoExtendido> listadopisosfiltrado = queryPisos(filterHab:filterHab);
            foreach (PisoExtendido piso in listadopisosfiltrado)
            {
                Console.WriteLine($"El piso {piso.Nombre} tiene {piso.Habitaciones} habitaciones");
            }

        }

        public void PrintListPisosSize(int? size = 105)
        {
            List<PisoExtendido> listadopisosfiltrado = queryPisos(filterSize:size);
            foreach (PisoExtendido piso in listadopisosfiltrado)
            {
                Console.WriteLine($"El {piso.Nombre} tiene {piso.Tamaño} metros");
            }

        }

        #endregion

        #region Metodos Adosados
        public void PrintListMunicipioAdosados(string? filter = null)
        {
            if (filter == "")
            {
                Console.WriteLine("Debes de incluir un parametro de busqueda");
                return;
            }

            List<AdosadoExtendido> listadoAdosadosfiltrado = queryAdosados(filter);

            if (filter == null)
            {
                foreach (AdosadoExtendido adosado in listadoAdosadosfiltrado)
                {
                    Console.WriteLine($"El {adosado.Nombre} esta situado en {adosado.Localidad} ");
                }
            }
            else
            {
                foreach (AdosadoExtendido adosado in listadoAdosadosfiltrado)
                {
                    Console.WriteLine($"En {filter} Tenemos el {adosado.Nombre} ");
                }

            }



        }

        public void PrintListAdosadosRooms(int? filterHab = 4)
        {
            List<AdosadoExtendido> listadoadosados = queryAdosados(filterHab: filterHab);
            foreach (AdosadoExtendido adosado in listadoadosados)
            {
                Console.WriteLine($"El adosado {adosado.Nombre} tiene {adosado.Habitaciones} habitaciones");
            }

        }

        public void PrintAdosadosConpiscina(bool si = true)
        {
            List<AdosadoExtendido> listadoadosados = queryAdosados(piscina:si) ;
            foreach (AdosadoExtendido adosado in listadoadosados)
            {
                Console.WriteLine($"El adosado {adosado.Nombre} tiene piscina");
            }
        }

        public void PrintListAdosadosSize(int? size = 170)
        {
            List<AdosadoExtendido> listaAdosadoFiltrado = queryAdosados(filterSize: size);
            foreach (AdosadoExtendido adosado in listaAdosadoFiltrado)
            {
                Console.WriteLine($"El {adosado.Nombre} tiene {adosado.Size} metros");
            }

        }

        #endregion
    }
}
