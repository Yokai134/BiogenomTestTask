using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class Users
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PatronomycName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public decimal Weight { get; set; }
        public virtual ICollection<ProductConsumption> ProductConsumptions { get; set; } = new List<ProductConsumption>();
        public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();
        public virtual ICollection<UserSupplement> UserSupplements { get; set; } = new List<UserSupplement>();
    }
}
