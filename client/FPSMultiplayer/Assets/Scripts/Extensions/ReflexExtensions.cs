using Reflex.Core;

namespace Extensions
{
    public static class ReflexExtensions
    {
        public static ContainerBuilder AddSingleton<TImplementation>(this ContainerBuilder builder) => 
            builder.AddSingleton(typeof(TImplementation));

        public static ContainerBuilder AddSingleton<TInterface, TImplementation>(this ContainerBuilder builder)
            where TImplementation : TInterface =>
            builder.AddSingleton(typeof(TImplementation), typeof(TInterface));

        public static ContainerBuilder AddTransient<TImplementation>(this ContainerBuilder builder) => 
            builder.AddTransient(typeof(TImplementation));
    }
}