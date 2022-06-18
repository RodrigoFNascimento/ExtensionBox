using System;
using System.Collections.Generic;

namespace ExtensionBox
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Returns the element at a specified index in a sequence or a default value if
        /// the index is out of range.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.IEnumerable`1 to return an element from.</param>
        /// <param name="index">The zero-based index of the element to retrieve.</param>
        /// <param name="defaultValue">The value to return if <paramref name="predicate"/> doesn't return a value.</param>
        /// <returns>
        /// <paramref name="defaultValue"/> if the index is outside the bounds of the source sequence; otherwise,
        /// the element at the specified position in the source sequence.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/>is <c>null</c>.</exception>
        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index >= 0)
            {
                IList<TSource> list = source as IList<TSource>;
                if (list != null)
                {
                    if (index < list.Count) return list[index];
                }
                else
                {
                    using (IEnumerator<TSource> e = source.GetEnumerator())
                    {
                        while (true)
                        {
                            if (!e.MoveNext()) break;
                            if (index == 0) return e.Current;
                            index--;
                        }
                    }
                }
            }
            return defaultValue;
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition
        /// or a default value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.IEnumerable`1 to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">The value to return if <paramref name="predicate"/> doesn't return a value.</param>
        /// <returns>
        /// default(TSource) if source is empty or if no element passes the test specified
        /// by predicate; otherwise, the first element in source that passes the test specified
        /// by predicate.
        /// </returns>
        /// <exception cref="ArgumentNullException">source or predicate is null.</exception>
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            foreach (TSource element in source)
            {
                if (predicate(element)) return element;
            }
            return defaultValue;
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default
        /// value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.IEnumerable`1 to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="defaultValue">The value to return if <paramref name="predicate"/> doesn't return a value.</param>
        /// <returns>
        /// default(TSource) if the sequence is empty or if no elements pass the test in
        /// the predicate function; otherwise, the last element that passes the test in the
        /// predicate function.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is <c>null</c>.</exception>
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            TSource result = defaultValue;
            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    result = element;
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a single, specific element of a sequence, or a default value if that element is not found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="source">An System.Collections.Generic.IEnumerable`1 to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <param name="defaultValue">The value to return if <paramref name="predicate"/> doesn't return a value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is <c>null</c></exception>
        /// <exception cref="InvalidOperationException">
        /// The input sequence contains more than one element or the input sequence is empty.
        /// </exception>
        public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            TSource result = defaultValue;
            long count = 0;
            foreach (TSource element in source)
            {
                if (predicate(element))
                {
                    result = element;
                    checked { count++; }
                }
            }
            switch (count)
            {
                case 0: return defaultValue;
                case 1: return result;
            }
            throw new InvalidOperationException();
        }
    }
}
