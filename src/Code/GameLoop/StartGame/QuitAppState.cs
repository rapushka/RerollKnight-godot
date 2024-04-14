using Godot;

namespace RerollKnight;

public class QuitAppState : IAppState
{
	private readonly SceneTree _sceneTree = DiContainer.Instance.Get<SceneTree>();

	public void Enter(StateMachineBase<IAppState> stateMachine)
	{
		_sceneTree.Quit();
	}
}