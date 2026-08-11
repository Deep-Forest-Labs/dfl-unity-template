#nullable enable
using DeepForestLabs;
using DeepForestLabs.BuildSystems;
using DeepForestLabs.Platform;
using DeepForestLabs.Services;
using DeepForestLabs.States.Error.Controllers;

namespace GameName
{
    public sealed class MainArgs : DeepForestLabs.MainArgs
    {
        public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
        {
            return base.AddToBuilder(builder)
                .AddSingleton(BuildSettings.Instance)
                .AddScoped<IMain, AppMain>()
                .AddPlatformServices(PlatformServiceOptions.Null)
                .AddScoped<IErrorReporter, SentryErrorReporter>()
                .AddScoped<IErrorStateController, NullErrorController>();
        }
    }
}
#nullable disable
