using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Model
{
    public class ProductConsumption
    {
        public int Id { get; set; }
        public int UserId { get; set; } // ID пользователя
        public int ProductTypeId { get; set; } // ID типа продукта
        public int FrequencyId { get; set; } // ID частоты потребления
        public int Amount { get; set; } // Количество
        public int AmountUnitId { get; set; } // ID единицы измерения
        public Users User { get; set; } // Ссылка на пользователя
        public ProductType ProductType { get; set; } // Ссылка на тип продукта
        public ConsumptionFrequency Frequency { get; set; } // Ссылка на частоту потребления продукта
        public MeasurementUnit AmountUnit { get; set; } // Ссылка на единицы измерения продукта
    }
}
