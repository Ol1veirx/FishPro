using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FishPro.Core.Entities;

namespace FishPro.Application.Services.DTO
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Result> Results { get; set; }

        public int TournamentId { get; set; }
    }
}
