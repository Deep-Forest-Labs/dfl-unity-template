#nullable enable
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DeepForestLabs.States.Error.Controllers;

public sealed class NullErrorController : IErrorStateController
{
    public UniTask Run(Exception args, CancellationToken token) => UniTask.CompletedTask;
}
#nullable disable
