using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.Models
{
    public class Book
    {
        [Key] //atributo
        public int Id { get; set; }

        [Required(ErrorMessage = "El Título es obligatorio")]
        //[StringLength(30, MinimumLength =5, ErrorMessage ="El Titulo debe tener entre 5 y 30 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria")]
        //[StringLength(150, MinimumLength = 5, ErrorMessage = "La Descripción debe tener entre 5 y 150 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El Autor es obligatorio")]
        public string Author { get; set; }

        [Required(ErrorMessage = "La Cantidad de Páginas es obligatoria")]
        //[Range(1,1000, ErrorMessage ="La cantidad de Paginas deden ser de mínimo 1 y Máximo 1000")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        //[Range(1, 10000, ErrorMessage ="El precio no puede ser negativo")]
        public int Price { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
