using System;
using System.Linq;
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
        
        public static ContainerBuilder AddSingletonWithInterfacesAndSelf<TImplementation>(this ContainerBuilder builder)
        {
            var type = typeof(TImplementation);
            var interfaces = type.GetInterfaces();
            var contracts = new Type[interfaces.Length + 1];
            for (var i = 0; i < interfaces.Length; i++) 
                contracts[i] = interfaces[i];
            contracts[interfaces.Length] = type;
            return builder.AddSingleton(type, contracts);
        }

        public static ContainerBuilder AddTransient<TImplementation>(this ContainerBuilder builder) => 
            builder.AddTransient(typeof(TImplementation));
    }
}