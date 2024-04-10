using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Application.Services.DTO
{
    public class StageDTO
    {
        public int Id { get; set; }
        public string StageNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime StageDate { get; set; }
        public int TournamentId { get; set; }
    }
}
