namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> map = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements => this.map.Count;

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get { return this.map[Tuple.Create(key1, key2)]; }
            set { this.map[Tuple.Create(key1, key2)] = value; }
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            List<Tuple<TKey2, TValue>> list = new List<Tuple<TKey2, TValue>>();
            foreach (var pair in map)
            {
                if (pair.Key.Item1.Equals(key1)) {
                    list.Add(Tuple.Create(pair.Key.Item2, pair.Value));
                }
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            List<Tuple<TKey1, TValue>> list = new List<Tuple<TKey1, TValue>>();
            foreach (var pair in map)
            {
                if (pair.Key.Item2.Equals(key2))
                {
                    list.Add(Tuple.Create(pair.Key.Item1, pair.Value));
                }
            }
            return list;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return this.map.Keys
                .Select(tuple => Tuple.Create(tuple.Item1, tuple.Item2, this.map[tuple]))
                .ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach (var key1 in keys1)
            {
                foreach (var key2 in keys2)
                {
                this[key1, key2] = generator(key1, key2);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            return other.GetElements().Equals(this.GetElements());
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (obj is IMap2D<TKey1, TKey2, TValue> objMap)
            {
                return this.Equals(objMap);
            }
            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return this.map != null ? this.map.GetHashCode() : 0;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.GetElements()
                       .Select(e => $"[{e.Item1}, {e.Item2}] => {e.Item3}"));
        }
    }
}
