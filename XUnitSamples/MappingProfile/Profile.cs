using XUnitSamples.Models;

namespace XUnitSamples.MappingProfile
{
    public class Profile : AutoMapper.Profile
    {
        public Profile()
        {
            CreateMap<Core.Entities.Address, AddressModel>();
            CreateMap<Core.Entities.Person, PersonModel>();
        }
    }
}
