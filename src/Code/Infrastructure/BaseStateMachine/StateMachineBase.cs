using RerollKnight.Common;

namespace RerollKnight;

public abstract class StateMachineBase<TState>
	where TState : IState<TState>
{
	private readonly TypedDictionary<TState> _states = new();

	public TState CurrentState { get; private set; }

	public void Enter<TConcreteState>()
		where TConcreteState : TState, new()
	{
		// ReSharper disable once SuspiciousTypeConversion.Global - will be! :p
		(CurrentState as IExitState)?.Exit();

		CurrentState = _states.GetOrAdd<TConcreteState>();
		Godot.GD.PrintRich($"[color=green]state machine:[/color] Enter {typeof(TConcreteState).Name}");
		CurrentState.Enter(this);
	}
}