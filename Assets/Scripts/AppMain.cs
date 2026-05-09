#nullable enable
using System;
using DeepForestLabs;

public sealed class AppMain : IMain
{
    public void Start() { }
    public void PreRestart() { }
    public void ShowingErrorPopup(Exception unhandled) { }
    public void DismissingErrorPopup(Exception unhandled) { }
    public void PostRestart() { }
}
#nullable disable
