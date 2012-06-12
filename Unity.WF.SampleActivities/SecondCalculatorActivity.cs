using System.Activities;

namespace Unity.WF.SampleActivities
{
    public sealed class SecondCalculatorActivity : CodeActivity
    {
        public ICalcService Calculator { get; set; }

        public InArgument<int> A { get; set; }
        public InArgument<int> B { get; set; }

        public OutArgument<int> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            InitializeDependencies(context);

            var a = context.GetValue(A);
            var b = context.GetValue(B);

            var result = Calculator.Add(a, b);

            Result.Set(context, result);
        }

        private void InitializeDependencies(ActivityContext context)
        {
            Calculator = context.GetDependency<ICalcService>();
        }
    }
}
