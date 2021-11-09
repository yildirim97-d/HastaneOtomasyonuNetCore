using AppCore.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Hastane : RecordBase
    {
        [Required]
        [StringLength(100)]
        public string HastaneAdi { get; set; }
        [Required]
        [StringLength(150)]
        public string HastaneAdres { get; set; }
        public List<DoktorHastane> doktorHastaneler { get; set; }
    }
}
