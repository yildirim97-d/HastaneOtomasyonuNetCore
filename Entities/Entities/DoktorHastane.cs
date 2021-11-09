using AppCore.Records.Bases;

namespace Entities.Entities
{
    public class DoktorHastane : RecordBase
    {
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
        public int HastaneId { get; set; }
        public Hastane Hastane { get; set; }
    }
}
