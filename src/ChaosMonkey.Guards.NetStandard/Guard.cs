using System;
using System.Collections.Generic;
using System.Linq;

namespace ChaosMonkey.Guards
{
    public static class Guard
    {
        /// <summary>
        ///  Verifies the given argument is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>Original argument</returns>
        public static T IsNotNull<T>(T argument, string argumentName)
        {
            if (argument == null)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentNullException(name);
            }
            return argument;
        }

        /// <summary>
        /// Verifies an argument is not empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Original argument</returns>
        public static IEnumerable<T> IsNotEmpty<T>(IEnumerable<T> argument, string argumentName)
        {
            if (!argument.Any())
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentException($"Parameter '{name}' cannot be empty.", name);
            }
            return argument;
        }

        /// <summary>
        /// Verifies an argument is not null or empty
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <returns>Original argument</returns>
        public static IEnumerable<T> IsNotNullOrEmpty<T>(IEnumerable<T> argument, string argumentName)
        {
            IsNotNull(argument, argumentName);
            return IsNotEmpty(argument, argumentName);
        }

        /// <summary>
        /// Verifies an argument does not have the default value for its type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsNotDefault<T>(T argument, string argumentName)
        {
            if (Equals(argument, default(T)))
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException(name);
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is greater than the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsGreaterThan<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) <= 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must be greater than '{expected}' but was '{argument}'.");  
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is greater than or equal to the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsGreaterThanOrEqualTo<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) < 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException(($"Argument '{name}' must be greater than or equak to '{expected}' but was '{argument}'."));
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is less than the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsLessThan<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) >= 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must be less than '{expected}' but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is less than or equal to the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsLessThanOrEqualTo<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) > 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must be less than or equal to '{expected}' but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is equal to the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsEqualTo<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) != 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must be equal to '{expected}' but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is not equal to the expected value
        /// </summary>
        /// <param name="argument"></param>
        /// <param name="expected"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsNotEqualTo<T>(T argument, T expected, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(expected) == 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must not be equal to '{expected}' but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is in the given range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsInRange<T>(T argument, T start, T end, string argumentName) where T : struct, IComparable<T>
        {
            IsGreaterThanOrEqualTo(argument, start, argumentName);
            return IsLessThanOrEqualTo(argument, end, argumentName);
        }

        /// <summary>
        /// Verifies that an argument is in the given range (excluding the start and end).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsInRangeExclusive<T>(T argument, T start, T end, string argumentName) where T : struct, IComparable<T>
        {
            IsGreaterThan(argument, start, argumentName);
            return IsLessThan(argument, end, argumentName);
        }

        /// <summary>
        /// Verifies that an argument is not in the given range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsNotInRange<T>(T argument, T start, T end, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(start) >= 0 && argument.CompareTo(end) <= 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must not be in the range '{start}' - '{end}' but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies that an argument is not in the given range (excluding the start and end).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argument"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="argumentName"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Original argument</returns>
        public static T IsNotInRangeExclusive<T>(T argument, T start, T end, string argumentName) where T : struct, IComparable<T>
        {
            if (argument.CompareTo(start) > 0 && argument.CompareTo(end) < 0)
            {
                var name = GetSafeArgumentName(argumentName);
                throw new ArgumentOutOfRangeException($"Argument '{name}' must not be in the range '{start}' - '{end}' (exclusive) but was '{argument}'.");
            }
            return argument;
        }

        /// <summary>
        /// Verifies the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsRequiredThat(bool condition, string message)
        {
            if (!condition)
            {
                throw new ArgumentException(message ?? "The required argument expectation was not met.");
            }
        }

        /// <summary>
        /// Verifies the given condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsTrue(bool condition, string message)
        {
            IsRequiredThat(condition, message ?? "Condition must be true.");
        }

        /// <summary>
        /// Verifies the given condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        /// <exception cref="ArgumentException"></exception>
        public static void IsFalse(bool condition, string message)
        {
            IsRequiredThat(!condition, message ?? "Condition must be true.");
        }

        private static string GetSafeArgumentName(string name)
        {
            return name ?? "[Unknown Argument Name]";
        }
    }
}
