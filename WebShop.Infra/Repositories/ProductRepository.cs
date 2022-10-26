using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ISessionService _sessionService;

        public ProductRepository()
        {
            using (var context = new ProductDbContext())
            {
                var products = new List<Product>
                {
                    new Product(1, "PS5", "Amazon", "imgs/shop/thumbnail-2.jpg", 500, 4, 0, ProductCategory.Vege),
                    new Product(2, "Xbox", "Amazon", "imgs/shop/thumbnail-2.jpg", 400, 4, 20, ProductCategory.Snack),
                    new Product(3,"Switch", "Amazon", "imgs/shop/thumbnail-2.jpg", 300, 4, 0, ProductCategory.Meats),
                    new Product(4,"Dell XPS 15", "Amazon", "imgs/shop/thumbnail-2.jpg", 1500, 4, 50, ProductCategory.Meats)
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }

        public ProductRepository(ISessionService sessionService) : this()
        {
            _sessionService = sessionService;
        }

        public Product? GetProductWithId(int id)
        {
            using (var context = new ProductDbContext())
            {
                return context.Products.Find(id);
            }
        }

        public IEnumerable<Product> WithFilter()
        {
            using (var context = new ProductDbContext())
            {
                var filter = _sessionService.GetFilter();

                var list = context.Products;
                list.Where(p => p.UnitPrice >= filter.minAmount)
                    .Where(p => p.UnitPrice <= filter.maxAmount);

                if (filter.category != ProductCategory.All)
                {
                    list.Where(p => p.Category == filter.category);
                }

                return list.ToList();
            }
        }
    }
}
