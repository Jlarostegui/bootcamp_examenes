namespace examen.Entidades
{
    public class Adosado : Vivienda
    {
        public bool Piscina { get; set; }


        public Adosado(string name, int size, int numrooms, int numbath, bool pool, int municipioid)
        {
            Name = name;
            Size = size;
            NumRooms = numrooms;
            NumBath = numbath;
            Piscina = pool;
            MunicipioId = municipioid;
        }

        public static List<Adosado> GetAdosados()
        {
            return new List<Adosado>()
            {
                new Adosado("Adosado1",160,3,3,true,1),
                new Adosado("Adosado2",170,4,2,false,2),
                new Adosado("Adosado3",180,5,3,true,3),
                new Adosado("Adosado4",190,5,2,false,4),
            };

        }

    }
}
