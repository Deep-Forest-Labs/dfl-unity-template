#nullable enable
using DeepForestLabs;
using DeepForestLabs.BuildSystems;
using DeepForestLabs.States.Error.Controllers;

public sealed class MainArgs : DeepForestLabs.MainArgs
{
    public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
    {
        return base.AddToBuilder(builder)
            .AddSingleton(BuildSettings.Instance)
            .AddScoped<IMain, AppMain>()
            .AddScoped<IAnalyticsErrorHelper, NullAnalyticsHelper>()
            .AddScoped<IErrorStateController, NullErrorController>();
    }
}
#nullable disable
