using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Core.Entities
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Local { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public IEnumerable<Team> Teams { get; set; }
        public int UserId { get; set; }
    }
}
