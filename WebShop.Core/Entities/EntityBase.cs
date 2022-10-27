namespace WebShop.Core.Entities; 

public class EntityBase 
{ 
    public int Id { get; set; }

    public EntityBase(int id) : base() => Id = id; 
}