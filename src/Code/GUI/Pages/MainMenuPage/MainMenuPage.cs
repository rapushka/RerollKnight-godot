using Godot;
using RerollKnight;

public partial class MainMenuPage : Control
{
	private static IUiMediator Ui => DiContainer.Instance.Get<IUiMediator>();

	private void OnPlayButtonClicked()
	{
		GD.Print($"clicked");
		Ui.StartGame();
	}

	private void OnQuitButtonClicked()
	{
		GD.Print($"quit plz");
		GetTree().Quit();
	}
}