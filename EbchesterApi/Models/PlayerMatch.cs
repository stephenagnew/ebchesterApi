using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EbchesterApi.Models
{
    public class PlayerMatch
    {
        public int Appearance { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int MoM { get; set; }
    }
}
