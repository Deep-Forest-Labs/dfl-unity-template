#nullable enable
using System;
using DeepForestLabs;
using DeepForestLabs.Logger;

public sealed class AppMain : IMain
{
    public void Start()
    {
        Log.Info("[AppMain] Start");
    }

    public void PreRestart()
    {
        Log.Info("[AppMain] PreRestart");
    }

    public void ShowingErrorPopup(Exception unhandled)
    {
        Log.Error("[AppMain] ShowingErrorPopup: {0}", unhandled.Message);
    }

    public void DismissingErrorPopup(Exception unhandled)
    {
        Log.Info("[AppMain] DismissingErrorPopup");
    }

    public void PostRestart()
    {
        Log.Info("[AppMain] PostRestart");
    }
}
#nullable disable
