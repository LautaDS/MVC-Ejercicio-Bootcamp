using System.ComponentModel.DataAnnotations;
namespace MVC1.Models
{
    public class Automovil
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Marca es obligatorio")]
        string marca;
        [Required(ErrorMessage = "El campo Modelo es obligatorio")]
        string model;
        [Required(ErrorMessage = "El campo Año es obligatorio")]
        int año;
        int kilometros;
        int precio;

        public Automovil()
        {
            Id = 0;
            marca = "";
            model = "";
            año = 0;
        }

        public Automovil(int id, string marca, string model, int año, int kilometros, int precio)
        {
            Id = id;
            this.marca = marca;
            this.model = model;
            this.año = año;
            this.kilometros = kilometros;
            this.precio = precio;
        }

        public Automovil(int id, string marca, string model, int año)
        {
            Id = id;
            this.marca = marca;
            this.model = model;
            this.año = año;
        }

        public string Marca { get => marca; set => marca = value; }
        public string Model { get => model; set => model = value; }
        public int Año { get => año; set => año = value; }
        public int Kilometros { get => kilometros; set => kilometros = value; }
        public int Precio { get => precio; set => precio = value; }

    }
}
