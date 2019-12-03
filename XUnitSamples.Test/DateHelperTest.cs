using System;
using Xunit;

namespace XUnitSamples.Test
{
    public class DateHelperTest
    {
        [Fact]
        public void TimeOfDay_InputIsBetween6And12_ReturnMorning()
        {
            //arrange
            var sut = new DateHelper();
            //act
            var result = sut.GetTimeOfDay(TimeSpan.FromHours(7));
            //assert
            Assert.Equal("Morning", result);

            Assert.StartsWith("M", result);
            Assert.EndsWith("g", result);
            Assert.Equal("morning", result, true);
            Assert.Contains("orn", result);
        }

        [Fact]
        public void TimeOfDay_InputIsHigherThan24_ReturnNull()
        {
            //arrange
            var sut = new DateHelper();
            //act
            var result = sut.GetTimeOfDay(TimeSpan.FromHours(25));
            //assert
            Assert.Null(result); //should pass
            Assert.NotNull(result); //should fail
        }

        [Fact]
        public void TimeOfDay_InputIsLowerThan24_ReturnNotNull()
        {
            //arrange
            var sut = new DateHelper();
            //act
            var result = sut.GetTimeOfDay(TimeSpan.FromHours(25));
            //assert
            Assert.NotNull(result); //should pass
            Assert.Null(result); //should fail
        }

        [Fact]
        public void TestSameReferenceOfTwoObjects()
        {
            var dateHelper1 = new DateHelper();
            var dateHelper2 = dateHelper1;
            Assert.Same(dateHelper1, dateHelper2);
        }

        [Fact]
        public void TestNotSameReferenceOfTwoObjects()
        {
            var dateHelper1 = new DateHelper();
            var dateHelper2 = new DateHelper();
            Assert.NotSame(dateHelper1, dateHelper2);
        }
    }
}