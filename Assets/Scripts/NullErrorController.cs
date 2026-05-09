#nullable enable
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DeepForestLabs;

public sealed class NullErrorController : IErrorStateController
{
    public UniTask Run(Exception args, CancellationToken token) => UniTask.CompletedTask;
}
#nullable disable
