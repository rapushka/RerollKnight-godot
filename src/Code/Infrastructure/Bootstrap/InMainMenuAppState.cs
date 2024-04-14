namespace RerollKnight;

public class InMainMenuAppState : IAppState
{
	private readonly IUiMediator _ui = DiContainer.Instance.Get<IUiMediator>();
	private readonly ILocationLoader _locationLoader = DiContainer.Instance.Get<ILocationLoader>();
	private readonly IPagesLoader _pagesLoader = DiContainer.Instance.Get<IPagesLoader>();

	public async void Enter(StateMachineBase<IAppState> stateMachine)
	{
		await _locationLoader.LoadMainMenu();
		_pagesLoader.OpenMainMenu();

		await _ui.LoadingCurtain.Hide();
	}
}