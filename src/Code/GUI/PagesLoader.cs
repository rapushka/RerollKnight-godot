using Godot;

namespace RerollKnight;

public interface IPagesLoader
{
	void OpenMainMenu();
	void OpenGameplay();
}

public partial class PagesLoader : Node, IPagesLoader
{
	[Export] private PackedScene MainMenuPageScene { get; set; }
	[Export] private PackedScene GameplayPageScene { get; set; }

	private Node _currentPage;

	public void OpenMainMenu() => Open(MainMenuPageScene);
	public void OpenGameplay() => Open(GameplayPageScene);

	private void Open(PackedScene scene)
	{
		if (_currentPage is not null)
		{
			RemoveChild(_currentPage);
			_currentPage.QueueFree();
		}

		_currentPage = scene.Instantiate();
		AddChild(_currentPage);
	}
}