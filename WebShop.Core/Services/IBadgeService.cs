using WebShop.Core.Entities;

namespace WebShop.Core.Services;

public interface IBadgeService
{
    (string, string) GetInfo(Product product);
}
