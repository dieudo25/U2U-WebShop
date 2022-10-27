using WebShop.Core.Entities;
using WebShop.Core.Services;
using WebShop.Core.Utils;

namespace WebShop.MVC.ViewModels.Home
{
    public class HomeIndexVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal UnitPrice { get; set; }
        public string Seller { get; set; }
        public int Rating { get; set; }
        public int RatingStar 
        { 
            get
            {
                return Rating * 20;
            }
        }
        public ProductCategory Category { get; set; }
        public (string, string) Badge { get; set; }

    }
}