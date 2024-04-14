using Godot;

namespace RerollKnight;

public interface IUiMediator
{
	LoadingCurtain LoadingCurtain { get; }
}

public partial class UiMediator : Control, IUiMediator
{
	[Export] public LoadingCurtain LoadingCurtain { get; private set; }
}