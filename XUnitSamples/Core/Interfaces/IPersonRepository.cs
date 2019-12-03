using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XUnitSamples.Core.Entities;

namespace XUnitSamples.Core.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
    }
}
