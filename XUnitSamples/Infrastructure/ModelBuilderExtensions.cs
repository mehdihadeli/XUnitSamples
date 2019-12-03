using System.Linq;
using Bogus;
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using XUnitSamples.Core.Entities;
using Address = XUnitSamples.Core.Entities.Address;
using Person = XUnitSamples.Core.Entities.Person;

namespace XUnitSamples.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var addressId = 1;
            var addressFaker = new Faker<Address>()
                .RuleFor(x => x.Id, f => addressId++)
                .RuleFor(x => x.Value, f => f.Address.FullAddress());

            var personId = 1;
            var personFaker = new Faker<Person>()
                .RuleFor(o => o.Id, f => personId++)
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName((Name.Gender?) u.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName((Name.Gender?) u.Gender))
                .RuleFor(x => x.Addresses, (f, u) => addressFaker.Generate(2).ToList())
                .FinishWith((f, u) => u.Addresses.ToList().ForEach(x => x.PersonId = u.Id));
            var personsToSeed = personFaker.Generate(20).ToList();

            modelBuilder.Entity<Person>().HasData(personsToSeed);
        }
    }
}