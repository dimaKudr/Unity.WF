using System.Activities;
using Microsoft.Practices.Unity;

namespace Unity.WF.SampleActivities
{
    public sealed class FirstCalculatorActivity : CodeActivity
    {
        [Dependency]
        public ICalcService Calculator { get; set; }

        public InArgument<int> A { get; set; }
        public InArgument<int> B { get; set; }

        public OutArgument<int> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var a = context.GetValue(A);
            var b = context.GetValue(B);

            var result = Calculator.Add(a, b);

            Result.Set(context, result);
        }
    }
}
