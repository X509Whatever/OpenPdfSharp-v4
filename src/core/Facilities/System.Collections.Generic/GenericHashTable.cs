namespace System.Collections.Generic
{
	public class GenericHashTable<K, V> : Dictionary<K, V>
	{
		#region .ctors

		public GenericHashTable()
			: base()
		{ }

		public GenericHashTable(int capacity)
			: base(capacity)
		{ }

		public GenericHashTable(IDictionary<K, V> dictionary)
			: base(dictionary)
		{ }

		#endregion

		public new V this[K key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => this[key] = value;
		}
	}
}
