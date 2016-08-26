using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trains.Util
{
    public static class ImmutableBuilderExtensions
    {
        public static ImmutableDictionary<TKey, TValue>.Builder AddFluent<TKey, TValue>(this ImmutableDictionary<TKey, TValue>.Builder builder, TKey key, TValue value)
        {
            builder.Add(key, value);
            return builder;
        }
    }
}
