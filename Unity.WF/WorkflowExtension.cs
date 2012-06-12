using System.Activities;
using System.Collections.Generic;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace Unity.WF
{
    public interface IWorkflowConfiguration : IUnityContainerExtensionConfigurator { }

    public sealed class WorkflowExtension : UnityContainerExtension, IWorkflowConfiguration
    {
        protected override void Initialize()
        {
            Context.Strategies.Add(
                new WorkflowBuildStrategy(Context), UnityBuildStage.PostInitialization);
        }
    }

    public class WorkflowBuildStrategy : BuilderStrategy
    {
        private IUnityContainer _container;

        public WorkflowBuildStrategy(ExtensionContext baseContext)
        {
            _container = baseContext.Container;
        }

        public override void PostBuildUp(IBuilderContext context)
        {
            var derivedFromActivity = typeof(Activity).IsAssignableFrom(context.BuildKey.Type);
            if (!derivedFromActivity)
                return;

            var rootActivity = (Activity)context.Existing;
            BuildUpChildActivities(rootActivity);
        }

        private void BuildUpChildActivities(Activity root)
        {
            IEnumerable<Activity> activities =
                WorkflowInspectionServices.GetActivities(root);

            foreach (var activity in activities)
            {
                var type = activity.GetType();

                var systemActivities =
                    type.Namespace.StartsWith("System.") || type.Namespace.StartsWith("Microsoft.");

                if (!systemActivities)
                    _container.BuildUp(type, activity);

                BuildUpChildActivities(activity);
            }
        }
    }
}
