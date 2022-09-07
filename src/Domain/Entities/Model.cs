namespace Domain.Entities;

public class Model : BaseEntity
{
     #region ctor

     public Model()
     {

     }

     public Model(int id, int brandId, DateTime createdDate, string name, decimal dailyPrice)
     {
          Id = id;
          BrandId = brandId;
          CreatedDate = createdDate;
          Name = name;
          DailyPrice = dailyPrice;
     }

     #endregion

     #region Properties

     public string Name { get; set; }
     public decimal DailyPrice { get; set; }
     public string? ImageUrl { get; set; }

     public int BrandId { get; set; }
     public Brand Brand { get; set; }


     #endregion
}
