using WebShop.Core.Entities;

namespace WebShop.Core.Repositories;

public interface IProductRepository 
{
    IEnumerable<Product> WithFilter(); 
    Product? GetProductWithId(int id); 
}

