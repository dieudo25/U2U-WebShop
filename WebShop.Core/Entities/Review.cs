namespace WebShop.Core.Entities
{
    public class Review : EntityBase
    {
        public Review(int id) : base(id) { }

        public Review(int id, string title, string text, string user, int score) : base(id)
        {
            Title = title;
            Text = text;
            User = user;
            Score = score;
            CreatedAt = DateTime.Now;
        }

        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public int Score { get; set; }
        public DateTime CreatedAt { get; }
        public Product Product { get; set; }
    }
}
