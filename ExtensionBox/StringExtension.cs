using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtensionBox
{
    public static class StringExtension
    {
        /// <summary>
        /// Formats a string.
        /// </summary>
        /// <param name="s">string to be formatted.</param>
        /// <param name="pattern">Pattern.</param>
        /// <param name="replacement">Replacement.</param>
        /// <returns>Formatted string.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when given an empty pattern.
        /// </exception>
        public static string FormatString(this string s, string pattern, string replacement)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            if (string.IsNullOrEmpty(pattern))
                throw new ArgumentException("Invalid pattern", nameof(pattern));

            var regExp = new Regex(pattern);
            return regExp.Replace(s, replacement);
        }

        /// <summary>
        /// Indicates whether all the chars in a string are digits.
        /// </summary>
        /// <param name="s">string to be validated.</param>
        /// <returns>
        /// true when <paramref name="s"/> is only composed of digits,
        /// false otherwise.
        /// </returns>
        public static bool IsANumber(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return false;

            var removedString = s.RemoveNonDigits();

            return !string.IsNullOrEmpty(removedString) && removedString.Length == s.Length;
        }

        /// <summary>
        /// Removes all chars of a string that are not considered digits.
        /// </summary>
        /// <param name="s">string that should have any char that's not a digit removed.</param>
        /// <returns>String without any char that is not a digit.</returns>
        public static string RemoveNonDigits(this string s)
        {
            if (s is null)
                return null;

            return new string(s.Where(c => char.IsDigit(c)).ToArray());
        }

        /// <summary>
        /// Converts string to byte array.
        /// </summary>
        /// <param name="s">string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="InvalidCastException">Thrown when <paramref name="s"/> isn't a number.</exception>
        public static byte[] ToByteArray(this string s)
        {
            if (!s.IsANumber())
                throw new InvalidCastException($"Can't convert {s} to byte array.");

            int length = s.Length;

            byte[] intArray = new byte[length];

            for (int i = 0; i < length; i++)
            {
                intArray[i] = byte.Parse(s[i].ToString());
            }

            return intArray;
        }
    }
}
