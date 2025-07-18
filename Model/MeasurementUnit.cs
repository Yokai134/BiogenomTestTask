using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class MeasurementUnit
    {
        public int  Id { get; set; }
        public string NameUnit { get; set; }
        public virtual ICollection<ProductConsumption> ProductConsumptions { get; set; } = new List<ProductConsumption>();
    }
}
