using Godot;

namespace RerollKnight;

[GlobalClass]
public partial class Bootstrap : Node
{
	[Export] private BootstrapInstaller Installer { get; set; }

	private static AppStateMachine AppStateMachine => DiContainer.Instance.Get<AppStateMachine>();

	public override void _EnterTree()
	{
		GD.Print("> bootstrap enter tree");
	}

	public override void _Ready()
	{
		GD.Print("> bootstrap ready");
		Installer.InstallBindings();

		AppStateMachine.Enter<BootstrapAppState>();
	}
}