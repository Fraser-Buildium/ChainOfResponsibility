using Lamar;
using Moq;

namespace Tests.Core;

public class MoqInjector
{
    private readonly Container m_container;
    private readonly Dictionary<Type, Mock> m_mocks = new ();
    
    public MoqInjector(Container container)
    {
        m_container = container;
    }

    public MoqInjector Add<T>() where T : class
    {
        var mock = new Mock<T>();
        m_mocks[typeof(T)] = mock;
        m_container.Inject(typeof(T), mock.Object, true);

        return this;
    }

    public Mock<T> Get<T>() where T : class
    {
        var key = typeof(T);
        if (!m_mocks.ContainsKey(typeof(T)))
        {
            throw new ArgumentException($"Mock of type {typeof(T).Name} hasn't been registered, yet.");
        }

        return (Mock<T>) m_mocks[typeof(T)];
    }
}