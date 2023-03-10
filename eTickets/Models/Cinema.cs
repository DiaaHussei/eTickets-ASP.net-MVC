using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema: IEntityBaseRepostory
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Cinema logo")]
        [Required(ErrorMessage ="The logo is requiter") ]
        public string Logo { get; set; }
        [Display(Name = "Cinema Name")]
        [Required(ErrorMessage = "The Nem is required")]
        public string Name { get; set; }
        [Display(Name = "Descritpion")]
        [Required(ErrorMessage = "The Descritiption is required")]
        public string Descritpion { get; set; }

        //Relationship
        public List<Movie> Movies { get; set; }
    }
}
