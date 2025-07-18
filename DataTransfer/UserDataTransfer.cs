namespace Biogenom.DataTransfer
{
    public class UserDataTransfer
    {
        public int Id { get; set; }
        public string FullName { get; set; } // Полное имя
        public DateTime BirthDate { get; set; } 
        public int? Height { get; set; } 
        public decimal? Weight { get; set; } 
        public string ActivityLevel { get; set; } 
    }
}
