using WebShop.Core.Entities;
using WebShop.Core.Repositories;
using WebShop.Core.Services;

namespace WebShop.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ISessionService _sessionService;
        private readonly WebShopDbContext _db;

        public ProductRepository()
        {
        }

        public ProductRepository(ISessionService sessionService, WebShopDbContext db) : this()
        {
            _db = db;
            _sessionService = sessionService;
        }

        public Product? GetProductWithId(int id)
        {
            using (var context = _db)
            {
                return context.Products.Find(id);
            }
        }

        public IEnumerable<Product> WithFilter()
        {
            using (var context = _db)
            {
                var filter = _sessionService.GetFilter();

                var list = context.Products;

                if (filter.minAmount is not null || filter.maxAmount is not null)
                {
                    list.Where(p => p.UnitPrice >= filter.minAmount)
                        .Where(p => p.UnitPrice <= filter.maxAmount);
                }
                

                if (filter.category != ProductCategory.All)
                {
                    list.Where(p => p.Category == filter.category);
                }

                var filteredList = list.ToList();
                return filteredList;
            }
        }
    }
}
