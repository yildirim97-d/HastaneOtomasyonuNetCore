using AppCore.Records.Bases;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class Doktor : RecordBase
    {

       
        [StringLength(50)]
        [Required]
        public string DoktorAdi { get; set; }
        [StringLength(50)]
        [Required]
        public string DoktorSoyadi { get; set; }
        [StringLength(11)]
        [Required]
        public string DoktorTcNo { get; set; }
        public List<DoktorHastane> doktorHastaneler { get; set; }

    }
}
