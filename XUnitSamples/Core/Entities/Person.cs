using System;
using System.Collections.Generic;

namespace XUnitSamples.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }
        private bool _isActive;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                OnIsActiveChanged();
            }
        }

        public event EventHandler<EventArgs> ActiveStateChanged;

        protected virtual void OnIsActiveChanged()
        {
            ActiveStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => "${this.FirstName} {this.LastName}";
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Gender Gender { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}