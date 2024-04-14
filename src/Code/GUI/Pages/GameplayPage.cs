using Godot;
using RerollKnight;

public partial class GameplayPage : Control
{
	private static IUiMediator Ui => DiContainer.Instance.Get<IUiMediator>();

	private void OnBackButtonClicked()
	{
		Ui.EndRun();
	}
}