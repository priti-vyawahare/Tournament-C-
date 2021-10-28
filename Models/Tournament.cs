using System;
namespace ChessTournament.Models
{
    public class Tournament
    {
        public string Name { get; set; }
        public string Location{ get;set; }
        public string Category { get;set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Website{ get;set; }
    }
}