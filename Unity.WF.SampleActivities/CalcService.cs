namespace Unity.WF.SampleActivities
{
    public sealed class CalcService : ICalcService
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
