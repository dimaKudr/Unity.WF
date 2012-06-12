using System.Activities;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Unity.WF;
using Unity.WF.SampleActivities;

namespace Unity.WF.Tests
{
    [TestFixture]
    public sealed class WorkflowExtensionTests
    {
        private IUnityContainer _container;

        [TestFixtureSetUp]
        public void Initialise()
        {
            _container = new UnityContainer();

            _container.RegisterType<ICalcService, CalcService>();
        }

        ///<summary>
        /// For simple code activities instanciated manualy all dependencies
        /// should be resolved without any additional extensions.
        ///</summary>
        [Test]
        public void SimpleCodeActivityInjectedByUnityContainer()
        {
            var activity = _container.Resolve<FirstCalculatorActivity>();

            var activityArgs = new Dictionary<string, object>
            {
                { "A", 21 }, { "B", 21 }
            };

            var results = new WorkflowInvoker(activity).Invoke(activityArgs);

            Assert.AreEqual(42, (int)results["Result"]);
        }

        ///<summary>
        /// For xaml-driven composite activities external dependencies
        /// could be injected using Workflow extension.
        ///</summary>
        [Test]
        public void CompositeActivityInjectedByWorkflowExtension()
        {
            var activity = _container.Resolve<CompositeActivity>();

            var diExtension = new DependencyInjectionExtension(_container);

            var wfInvoker = new WorkflowInvoker(activity);
            wfInvoker.Extensions.Add(diExtension);

            var results = wfInvoker.Invoke();

            Assert.AreEqual(45, (int)results["CompositeResult"]);
        }

        ///<summary>
        /// For xaml-driven composite activities external dependencies
        /// could be injected using Unity extension.
        ///</summary>
        [Test]
        public void CompositeActivityInjectedByUnityExtension()
        {
            _container.AddNewExtension<WorkflowExtension>();

            var activity = _container.Resolve<CompositeActivity2>();

            var wfInvoker = new WorkflowInvoker(activity);

            var results = wfInvoker.Invoke();

            Assert.AreEqual(45, (int)results["CompositeResult"]);
        }
    }
}
