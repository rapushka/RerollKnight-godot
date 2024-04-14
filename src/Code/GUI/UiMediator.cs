using Godot;

namespace RerollKnight;

public interface IUiMediator
{
	LoadingCurtain LoadingCurtain { get; }

	void StartGame();
}

public partial class UiMediator : Control, IUiMediator
{
	private AppStateMachine StateMachine => DiContainer.Instance.Get<AppStateMachine>();

	[Export] public LoadingCurtain LoadingCurtain { get; private set; }

	public void StartGame() => StateMachine.Enter<StartNewGameAppState>();
}