using System.Threading.Tasks;
using Godot;

namespace RerollKnights;

public static class DoTweenExtensions
{
	public static async Task DoModulateFade(this CanvasItem @this, float target, float duration)
	{
		var delta = target - @this.Modulate.A;
		var milliseconds = duration * 1_000;
		if (milliseconds.ApproximatelyEquals(0))
			milliseconds = 1;

		var step = delta / milliseconds;

		var counter = 1_000; // TODO: it's here to prevent endless loop
		while (@this.Modulate.A.ApproximatelyEquals(target))
		{
			var modulate = @this.Modulate;
			modulate.A += step;
			@this.Modulate = modulate;

			await Task.Yield();

			if (counter-- == 0)
				break;
		}

		if (counter <= 0)
			GD.PrintRich("[color=red]there was an endless loop[/color]");
	}
}