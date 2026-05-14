#nullable enable
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DeepForestLabs.Logger;
using DeepForestLabs.States.Error.Controllers;

public sealed class NullErrorController : IErrorStateController
{
    public UniTask Run(Exception args, CancellationToken token)
    {
        Log.Exception(args, "[ErrorController] Unhandled exception");
        return UniTask.CompletedTask;
    }
}
#nullable disable
