namespace WebShop.Core.Entities; 

public class EntityBase 
{ 
    public int Id { get; } 
    public EntityBase(int id) => Id = id; 
}