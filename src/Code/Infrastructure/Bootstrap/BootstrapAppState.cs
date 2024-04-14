using Godot;

namespace RerollKnight;

public class BootstrapAppState : IAppState
{
	public void Enter(StateMachineBase<IAppState> stateMachine)
	{
		// TODO: something nice
		GD.Print("Hello from bootstrap state");
	}
}