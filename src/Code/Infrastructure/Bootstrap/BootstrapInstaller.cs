using Godot;

namespace RerollKnight;

[GlobalClass]
public partial class BootstrapInstaller : Node
{
	private static DiContainer Container => DiContainer.Instance;

	public void InstallBindings()
	{
		var systemsService = new SystemsService();
		AddChild(systemsService);
		Container.Register<ISystemsService>(systemsService);

		Container.Register<AppStateMachine>();
	}
}