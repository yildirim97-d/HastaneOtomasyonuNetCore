using AppCore.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Business.Models
{
   public class DoktorModel : RecordBase
    {

        [DisplayName("Doktor Adı")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        public string DoktorAdi { get; set; }
        [DisplayName("Doktor Soyadı")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        public string DoktorSoyadi { get; set; }
        [DisplayName("Doktor Tc No")]
        [Required(ErrorMessage = "{0} Boş geçilemez!")]
        public string DoktorTcNo { get; set; }
    }
}
