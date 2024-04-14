namespace RerollKnight;

/// There's no Dependency Injection, but nah 
public class DiContainer
{
	private static DiContainer _instance;

	public static DiContainer Instance => _instance ??= new DiContainer();

	public T Get<T>() => Dependency<T>.Value;

	public void Register<T>() where T : new() => Register(new T());

	public void Register<TContract, TImplementation>()
		where TImplementation : TContract, new()
		=> Register<TContract>(new TImplementation());

	public void Register<T>(T instance) => Dependency<T>.Value = instance;

	private static class Dependency<T>
	{
		public static T Value;
	}
}