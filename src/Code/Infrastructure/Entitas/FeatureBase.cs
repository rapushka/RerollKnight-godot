using Entitas;

namespace RerollKnight;

public abstract class FeatureBase(string name) : Feature(name)
{
	protected void Add<TSystem>()
		where TSystem : ISystem, new()
		=> Add(new TSystem());
}