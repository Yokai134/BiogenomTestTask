using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class ProductType
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } // ID категории
        public string NameProduct { get; set; }
        public virtual ProductCategory Category { get; set; } // Ссылка на категорию продукта
        public virtual ICollection<ProductConsumption> ProductConsumptions { get; set; } = new List<ProductConsumption>();
    }
}
