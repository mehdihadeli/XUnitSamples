using System;
using System.Collections.Generic;
using XUnitSamples.Core.Entities;

namespace XUnitSamples.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public Gender Gender { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public IEnumerable<AddressModel> Addresses { get; set; }
    }
}