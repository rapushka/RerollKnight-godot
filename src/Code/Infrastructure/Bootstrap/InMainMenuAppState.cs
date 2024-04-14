using Godot;

namespace RerollKnight;

public class InMainMenuAppState : IAppState
{
	private readonly IUiMediator _ui = DiContainer.Instance.Get<IUiMediator>();

	public async void Enter(StateMachineBase<IAppState> stateMachine)
	{
		GD.Print($"Hello from {nameof(InMainMenuAppState)}");

		await _ui.LoadingCurtain.Hide();
	}
}