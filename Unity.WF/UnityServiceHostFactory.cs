using System;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Activation;
using Microsoft.Practices.Unity;

namespace Unity.WF
{
    public abstract class UnityServiceHostFactory : WorkflowServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service, Uri[] baseAddresses)
        {
            var host = base.CreateWorkflowServiceHost(service, baseAddresses);

            var container = new UnityContainer();
            ConfigureContainer(container);

            var diExtension = new DependencyInjectionExtension(container);
            host.WorkflowExtensions.Add(diExtension);

            return host;
        }
    }
}
