namespace RerollKnight;

public class EndRunAppState : IAppState
{
	private readonly IUiMediator _ui = DiContainer.Instance.Get<IUiMediator>();

	public async void Enter(StateMachineBase<IAppState> stateMachine)
	{
		await _ui.LoadingCurtain.Show();

		stateMachine.Enter<InMainMenuAppState>();
	}
}