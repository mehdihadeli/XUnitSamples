using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bogus;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using XUnitSamples.Controllers;
using XUnitSamples.Core.Entities;
using XUnitSamples.Core.Interfaces;
using XUnitSamples.Services;
using XUnitSamples.Models;

namespace XUnitSamples.Test
{
    public class PersonControllerTests
    {
        [Fact]
        public void GetPerson_IdIsZero_ReturnNotFound()
        {
            var service = new Mock<IPersonService>();
            service.Setup(x => x.FindPerson(It.IsAny<int>()))
                .Returns((int input) => GetPersonTestData().FirstOrDefault(x => x.Id == input));

            var sut = new PersonController(service.Object);
            var actual = sut.GetPerson(0);
            Assert.IsType<NotFoundResult>(actual);
        }

        [Fact]
        public void GetPerson_IdIsNotZero_ReturnOk()
        {
            var service = new Mock<IPersonService>();
            service.Setup(x => x.FindPerson(It.IsAny<int>()))
                .Returns((int input) => GetPersonTestData().FirstOrDefault(x => x.Id == input));

            var sut = new PersonController(service.Object);
            var actual = sut.GetPerson(1);
            Assert.NotNull(actual);
            OkObjectResult okObjectResultAssert = Assert.IsType<OkObjectResult>(actual.Result);
            Assert.IsAssignableFrom<PersonModel>(okObjectResultAssert?.Value);
        }

        [Fact]
        public void GetPersons_WhenCalled_ReturnOk()
        {
            var service = new Mock<IPersonService>();
            service.Setup(x => x.AllPersons())
                .Returns(GetPersonTestData());

            var sut = new PersonController(service.Object);
            var actual = sut.GetPersons();
            Assert.NotNull(actual);
            Assert.IsType<OkObjectResult>(actual);
            Assert.IsAssignableFrom<IEnumerable<PersonModel>>((actual as OkObjectResult)?.Value);
        }

        private IEnumerable<PersonModel> GetPersonTestData()
        {
            var addressId = 1;
            var addressFaker = new Faker<AddressModel>()
                .RuleFor(x => x.Id, f => addressId++)
                .RuleFor(x => x.Value, f => f.Address.FullAddress());
            var personId = 1;
            var personFaker = new Faker<PersonModel>()
                .RuleFor(o => o.Id, f => personId++)
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName((Bogus.DataSets.Name.Gender?) u.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName((Bogus.DataSets.Name.Gender?) u.Gender))
                .RuleFor(x => x.Addresses, (f, u) => addressFaker.Generate(2).ToList())
                .FinishWith((f, u) => u.Addresses.ToList().ForEach(x => x.PersonId = u.Id));
            var personsToSeed = personFaker.Generate(20).ToList();

            return personsToSeed;
        }
    }
}