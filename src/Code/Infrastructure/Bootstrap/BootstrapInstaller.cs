using Godot;

namespace RerollKnight;

[GlobalClass]
public partial class BootstrapInstaller : Node
{
	[Export] private UiMediator   UiMediator   { get; set; }
	[Export] private LocationLoader LocationLoader { get; set; }

	private static DiContainer Container => DiContainer.Instance;

	public void InstallBindings()
	{
		RegisterFromNewChild<ISystemsService, SystemsService>();
		Container.Register<AppStateMachine>();

		Container.Register<IUiMediator>(UiMediator);
		Container.Register<ILocationLoader>(LocationLoader);
	}

	private void RegisterFromNewChild<TContract, TImplementation>()
		where TImplementation : Node, TContract, new()
	{
		var instance = new TImplementation();
		AddChild(instance);
		Container.Register<TContract>(instance);
	}
}