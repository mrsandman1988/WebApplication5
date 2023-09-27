using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class Phone
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Price { get; set; }
        public string FileName { get; set; }
    }

    public class PhoneDbContext:DbContext
    {
        public DbSet<Phone> Phones { get; set;}

        public PhoneDbContext(DbContextOptions<PhoneDbContext> opt) :base(opt) 
        { }
    }
}
