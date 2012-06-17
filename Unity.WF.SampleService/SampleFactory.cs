using Microsoft.Practices.Unity;
using Unity.WF.SampleActivities;

namespace Unity.WF.SampleService
{
    public class SampleFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<ICalcService, CalcService>();
        }
    }
}