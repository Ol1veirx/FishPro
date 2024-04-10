using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishPro.Core.Entities
{
    public class Result
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public int TeamId { get; set; }
        public int Sector {  get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
        public decimal Punctuation { get; set; }
    }
}
