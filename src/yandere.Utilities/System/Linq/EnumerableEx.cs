using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class EnumerableEx
    {
        public static int FindIndex<T>(this IEnumerable<T> source, T element) => EnumerableEx.FindIndex(source, element, EqualityComparer<T>.Default);

        public static int FindIndex<T>(this IEnumerable<T> source, T element, IEqualityComparer<T> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(t, element)
            );
        }

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, Func<TSource, TElement> sourceSelector, TElement element) => EnumerableEx.FindIndex(source, sourceSelector, element, EqualityComparer<TElement>.Default);

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, Func<TSource, TElement> sourceSelector, TElement element, IEqualityComparer<TElement> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (sourceSelector is null) throw new ArgumentNullException(nameof(sourceSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(sourceSelector(t), element)
            );
        }

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, TElement element, Func<TElement, TSource> elementSelector) => EnumerableEx.FindIndex(source, element, elementSelector, EqualityComparer<TSource>.Default);

        public static int FindIndex<TSource, TElement>(this IEnumerable<TSource> source, TElement element, Func<TElement, TSource> elementSelector, IEqualityComparer<TSource> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (elementSelector is null) throw new ArgumentNullException(nameof(elementSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(t, elementSelector(element))
            );
        }

        public static int FindIndex<TSource, TTemporary, TElement>(this IEnumerable<TSource> source, Func<TSource, TTemporary> sourceSelector, TElement element, Func<TElement, TTemporary> elementSelector) => EnumerableEx.FindIndex(source, sourceSelector, element, elementSelector, EqualityComparer<TTemporary>.Default);

        public static int FindIndex<TSource, TTemporary, TElement>(this IEnumerable<TSource> source, Func<TSource, TTemporary> sourceSelector, TElement element, Func<TElement, TTemporary> elementSelector, IEqualityComparer<TTemporary> equalityComparer)
        {
            if (source is null) throw new ArgumentNullException(nameof(source));
            if (sourceSelector is null) throw new ArgumentNullException(nameof(sourceSelector));
            if (elementSelector is null) throw new ArgumentNullException(nameof(elementSelector));
            if (equalityComparer is null) throw new ArgumentNullException(nameof(equalityComparer));

            return EnumerableEx.FindIndexInternal(
                source,
                t => equalityComparer.Equals(sourceSelector(t), elementSelector(element))
            );
        }

        private static int FindIndexInternal<T>(IEnumerable<T> source, Predicate<T> predicate)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                    return index;
                else
                    index++;
            }

            return -1;
        }
    }
}
