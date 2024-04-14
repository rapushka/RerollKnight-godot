namespace RerollKnight;

public class InMainMenuAppState : IAppState
{
	private readonly IUiMediator _ui = DiContainer.Instance.Get<IUiMediator>();
	private readonly ILocationLoader _locationLoader = DiContainer.Instance.Get<ILocationLoader>();

	public async void Enter(StateMachineBase<IAppState> stateMachine)
	{
		await _locationLoader.LoadMainMenu();

		await _ui.LoadingCurtain.Hide();
	}
}