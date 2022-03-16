using System.ComponentModel.DataAnnotations;

namespace BookAPI.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} precisa conter entre {2} a {1} caracteres")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório!")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Campo {0} precisa conter entre {2} a {1} caracteres")]
        public string Title { get; set; }

        [StringLength(200, MinimumLength = 2, ErrorMessage = "Campo {0} precisa conter entre {2} a {1} caracteres")]
        public string Description { get; set; }       
    }
}
