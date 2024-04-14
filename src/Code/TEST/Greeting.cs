using Entitas;
using Godot;

namespace RerollKnight;

public sealed class Greeting : IInitializeSystem
{
	public void Initialize()
	{
		GD.PrintRich("[rainbow]Hello World![/rainbow]");
	}
}