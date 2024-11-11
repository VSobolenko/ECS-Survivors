using Entitas;
using Zenject;

namespace Code.Infrastructure.Systems
{
public class SystemFactory : ISystemFactory
{
    private readonly DiContainer _container;

    public SystemFactory(DiContainer diContainer) => _container = diContainer;

    public T Create<T>() where T : ISystem => _container.Instantiate<T>();
    
    public T Create<T>(params object[] args) where T : ISystem => _container.Instantiate<T>(args);
}
}