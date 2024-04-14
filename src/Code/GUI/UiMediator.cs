using Godot;

namespace RerollKnight;

public interface IUiMediator
{
	LoadingCurtain LoadingCurtain { get; }

	void StartRun();
	void EndRun();

	void QuitGame();
}

public partial class UiMediator : Control, IUiMediator
{
	private AppStateMachine StateMachine => DiContainer.Instance.Get<AppStateMachine>();

	[Export] public LoadingCurtain LoadingCurtain { get; private set; }

	public void StartRun() => StateMachine.Enter<StartNewRunAppState>();
	public void EndRun()   => StateMachine.Enter<EndRunAppState>();

	public void QuitGame() => StateMachine.Enter<QuitAppState>();
}