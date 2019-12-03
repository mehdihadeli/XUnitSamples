using System;
using Xunit;
using XUnitSamples.Core.Entities;

namespace XUnitSamples.Test
{
    public class PersonTests
    {
        [Fact]
        public void IsActive_WhenSet_RaiseIsActiveChangedEvent()
        {
            var sut = new Person();
            Assert.Raises<EventArgs>(xunitHandler => sut.ActiveStateChanged += xunitHandler,
                xunitHandler => sut.ActiveStateChanged -= xunitHandler,
                () => sut.IsActive = true
            );
        }
    }
}