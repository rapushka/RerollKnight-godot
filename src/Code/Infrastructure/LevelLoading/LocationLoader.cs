using System.Threading.Tasks;
using Godot;

namespace RerollKnight;

public interface ILocationLoader
{
	Task LoadMainMenu();
	Task LoadGameplay();
}

[GlobalClass]
public partial class LocationLoader : Node, ILocationLoader // TODO: warm-up
{ // TODO: mb merge with PageLoader?
	[Export] public PackedScene MainMenuScene { get; set; }
	[Export] public PackedScene GameplayScene { get; set; }

	private Node _currentLocation;

	public async Task LoadMainMenu() => await Load(MainMenuScene);
	public async Task LoadGameplay() => await Load(GameplayScene);

	private Task Load(PackedScene scene)
	{
		if (_currentLocation is not null)
		{
			RemoveChild(_currentLocation);
			_currentLocation.QueueFree();
		}

		_currentLocation = scene.Instantiate();
		AddChild(_currentLocation);

		return Task.CompletedTask;
	}
}