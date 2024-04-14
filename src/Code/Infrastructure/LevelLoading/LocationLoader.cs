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
{
	[Export] public PackedScene MainMenuScene { get; set; }
	[Export] public PackedScene GameplayScene { get; set; }

	private Node _currentLevel;

	public async Task LoadMainMenu() => await Load(MainMenuScene);
	public async Task LoadGameplay() => await Load(GameplayScene);

	private Task Load(PackedScene scene)
	{
		if (_currentLevel is not null)
		{
			RemoveChild(_currentLevel);
			_currentLevel.QueueFree();
		}

		_currentLevel = scene.Instantiate();
		AddChild(_currentLevel);

		return Task.CompletedTask;
	}
}