using System;
using System.ServiceModel.Activities;
using System.ServiceModel.Activities.Activation;
using Microsoft.Practices.Unity;

namespace Unity.WF
{
    public abstract class UnityServiceHostFactory : WorkflowServiceHostFactory
    {
        protected abstract void ConfigureContainer(IUnityContainer container);

        protected abstract InjectionTypes ConfigureInjectionType();

	    protected virtual void ConfigureServiceHost(WorkflowServiceHost serviceHost)
	    {
	    }

	    protected override WorkflowServiceHost CreateWorkflowServiceHost(WorkflowService service, Uri[] baseAddresses)
        {
            var container = new UnityContainer();
            ConfigureContainer(container);

            var host = base.CreateWorkflowServiceHost(service, baseAddresses);

            var injectionType = ConfigureInjectionType();

            if (injectionType == InjectionTypes.Push)
            {
                container.AddNewExtension<WorkflowExtension>();

                var rootActivity = host.Activity;
                container.BuildUp(rootActivity.GetType(), rootActivity);
            }
            else
            {
                var diExtension = new DependencyInjectionExtension(container);
                host.WorkflowExtensions.Add(diExtension);
            }

		    ConfigureServiceHost(host);
            return host;
        }
    }
}
