using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Test.Entities
{
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        
        public string FirstName { get; set; } = string.Empty;
        
        public string LastName { get; set; } = string.Empty;
        
        public string NickName { get; set; } = string.Empty;
        public DateTimeOffset DoB { get; set; }
        
        public DateTimeOffset RegDate { get; set; }
         
        [Obsolete("Used only for Entities binding.", true)]
        public Author() { }
        public Author(string firstName, string lastName, string nickName, DateTimeOffset doB)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            DoB = doB;
            RegDate = DateTime.UtcNow;
        }
    }
}