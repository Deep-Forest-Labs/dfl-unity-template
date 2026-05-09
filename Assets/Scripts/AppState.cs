#nullable enable
using System.Threading;
using Cysharp.Threading.Tasks;
using DeepForestLabs;
using DeepForestLabs.Logger;

public sealed class AppState : IRunnable
{
    public async UniTask Run(CancellationToken token)
    {
        Log.Info("AppState started. Replace this with your game logic.");
        await UniTask.WaitUntilCanceled(token);
    }
}
#nullable disable
