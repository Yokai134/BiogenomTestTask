using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class ActivityLevel
    {
        public int Id { get; set; }
        public string NameLevels { get; set; }
        public virtual ICollection<UserActivity> UserActivities { get; set; } = new List<UserActivity>();
    }
}
