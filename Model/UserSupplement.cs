using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class UserSupplement
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public int UserId { get; set; }
        [Column("supplementid")]
        public int SupplementId { get; set; }

        public Users User { get; set; } // Ссылка на пользователя
        public Supplement Supplement { get; set; } // Ссылка на добавки
    }
}
