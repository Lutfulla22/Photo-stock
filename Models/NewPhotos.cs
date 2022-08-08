using Test.Entities;

namespace Test.Models
{
    public class NewPhotos
    {
        public string Name { get; set; }
        
        public IEnumerable<Guid> MediasId { get; set; }
                
        public IEnumerable<Guid> AuthorId { get; set; }
        
        public int Cost { get; set; }
        
        public int Sales { get; set; }
    }
}