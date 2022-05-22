using examen.Clases;
MetodosInmobiliaria inmobiliaria = new MetodosInmobiliaria();

//01- Mostar los Municipios :
Console.WriteLine("Disponemos de viviendas en los siguientes municipios:");
inmobiliaria.PrintMunicipios();
Console.WriteLine();

//02- Mostrar Los Pisos y sus Municipios:
Console.WriteLine("Estos son los pisos que disponemos en cada localidad: ");
inmobiliaria.PrintListMunicipioPisos();
Console.WriteLine();

//03- Mostrar los Adosados y sus Municipios:
Console.WriteLine("Estos son los adosados que disponemos en cada localidad: ");
inmobiliaria.PrintListMunicipioAdosados();
Console.WriteLine();

//04 - Filtrar pisos por Nombre de Municipio:
Console.WriteLine("En la localidad indicada disponemos de: ");
inmobiliaria.PrintListMunicipioPisos("Cadiz");
Console.WriteLine();

//05 - filtrar Adosados por Nombre de Municipio
Console.WriteLine("En la localidad indicada disponemos de");
inmobiliaria.PrintListMunicipioAdosados("Cadiz");
Console.WriteLine();

//06- Imprimir Pisos con mas de 3 habitaciones.
Console.WriteLine("Estos son los pisos con 3 o mas habitaciones");
inmobiliaria.PrintListPisosRooms();
Console.WriteLine();

//07- Impirmir Adosados con mas de 4 habitaciones.
Console.WriteLine("Estos son los adosados con 4 o mas habitaciones");
inmobiliaria.PrintListAdosadosRooms();
Console.WriteLine();

//08- Imprimir Adosados con piscina 
Console.WriteLine("Estos son los adosados que tenemos con piscina:");
inmobiliaria.PrintAdosadosConpiscina();
Console.WriteLine();

//09- Imprimir Pisos con mas de 105 metros
Console.WriteLine("Estos son los piso que tenemos 105 o mas mestros ");
inmobiliaria.PrintListPisosSize();
Console.WriteLine();

//10- Imprimir Adosados con mas de 170 metros
Console.WriteLine("Estos son los adosados que tenemos con 170 o mas metros");
inmobiliaria.PrintListAdosadosSize();
