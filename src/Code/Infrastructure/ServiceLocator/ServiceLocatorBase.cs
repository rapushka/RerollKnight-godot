namespace RerollKnight;

public abstract class ServiceLocatorBase<TSelf>
	where TSelf : ServiceLocatorBase<TSelf>, new()
{
	private static TSelf _instance;

	public static TSelf Instance
	{
		get
		{
			if (_instance is null)
			{
				_instance = new TSelf();
				_instance.InstallBindings();
			}

			return _instance;
		}
	}

	public T Get<T>() => Dependency<T>.Value;

	protected abstract void InstallBindings();

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