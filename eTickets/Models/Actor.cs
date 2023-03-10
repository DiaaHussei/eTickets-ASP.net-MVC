using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor:IEntityBaseRepostory
    {
        //the [Column("the name of the column thar we want to")]

        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture URL")]
        [Required(ErrorMessage = "The Profile Picture URL is Required ")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Full Name")]
        [Required(ErrorMessage ="The Full Name is Required")]
        public string FullName { get; set; }
        [Display(Name = "Biogrphay")]
        [Required(ErrorMessage = "The Biogrphay is Required ")]
        public string  Bio { get; set; }

        //Relationship
        public List<Actor_Movie> Actor_Movies { get; set; }


    }
}
