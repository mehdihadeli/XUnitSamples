using System;
using System.Linq;
using Xunit;

namespace XUnitSamples.Test
{
    public class MathTests
    {
        [Fact]
        public void Add_WhenCalled_ReturnSumOfInputs()
        {
            var sut = new XUnitSamples.Math();
            var result = sut.Add(1M, 2M);
            Assert.True(3M == result);
        }

        [Fact]
        public void IsOdd_InputIsOdd_ReturnTrue()
        {
            var sut = new Math();
            var result = sut.IsOdd(3);
            Assert.True(result);
        }

        [Fact]
        public void Subtract_WhenCalled_ReturnSubtractOfInputs()
        {
            var sut = new Math();
            var result = sut.Subtract(2M, 1M);
            Assert.Equal(1M, result);
        }

        [Fact]
        public void Multiply_WhenCalled_ReturnSubtractOfInputs()
        {
            var sut = new Math();
            var result = sut.Multiply(2M, 3M);
            Assert.True(6M == result);
            Assert.True(result <= 10 && result >= 1);
            Assert.InRange<decimal>(result, 1, 10);
        }

        [Fact]
        public void Divide_WhenCalled_ReturnDivisionOfInputs()
        {
            var sut = new Math();
            var result = sut.Divide(2M, 2M);
            Assert.True(1M == result);
        }

        [Fact]
        public void Divide_PassZeroToSecondArgument_ThrowDivideByZeroException()
        {
            var sut = new Math();
            var exception = Assert.Throws<DivideByZeroException>(() => sut.Divide(2M, 0));
            Assert.Equal("The Secend Parameter can't be Zero", exception.Message);
        }

        [Fact]
        public void GetOddNumbers_LimitValueIsGreaterThanZero()
        {
            var sut = new Math();
            var result = sut.GetOddNumbers(5);
            //Check for collection is not empty
            Assert.NotEmpty(result);

            //Check for collection count
            Assert.Equal(3, result.Count());

            //Check for collection contain some specific values
            Assert.Contains(1, result);
            Assert.Contains(3, result);
            Assert.Contains(5, result);

            Assert.Contains(result, item => item == 1);

            Assert.DoesNotContain(6, result);

            //Better approach for checking existing items in collection
            var expectedCollection = new[] {1, 3, 5};
            Assert.Equal(expectedCollection, result);

            //Check all of the items grater than zero
            Assert.All(result, item => Assert.True(item > 0));
        }
    }
}