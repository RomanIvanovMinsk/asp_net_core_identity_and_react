using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RomanCinema.Models
{
    public class Ticket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime BuyingDate { get; set; }
        public int TicketsCountInThisMonth { get; set; }
        public string MovieName { get; set; }
        public string MoviePoster { get; set; }
    }
}
