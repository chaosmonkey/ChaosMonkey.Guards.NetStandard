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
            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNull<string>(null, null));

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
        public void IsNotNullOrWhitespace_WhenNotNullOrWhitespaceOnly_ReturnsArgument()
        {
            const string argument = "valid";

            var result = Guard.IsNotNullOrWhitespace(argument, nameof(argument));

            Assert.Same(argument, result);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenNotNullOrWhitespaceOnlyAndNameIsNull_ReturnsArgument()
        {
            const string argument = "valid";

            var result = Guard.IsNotNullOrWhitespace(argument, null);

            Assert.Same(argument, result);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenNull_ThrowsExpectedException()
        {
            string argument = null;

            var exception = Assert.Throws<ArgumentException>(()=> Guard.IsNotNullOrWhitespace(argument, nameof(argument)));

            Assert.Equal("Parameter 'argument' cannot be empty or whitespace only, but was '[NULL]'.\r\nParameter name: argument", exception.Message);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenNullAndNameIsNull_ThrowsExpectedException()
        {
            string argument = null;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrWhitespace(argument, null));

            Assert.Equal("Parameter '[Unknown Argument Name]' cannot be empty or whitespace only, but was '[NULL]'.\r\nParameter name: [Unknown Argument Name]", exception.Message);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenEmpty_ThrowsExpectedException()
        {
            string argument = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrWhitespace(argument, nameof(argument)));

            Assert.Equal("Parameter 'argument' cannot be empty or whitespace only, but was '[EMPTY]'.\r\nParameter name: argument", exception.Message);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenEmptyAndNameIsNull_ThrowsExpectedException()
        {
            string argument = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrWhitespace(argument, null));

            Assert.Equal("Parameter '[Unknown Argument Name]' cannot be empty or whitespace only, but was '[EMPTY]'.\r\nParameter name: [Unknown Argument Name]", exception.Message);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenWhitespaceOnly_ThrowsExpectedException()
        {
            string argument = "\r\n\t\f";

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrWhitespace(argument, nameof(argument)));

            Assert.Equal("Parameter 'argument' cannot be empty or whitespace only, but was '[WHITESPACE-ONLY]'.\r\nParameter name: argument", exception.Message);
        }

        [Fact]
        public void IsNotNullOrWhitespace_WhenWhitespaceOnlyAndNameIsNull_ThrowsExpectedException()
        {
            string argument = "\r\n\t\f";

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrWhitespace(argument, null));

            Assert.Equal("Parameter '[Unknown Argument Name]' cannot be empty or whitespace only, but was '[WHITESPACE-ONLY]'.\r\nParameter name: [Unknown Argument Name]", exception.Message);
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
        public void IsTrue_WhenTrue_DoesNotThrowException()
        {
            Guard.IsTrue(true, "1 must be equal to 1.");
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
        public void IsFalse_WhenFalse_DoesNotThrowException()
        {
            Guard.IsFalse(1==0, "1 cannot be equal to 0.");
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
        public void IsRequiredThat_WhenConditionIsTrue_DoesNotThrowException()
        {
            Guard.IsRequiredThat(true, "1 must be equal to 1.");
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

        [Fact]
        public void IsLessThan_WhenValueIsLessThanExpected_ReturnsArgument()
        {
            const int value = 3;
            const int expected = 5;

            var result = Guard.IsLessThan(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsLessThan_WhenValueIsGreaterThanExpected_ThrowsExpectedException()
        {
            const int value = 5;
            const int expected = 3;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsLessThan(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than '3' but was '5'.", exception.Message);
        }

        [Fact]
        public void IsLessThan_WhenValueIsEqualToExpected_ThrowsExpectedException()
        {
            const int value = 5;
            const int expected = 5;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsLessThan(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than '5' but was '5'.", exception.Message);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenValueIsGreaterThanExpected_ReturnsArgument()
        {
            const int value = 5;
            const int expected = 3;

            var result = Guard.IsGreaterThanOrEqualTo(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenValueIsLessThanExpected_ThrowsExpectedException()
        {
            const int value = 3;
            const int expected = 5;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsGreaterThanOrEqualTo(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be greater than or equal to '5' but was '3'.", exception.Message);
        }

        [Fact]
        public void IsGreaterThanOrEqualTo_WhenValueIsEqualToExpected_ReturnsValue()
        {
            const int value = 5;
            const int expected = 5;

            var result = Guard.IsGreaterThanOrEqualTo(value, expected, nameof(value));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenValueIsLessThanExpected_ReturnsArgument()
        {
            const int value = 3;
            const int expected = 5;

            var result = Guard.IsLessThanOrEqualTo(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenValueIsGreaterThanExpected_ThrowsExpectedException()
        {
            const int value = 5;
            const int expected = 3;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsLessThanOrEqualTo(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than or equal to '3' but was '5'.", exception.Message);
        }

        [Fact]
        public void IsLessThanOrEqualTo_WhenValueIsEqualToExpected_ReturnsValue()
        {
            const int value = 5;
            const int expected = 5;

            var result = Guard.IsLessThanOrEqualTo(value, expected, nameof(value));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsNotInRange_WhenValueIsNotInRange_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 5;

            var result = Guard.IsNotInRange(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsNotInRange_WhenValueIsInRange_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 2;

            var exception =  Assert.Throws<ArgumentOutOfRangeException>(()=>  Guard.IsNotInRange(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must not be in the range '1' - '3' but was '2'.", exception.Message);
        }

        [Fact]
        public void IsNotInRange_WhenValueEqualsStart_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotInRange(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must not be in the range '1' - '3' but was '1'.", exception.Message);
        }

        [Fact]
        public void IsNotInRange_WhenValueEqualsEnd_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 3;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotInRange(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must not be in the range '1' - '3' but was '3'.", exception.Message);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenValueIsNotInRange_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 5;

            var result = Guard.IsNotInRangeExclusive(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenValueIsInRange_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 2;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotInRangeExclusive(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must not be in the range '1' - '3' (exclusive) but was '2'.", exception.Message);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenValueEqualsStart_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 1;

            var result = Guard.IsNotInRangeExclusive(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsNotInRangeExclusive_WhenValueEqualsEnd_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 3;
            
            var result = Guard.IsNotInRangeExclusive(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsNotEqualTo_WhenNotEqual_ReturnsValue()
        {
            int value = 1;
            int expected = 2;

            var result = Guard.IsNotEqualTo(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsNotEqualTo_WhenEqual_ThrowsExpectedException()
        {
            int value = 1;
            int expected = 1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsNotEqualTo(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must not be equal to '1' but was '1'.", exception.Message);
        }

        [Fact]
        public void IsEqualTo_WhenEqual_ReturnsValue()
        {
            int value = 1;
            int expected = 1;

            var result = Guard.IsEqualTo(value, expected, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsEqualTo_WhenNotEqual_ThrowsExpectedException()
        {
            int value = 1;
            int expected = 2;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsEqualTo(value, expected, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be equal to '2' but was '1'.", exception.Message);
        }

        [Fact]
        public void IsInRange_WhenValueIsInRange_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 2;

            var result = Guard.IsInRange(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsInRange_WhenValueEqualsStart_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 1;

            var result = Guard.IsInRange(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsInRange_WhenValueEqualsEnd_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 3;

            var result = Guard.IsInRange(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsInRange_WhenValueIsOutisdeRange_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 12;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=> Guard.IsInRange(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than or equal to '3' but was '12'." , exception.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableNull_ThrowsExpectedException()
        {
            List<string> data = null;

            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNullOrEmpty(data, nameof(data)));

            Assert.Equal("Value cannot be null.\r\nParameter name: data", exception.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableEmpty_ThrowsExpectedException()
        {
            List<string> data = new List<string>();

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrEmpty(data, nameof(data)));

            Assert.Equal("Parameter 'data' cannot be empty.\r\nParameter name: data", exception.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenEnumerableNotNullOrEmpty_ReturnsValue()
        {
            List<string> data = new List<string>(){"Value"};

            var result = Guard.IsNotNullOrEmpty(data, nameof(data));

            Assert.Same(data, result);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNull_ThrowsExpectedException()
        {
            string data = null;

            var exception = Assert.Throws<ArgumentNullException>(() => Guard.IsNotNullOrEmpty(data, nameof(data)));

            Assert.Equal("Value cannot be null.\r\nParameter name: data", exception.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsEmpty_ThrowsExpectedException()
        {
            string data = string.Empty;

            var exception = Assert.Throws<ArgumentException>(() => Guard.IsNotNullOrEmpty(data, nameof(data)));

            Assert.Equal("Parameter 'data' cannot be empty.\r\nParameter name: data", exception.Message);
        }

        [Fact]
        public void IsNotNullOrEmpty_WhenStringIsNotNullOrEmpty_ReturnsValue()
        {
            string data = "value";

            var result = Guard.IsNotNullOrEmpty(data, nameof(data));

            Assert.Same(data, result);
        }

        [Fact]
        public void IsInRangeExclusive_WhenValueIsInRange_ReturnsValue()
        {
            int start = 1;
            int end = 3;
            int value = 2;

            var result = Guard.IsInRangeExclusive(value, start, end, nameof(value));

            Assert.Equal(value, result);
        }

        [Fact]
        public void IsInRangeExclusive_WhenValueEqualsStart_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 1;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsInRangeExclusive(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be greater than '1' but was '1'.", exception.Message);
        }

        [Fact]
        public void IsInRangeExclusive_WhenValueEqualsEnd_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 3;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsInRangeExclusive(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than '3' but was '3'.", exception.Message);
        }

        [Fact]
        public void IsInRangeExclusive_WhenValueIsOutisdeRange_ThrowsExpectedException()
        {
            int start = 1;
            int end = 3;
            int value = 12;

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Guard.IsInRangeExclusive(value, start, end, nameof(value)));

            Assert.Equal("Specified argument was out of the range of valid values.\r\nParameter name: Argument 'value' must be less than '3' but was '12'.", exception.Message);
        }
    }
}
