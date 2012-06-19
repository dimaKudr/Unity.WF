using Microsoft.Practices.Unity;
using Unity.WF.SampleActivities;

namespace Unity.WF.SampleService
{
    public class SamplePullFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ICalcService, CalcService>();
        }

        protected override InjectionTypes ConfigureInjectionType()
        {
            return InjectionTypes.Pull;
        }
    }
}