using Godot;
using Godot.Collections;

namespace RerollKnight;

public interface ILocationLoader
{
	void LoadMainMenu();
	void LoadGameplay();
}

[GlobalClass]
public partial class LocationLoader : Node, ILocationLoader // TODO: warm-up
{
	[Export] public PackedScene MainMenuScene { get; set; }
	[Export] public PackedScene GameplayScene { get; set; }

	private Node _currentLevel;

	public void LoadMainMenu() => Load(MainMenuScene);
	public void LoadGameplay() => Load(GameplayScene);

	private void Load(PackedScene scene)
	{
		if (_currentLevel is not null)
		{
			RemoveChild(_currentLevel);
			_currentLevel.QueueFree();
		}

		_currentLevel = scene.Instantiate();
		AddChild(_currentLevel);
	}
}