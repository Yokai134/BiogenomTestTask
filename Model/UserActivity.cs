using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class UserActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ActivityLevelId { get; set; }
        public Users User { get; set; } // Ссылка на пользователя
        public ActivityLevel ActivityLevel { get; set; } // Ссылка на уровни активности
    }
}
