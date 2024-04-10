using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Core.Entities
{
    public class Participation
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
    }
}
