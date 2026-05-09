#nullable enable
using Cysharp.Threading.Tasks;
using DeepForestLabs;
using DeepForestLabs.Factories;
using UnityEngine;

public sealed class AppContainerFactory : ContainerBuilderFactory
{
    public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
    {
        return builder
            .PushToServiceLocator()
            .PushRequestScope()
            .AddTransient<AppState>();
    }
}
#nullable disable
