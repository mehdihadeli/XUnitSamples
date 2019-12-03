using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XUnitSamples.Core.Entities;
using XUnitSamples.Core.Interfaces;
using XUnitSamples.Infrastructure.ApplicationContext;

namespace XUnitSamples.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context)
        {
        }
    }
}
