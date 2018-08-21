using System;
using System.Collections.Generic;
using Xunit;

namespace ChaosMonkey.Guards.NetStandard.Tests
{
    public class GuardTests
    {
        [Fact]
        public void IsNotNull_WhenItemIsNotNull_ReturnsItem()
        {
            var argument = "Not Null";
            var result = Guard.IsNotNull(argument, nameof(argument));

            Assert.NotNull(result);
            Assert.Same(argument, result);
        }

        [Fact]
        public void IsNotNull_WhenItemIsNull_ThrowsExpectedException()
        {
            string argument = null;

            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(argument, nameof(argument)));

            Assert.True(exception.Message.Contains(nameof(argument)), $"Exception message did not contain the expected name of the argument. '{nameof(argument)}'");
        }

        [Fact]
        public void IsNotNull_WhenItemIsNullAndNameIsNull_ThrowsExpectedException()
        {
            string argument = null;

            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull(argument, null));

            Assert.True(exception.Message.Contains("[Unknown Argument Name]"), $"Exception message did not contain the expected name of the argument. '[Unknown Argument Name]'");
        }

        [Fact]
        public void IsNotEmpty_WhenStringIsNotEmpty_ReturnsOriginalString()
        {
            string argument = "test value";

            var result = Guard.IsNotEmpty(argument, nameof(argument));

            Assert.Same(argument, result);
        }
        
        [Fact]
        public void IsNotEmpty_WithEmptyString_ThrowsExpectedException()
        {
            string argument = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotEmpty(argument, nameof(argument)));

            Assert.Equal("Parameter 'argument' cannot be empty.\r\nParameter name: argument", exception.Message);
        }

        [Fact]
        public void IsNotEmpty_WithEmptyStringAndNullArgumentName_ThrowsExpectedException()
        {
            string argument = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotEmpty(argument, null));

            Assert.Equal("Parameter '[Unknown Argument Name]' cannot be empty.\r\nParameter name: [Unknown Argument Name]", exception.Message);
        }

        [Fact]
        public void IsNotEmpty_WhenIEnumerableIsNotEmpty_ReturnsOriginalIEnumerable()
        {
            IEnumerable<string> argument = new []  {"test value"};

            var result = Guard.IsNotEmpty(argument, nameof(argument));

            Assert.Same(argument, result);
        }

        [Fact]
        public void IsNotEmpty_WithEmptyIEnumerable_ThrowsExpectedException()
        {
            IEnumerable<string> argument =new string[] {};

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotEmpty(argument, nameof(argument)));

            Assert.Equal("Parameter 'argument' cannot be empty.\r\nParameter name: argument", exception.Message);
        }

        [Fact]
        public void IsNotEmpty_WithEmptyIEnumerableAndNullArgumentName_ThrowsExpectedException()
        {
            IEnumerable<string> argument =new string[] {};

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotEmpty(argument, null));

            Assert.Equal("Parameter '[Unknown Argument Name]' cannot be empty.\r\nParameter name: [Unknown Argument Name]", exception.Message);
        }

        [Fact]
        public void IsNotDefault_WhenArgumentIsNotDefaultValueForItsType_ReturnsArgument()
        {
            var time = DateTime.Now;

            var result = Guard.IsNotDefault(time, nameof(time));

            Assert.Equal(time, result);
        }

        [Fact]
        public void IsNotDefault_WhenArgumentHasDefaultValueForItsType_ThrowsExpectedException()
        {
            var time = DateTime.MinValue;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotDefault(time, nameof(time)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: time", exception.Message);
        }

        [Fact]
        public void IsNotDefault_WhenArgumentHasDefaultValueForItsTypeAndNameIsNull_ThrowsExpectedException()
        {
            var time = DateTime.MinValue;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotDefault(time, null));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: [Unknown Argument Name]", exception.Message);
        }

        [Fact]
        public void IsTrue_WhenFalse_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsTrue(false, "Condition must evaluate to true."));

            Assert.Equal("Condition must evaluate to true.", exception.Message);
        }

        [Fact]
        public void IsTrue_WhenFalseAndMessageIsNull_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsTrue(false, "Condition must be true."));

            Assert.Equal("Condition must be true.", exception.Message);
        }

        [Fact]
        public void IsFalse_WhenTrue_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsFalse(true, "Condition must evaluate to false."));

            Assert.Equal("Condition must evaluate to false.", exception.Message);
        }

        [Fact]
        public void IsFalse_WhenTrueAndMessageIsNull_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsFalse(true, null));

            Assert.Equal("Condition must be false.", exception.Message);
        }

        [Fact]
        public void IsRequiredThat_WhenFalse_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsRequiredThat(false, "Condition must evaluate to true."));

            Assert.Equal("Condition must evaluate to true.", exception.Message);
        }

        [Fact]
        public void IsRequiredThat_WhenFalseAndMessageIsNull_ThrowsExpectedException()
        {
            var exception = Assert.Throws<ArgumentException>(() => Guard.IsRequiredThat(false, null));

            Assert.Equal("The required argument expectation was not met.", exception.Message);
        }

        [Fact]
        public void IsGreaterThan_WhenValueIsGreaterThanExpected_ReturnsArgument()
        {
            const int value = 5;
            const int expected = 3;

            var result = Guard.IsGreaterThan(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsGreaterThan_WhenValueIsLessThanExpected_ThrowsExpectedException()
        {
            const int value = 3;
            const int expected = 5;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=> Guard.IsGreaterThan(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be greater than '5' but was '3'.", exception.Message);
        }

        [Fact]
        public void IsGreaterThan_WhenValueIsEqualToExpected_ThrowsExpectedException()
        {
            const int value = 5;
            const int expected = 5;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsGreaterThan(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be greater than '5' but was '5'.", exception.Message);
        }
    }
}
