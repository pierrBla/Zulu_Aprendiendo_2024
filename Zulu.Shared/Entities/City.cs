using System.ComponentModel.DataAnnotations;

namespace Zulu.Shared.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede tener mas de {1} caractéres")]


        public string Name { get; set; } = null!;


        //para poner una relacion
        public int StateId { get; set; }

        public State? State { get; set; }




    }
}
