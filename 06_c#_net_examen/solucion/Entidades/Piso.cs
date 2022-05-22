namespace examen.Entidades
{
    public class Piso : Vivienda
    {
        public int NunFloor { get; }

        public Piso(string name, int size, int numrooms, int numbath, int numfloor, int municipioid)
        {
            Name = name;
            Size = size;
            NumRooms = numrooms;
            NumBath = numbath;
            NunFloor = numfloor;
            MunicipioId = municipioid;
        }


        public static List<Piso> GetPisos()
        {
            return new List<Piso>
            {
                new Piso("Piso1", 90,2,2,2,1),
                new Piso("Piso2", 105,4,2,1,2),
                new Piso("Piso3", 85,3,2,3,3),
                new Piso("Piso4", 150,5,2,4,4),
            };

        }




    }
}
