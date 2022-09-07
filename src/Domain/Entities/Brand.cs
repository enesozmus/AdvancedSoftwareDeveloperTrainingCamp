namespace Domain.Entities;

public class Brand : BaseEntity
{
     #region ctor

     public Brand()
     {

     }

     public Brand(int id, DateTime createdDate, string name) : this()
     {
          Id = id;
          CreatedDate = createdDate;
          Name = name;
     }

     #endregion

     #region Properties

     public string Name { get; set; }
     public ICollection<Model> Models { get; set; }

     #endregion
}
