using WebShop.Core.Entities;
using WebShop.Core.Utils;

namespace WebShop.MVC.ViewModels.Home
{
    public class HomeIndexVM
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<ProductCategory>? Categories 
        {
            get
            {
                return EnumUtil.GetValues<ProductCategory>();
            }
        }

    }
}