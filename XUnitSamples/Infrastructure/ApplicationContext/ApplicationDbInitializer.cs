using System.Linq;
using Bogus;
using Bogus.DataSets;
using XUnitSamples.Core.Entities;
using Address = XUnitSamples.Core.Entities.Address;

namespace XUnitSamples.Infrastructure.ApplicationContext
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            SeedPersons(context);
        }

        private static void SeedPersons(ApplicationDbContext context)
        {
            if (context.Persons.Any())
                return;

            var addressId = 1;
            var addressFaker = new Faker<Address>()
                .RuleFor(x => x.Id, f => addressId++)
                .RuleFor(x => x.Value, f => f.Address.FullAddress());

            var personId = 1;
            var personFaker = new Faker<Core.Entities.Person>()
                .RuleFor(o => o.Id, f => personId++)
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName((Name.Gender?) u.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName((Name.Gender?) u.Gender))
                .RuleFor(x => x.Addresses, (f, u) => addressFaker.Generate(2).ToList())
                .FinishWith((f, u) => u.Addresses.ToList().ForEach(x => x.PersonId = u.Id));
            var personsToSeed = personFaker.Generate(20).ToList();

            context.Persons.AddRange(personsToSeed);

            context.SaveChanges();
        }
    }
}
