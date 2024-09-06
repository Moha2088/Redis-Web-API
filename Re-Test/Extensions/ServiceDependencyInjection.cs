namespace Re_Test.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static void AddServiceDependencyInjection(this IServiceCollection service)
        {
            service.Scan(x =>
            {
                x.FromAssemblyOf<IDependencyAnchor>()
                .AddClasses(classes => classes
                .Where(cl => cl.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
            });
        }
    }
}
