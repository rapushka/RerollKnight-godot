namespace RerollKnight;

public class BootstrapAppState : IAppState
{
	private readonly IUiMediator _ui = DiContainer.Instance.Get<IUiMediator>();

	public async void Enter(StateMachineBase<IAppState> stateMachine)
	{
		await _ui.LoadingCurtain.Show(immediate: true);
		stateMachine.Enter<InMainMenuAppState>();
	}
}