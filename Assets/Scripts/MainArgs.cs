#nullable enable
using DeepForestLabs;
using DeepForestLabs.BuildSystems;

public sealed class MainArgs : DeepForestLabs.MainArgs
{
    public override IContainerBuilder AddToBuilder(IContainerBuilder builder)
    {
        return base.AddToBuilder(builder)
            .AddSingleton(BuildSettings.Instance)
            .AddSingleton<IMain, AppMain>()
            .AddSingleton<IAnalyticsErrorHelper, NullAnalyticsHelper>()
            .AddSingleton<IErrorStateController, NullErrorController>();
    }
}
#nullable disable
