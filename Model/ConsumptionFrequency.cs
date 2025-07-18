using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class ConsumptionFrequency
    {
        public int Id { get; set; }
        public string NameFrequencies { get; set; }
        public virtual ICollection<ProductConsumption> ProductConsumptions { get; set; } = new List<ProductConsumption>();
    }
}
