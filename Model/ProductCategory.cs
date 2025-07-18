using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string NameCategories { get; set; }
        public virtual ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();
    }
}
