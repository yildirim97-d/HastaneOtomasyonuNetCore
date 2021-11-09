using AppCore.Records.Bases;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class DoktorHastaneModel : RecordBase
    {
        public Doktor Doktor { get; set; }
        public Hastane Hastane { get; set; }
        public int DoktorId { get; set; }
        public int HastaneId { get; set; }
    }
}
