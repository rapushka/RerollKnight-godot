using Godot;
using RerollKnight;

public partial class MainMenuPage : Control
{
	private static IUiMediator Ui => DiContainer.Instance.Get<IUiMediator>();

	private void OnPlayButtonClicked()
	{
		Ui.StartGame();
	}

	private void OnQuitButtonClicked()
	{
		GetTree().Quit();
	}
}