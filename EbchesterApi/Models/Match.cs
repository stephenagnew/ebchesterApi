using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Models
{
    public class Match
    {
        public ObjectId _id { get; set; }
        public int MatchId { get; set; }
        public string HomeTeam { get; set; }
        public int HomeGoals { get; set; }
        public string AwayTeam { get; set; }
        public int AwayGoals { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public List<PlayerMatch> PlayerMatchStats { get; set; }
       

    }
}
