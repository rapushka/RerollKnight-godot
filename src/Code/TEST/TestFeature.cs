using Godot;

namespace RerollKnight;

public sealed class TestFeature : FeatureBase
{
	public TestFeature()
		: base(nameof(TestFeature))
	{
		Add<Greeting>();
	}
}