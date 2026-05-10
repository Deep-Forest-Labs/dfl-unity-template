#nullable enable
using Cysharp.Threading.Tasks;
using DeepForestLabs;
using DeepForestLabs.Factories;
using UnityEngine;

namespace GameName.Factories {
    public sealed class AppContainerFactory : ContainerBuilderFactory
    {
        public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
        {
            return builder
                .AddTransient<AppState>();
        }
    }
}
#nullable disable
