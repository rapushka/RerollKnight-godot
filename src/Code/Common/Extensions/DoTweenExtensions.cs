using System;
using System.Threading.Tasks;
using Godot;

namespace RerollKnights;

public static class DoTweenExtensions
{
	public static async Task DoModulateFade(this CanvasItem @this, float target, float duration)
	{
		if (duration.ApproximatelyEquals(0f))
		{
			@this.Modulate = @this.Modulate with { A = target };
			return;
		}

		var fromValue = @this.Modulate.A;
		var timer = @this.GetTree().CreateTimer(duration);
		var counter = 1_000;

		while (timer.TimeLeft > 0)
		{
			var elapsedTime = duration - (float)timer.TimeLeft;
			var normalized = elapsedTime / duration;
			var nextAlpha = Mathf.Lerp(fromValue, target, normalized);

			@this.Modulate = @this.Modulate with { A = nextAlpha };
			await Task.Delay(TimeSpan.FromMilliseconds(1));

			if (counter-- < 0)
			{
				GD.PrintRich("[color=red]endless loop[/color]");
				break;
			}
		}
	}
}