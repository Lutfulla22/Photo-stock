using Microsoft.EntityFrameworkCore;
using Test.Entities;

namespace Test.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) 
            :base(options) { }
        public DbSet<Author> Author { get; set; }
            
        public DbSet<Photos> Photo { get; set; }
        
        public DbSet<Media> Medias { get; set; }
    }
}