namespace Test.Entities
{
    public class Photos
    {
        

        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Media> Medias { get; set; }
        
        public DateTime CreatedAt { get; set; } = new DateTime();
        
        public ICollection<Author> Author { get; set; }
        
        public int Cost { get; set; }
        
        public int Sales { get; set; }

        [Obsolete("Used only for Entities binding.", true)]
        public Photos() { }

        public Photos(string name, IEnumerable<Media> medias, DateTime createdAt, ICollection<Author> author, int cost, int sales)
        {
            Id = Guid.NewGuid();
            Name = name;
            Medias = medias;
            CreatedAt = createdAt = DateTime.Today;
            Author = author;
            Cost = cost;
            Sales = sales;
        }
    }
}