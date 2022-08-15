namespace Domain.Entities;

public class Brand : BaseEntity
{
     #region Properties

     public string Name { get; set; }


     #endregion

     #region ctor

     public Brand()
     {

     }

     public Brand(int id, string name) : this()
     {
          Id = id;
          Name = name;
     }

     #endregion
}
