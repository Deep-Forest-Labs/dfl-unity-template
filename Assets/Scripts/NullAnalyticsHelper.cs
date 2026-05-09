#nullable enable
using DeepForestLabs;
using UnityEngine;

public sealed class NullAnalyticsHelper : IAnalyticsErrorHelper
{
    public void Log(string condition, string? stackTrace, LogType type) { }
}
#nullable disable
