using Godot;

namespace RerollKnight;

[GlobalClass]
public partial class Bootstrap : Node
{
	[Export] private SystemsService SystemsService { get; set; }

	public override void _Ready()
	{
		Container.Instance.Register<ISystemsService>(SystemsService);

		SystemsService.Add<TestFeature>(); // TODO: remove
	}
}