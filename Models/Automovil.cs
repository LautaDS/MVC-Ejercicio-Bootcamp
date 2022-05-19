namespace MVC1.Models
{
    public class Automovil
    {
        public int Id { get; set; }
   
        string marca;
        string model;
        int año;
        int kilometros;
        double precio;

        public string Marca { get => marca; set => marca = value; }
        public string Model { get => model; set => model = value; }
        public int Año { get => año; set => año = value; }
        public int Kilometros { get => kilometros; set => kilometros = value; }
        public double Precio { get => precio; set => precio = value; }

    }
}
