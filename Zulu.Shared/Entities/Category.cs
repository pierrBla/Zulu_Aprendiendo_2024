using System.ComponentModel.DataAnnotations;

namespace Zulu.Shared.Entities
{
    public class Category
    {

        public int Id { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} caractéres")]


        public string Name { get; set; } = null!;
    }
}
