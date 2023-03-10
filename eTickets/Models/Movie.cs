using eTickets.Data;
using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class Movie: IEntityBaseRepostory
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public double Price { get; set; }
        public DateTime EndDate { get; set; }
        public string ImageURL { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationalship
        public List<Actor_Movie> Actor_Movies { get; set; }

        //cinem
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer { get; set; }
       // public IEnumerable<object> Actors_Movies { get; internal set; }
    }
}
