using System.Activities;

namespace Unity.WF
{
    public static class ActivityContextExtension
    {
        public static T GetDependency<T>(this ActivityContext context)
        {
            var diExtension = context.GetExtension<DependencyInjectionExtension>();

            return diExtension.GetDependency<T>();
        }
    }
}
