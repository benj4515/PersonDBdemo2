using Microsoft.EntityFrameworkCore;
using personsDBdemo;

namespace Infrasctructure.Postgres.Scaffolding;

public class MyDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }
}