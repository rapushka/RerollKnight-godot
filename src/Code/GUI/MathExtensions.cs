using System;
using Godot;

namespace RerollKnights;

public static class MathExtensions
{
	public static bool ApproximatelyEquals(this float @this, float other) => Mathf.IsEqualApprox(@this, other);
}