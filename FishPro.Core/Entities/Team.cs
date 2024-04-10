using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Core.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Result> Results { get; set; }
        public int TournamentId { get; set; }
    }
}
