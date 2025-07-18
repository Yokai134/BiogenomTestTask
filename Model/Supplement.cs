using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class Supplement
    {
        public int Id { get; set; }
        public string NameSupplements { get; set; }
        public virtual ICollection<UserSupplement> UserSupplements { get; set; } = new List<UserSupplement>();
    }
}
