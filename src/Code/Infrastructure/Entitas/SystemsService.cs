using System.Collections.Generic;
using Entitas;
using Godot;

namespace RerollKnight;

public interface ISystemsService
{
	void Add<TFeature>() where TFeature : Systems, new();
	void Remove<TFeature>() where TFeature : Systems, new();
}

[GlobalClass]
public partial class SystemsService : Node, ISystemsService
{
	private readonly Dictionary<string, Systems> _features = new();

	public void Add<TFeature>()
		where TFeature : Systems, new()
	{
		var newFeature = new TFeature();
		newFeature.Initialize();
		_features.Add(typeof(TFeature).Name, newFeature);
	}

	public void Remove<TFeature>()
		where TFeature : Systems, new()
	{
		var name = typeof(TFeature).Name;

		_features[name].TearDown();
		_features.Remove(name);
	}

	public override void _EnterTree()
	{
		foreach (var (_, feature) in _features)
			feature.Initialize();
	}

	public override void _Process(double delta)
	{
		foreach (var (_, feature) in _features)
		{
			feature.Execute();
			feature.Cleanup();
		}
	}

	public override void _ExitTree()
	{
		foreach (var (_, feature) in _features)
			feature.TearDown();
	}
}