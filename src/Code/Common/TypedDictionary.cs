using System;
using System.Collections.Generic;

namespace RerollKnight.Common;

public class TypedDictionary<T> : Dictionary<Type, T>
{
	public TConcrete Get<TConcrete>()
		where TConcrete : T
		=> (TConcrete)this[typeof(TConcrete)];

	public TConcrete GetOrAdd<TConcrete>()
		where TConcrete : T, new()
	{
		var type = typeof(TConcrete);
		if (!ContainsKey(type))
			Add(type, new TConcrete());

		return Get<TConcrete>();
	}
}