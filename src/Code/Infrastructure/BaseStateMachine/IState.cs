using System.Threading.Tasks;

namespace RerollKnight;

public interface IState<TState>
	where TState : IState<TState>
{
	void Enter(StateMachineBase<TState> stateMachine);
}