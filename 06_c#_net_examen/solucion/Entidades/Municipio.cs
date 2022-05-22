namespace examen.Entidades
{
    public class Municipio
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public Municipio(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public static List<Municipio> GetMunicipios()
        {
            return new List<Municipio>
            {
                new Municipio(1,"Cadiz"),
                new Municipio(2,"Malaga"),
                new Municipio(3,"Sevilla"),
                new Municipio(4,"Almeria")
            };
        }


    }
}

