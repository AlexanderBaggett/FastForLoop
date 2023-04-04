using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FastForloop
{

    public static class Loops
    {

        public static void FastFor<T>(T[] items, Action codeblock)
        {
            ref var start = ref MemoryMarshal.GetArrayDataReference(items);
            ref var end = ref Unsafe.Add(ref start, items.Length);

            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                codeblock();
            }
        }

        public static void SpanFor<T>(T[] items, Action codeblock)
        {
            var span = items.AsSpan();

            for (int i = 0; i < span.Length; i++)
            {
                codeblock();
            }
        }
    }
    public static class ArrayExtensions
    {
        public static void FastFor<T>(this T[] items, Action codeblock)
        {
            ref var start = ref MemoryMarshal.GetArrayDataReference(items);
            ref var end = ref Unsafe.Add(ref start, items.Length);

            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                codeblock();
            }
        }

        public static void SpanFor<T>(this T[] items, Action codeblock)
        {
            var span = items.AsSpan();

            for (int i = 0; i < span.Length; i++)
            {
                codeblock();
            }
        }
    }
}
