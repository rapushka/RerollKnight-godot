using System.Threading.Tasks;
using Godot;
using RerollKnights;

namespace RerollKnight;

[GlobalClass]
public partial class LoadingCurtain : Control
{
	[Export] private float FadeDuration { get; set; } = 0.3f;

	public async Task FadeIn(bool immediate = false)
		=> await this.DoModulateFade(1f, immediate ? 0 : FadeDuration);

	public async Task FadeOut(bool immediate = false)
		=> await this.DoModulateFade(0f, immediate ? 0 : FadeDuration);
}