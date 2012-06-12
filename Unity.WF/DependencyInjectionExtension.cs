using Microsoft.Practices.Unity;

namespace Unity.WF
{
    public sealed class DependencyInjectionExtension
    {
        private readonly IUnityContainer _container;

        public DependencyInjectionExtension(IUnityContainer container)
        {
            _container = container;
        }

        public T GetDependency<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
