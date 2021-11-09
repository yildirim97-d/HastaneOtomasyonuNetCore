using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
    public class HastaneModel : RecordBase
    {

        [DisplayName("Hastane Adı")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        public string HastaneAdi { get; set; }
        [DisplayName("Hastane Adres")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        public string HastaneAdres { get; set; }
    }
}
