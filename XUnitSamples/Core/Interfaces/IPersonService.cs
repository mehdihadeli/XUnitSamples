using System.Collections.Generic;
using XUnitSamples.Core.Entities;
using XUnitSamples.Models;

namespace XUnitSamples.Core.Interfaces
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> AllPersons();
        PersonModel FindPerson(int id);
    }
}