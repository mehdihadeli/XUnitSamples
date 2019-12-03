using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using XUnitSamples.Core.Entities;
using XUnitSamples.Core.Interfaces;
using XUnitSamples.Models;
using Microsoft.EntityFrameworkCore;
namespace XUnitSamples.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PersonService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _uow = iUnitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<PersonModel> AllPersons()
        {
            var repo = _uow.GetRepository<Person>();
            var res = repo.GetAll(x => x.Include(i => i.Addresses)).OrderBy(x => x.DateOfBirth);
            return _mapper.ProjectTo<PersonModel>(res);
        }

        public PersonModel FindPerson(int id)
        {
            var repo = _uow.GetRepository<Person>();
            var model = repo.GetAll().FirstOrDefault(x => x.Id == id);
            return _mapper.Map<PersonModel>(model);
        }
    }
}
