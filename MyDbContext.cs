using Microsoft.EntityFrameworkCore;
using personsDBdemo;

public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
}