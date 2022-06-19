using System;

namespace ExtensionBox
{
    public static class TypeExtension
    {
        /// <summary>
        /// Checks if <paramref name="t"/> is a nullable type.
        /// </summary>
        /// <param name="t">Type that should be checked.</param>
        /// <returns>
        /// true if type is nullable, false otherwise.
        /// </returns>
        public static bool IsNullable(this Type t) =>
            Nullable.GetUnderlyingType(t) != null;

        /// <summary>
        /// Checks is <paramref name="t"/> is a nullable numeric type.
        /// </summary>
        /// <param name="t">Type that should be checked.</param>
        /// <returns>
        /// true if <paramref name="t"/> is a nullable numeric type,
        /// false otherwise.
        /// </returns>
        public static bool IsNullableNumeric(this Type t) =>
            t == typeof(sbyte?)
            || t == typeof(byte?)
            || t == typeof(short?)
            || t == typeof(ushort?)
            || t == typeof(int?)
            || t == typeof(uint?)
            || t == typeof(long?)
            || t == typeof(ulong?)
            || t == typeof(float?)
            || t == typeof(double?)
            || t == typeof(decimal?);

        /// <summary>
        /// Checks is <paramref name="t"/> is a numeric type.
        /// </summary>
        /// <param name="t">Type that should be checked.</param>
        /// <returns>
        /// true if <paramref name="t"/> is a numeric type,
        /// false otherwise.
        /// </returns>
        public static bool IsNumeric(this Type t) =>
            t == typeof(sbyte)
            || t == typeof(sbyte?)
            || t == typeof(byte)
            || t == typeof(byte?)
            || t == typeof(short)
            || t == typeof(short?)
            || t == typeof(ushort)
            || t == typeof(ushort?)
            || t == typeof(int)
            || t == typeof(int?)
            || t == typeof(uint)
            || t == typeof(uint?)
            || t == typeof(long)
            || t == typeof(long?)
            || t == typeof(ulong)
            || t == typeof(ulong?)
            || t == typeof(float)
            || t == typeof(float?)
            || t == typeof(double)
            || t == typeof(double?)
            || t == typeof(decimal)
            || t == typeof(decimal?);
    }
}
