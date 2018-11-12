using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Models
{
    public class Player
    {
        public ObjectId _id { get; set; }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PlayerMatch PlayerSeasonStats { get; set; }
        public List<PlayerMatch> PreviousSeasons { get; set; }
    }
}
