using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using XUnitSamples.Core.Entities;
using Address = XUnitSamples.Core.Entities.Address;
using Person = XUnitSamples.Core.Entities.Person;

namespace XUnitSamples.Infrastructure.ApplicationContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }
    }
}