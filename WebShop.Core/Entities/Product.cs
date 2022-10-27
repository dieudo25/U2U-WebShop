namespace WebShop.Core.Entities
{
    public class Product : EntityBase
    {
        public Product(int id) : base(id) {}

        public Product(int id, string name, string seller, string image, decimal unitPrice, int rating, int discount, ProductCategory category) : this(id)
        {
            Name = name;
            Seller = seller;
            Image = image; 
            UnitPrice = unitPrice; 
            Rating = rating;
            Discount = discount;
            Category = category;
            CreatedAt = DateTime.Now;
        }

        public string? Name { get; set; }

        public string? Seller { get; set; }

        public string? Image { get; set; }

        public ProductCategory Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        private decimal unitPrice;
        public decimal UnitPrice
        {
            get { return unitPrice; }
            set 
            { 
                if(value >= 0)
                {
                    unitPrice = value;
                }
            }
        }

        private int rating;
        public int Rating
        {
            get { return rating; }
            set 
            {
                if(value > 0 && value <= 5)
                {
                    rating = value;
                }   

            }
        }

        private int discount;
        public int Discount
        {
            get { return discount; }
            set
            {
                if (value > 0 && value < 100)
                {
                    discount = value;
                }
                else
                {
                    discount = 0;
                }
            }
        }

        public int GetRatingByHundred()
        {
            return Rating * 20;
        }
    }
}
