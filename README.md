# Deep Forest Labs Unity Template

A bootstrapped Unity 6.4 LTS project template with the DFL DI/MVC framework pre-configured and ready to go.

## What's included

- **DI container** with parent-child scoping and request scopes
- **MVC architecture** with reactive model binding and view pooling
- **Async lifecycle** powered by UniTask with CancellationToken scoping
- **Addressables management** for asset loading with configurable load strategy
- **Multi-platform build system** supporting Android, iOS, Windows Standalone, and WebGL
- **Error reporting** via `IErrorReporter` abstraction (Sentry by default)
- **Structured logging** with compile-time stripping and runtime filtering

## Supported Platforms

| Platform | Build Target | Notes |
|----------|-------------|-------|
| Android | `BuildTarget.Android` | APK/AAB, Gradle, keystore signing |
| iOS | `BuildTarget.iOS` | Xcode project generation, ATT, Bitcode |
| Windows | `BuildTarget.StandaloneWindows64` | IL2CPP `.exe` output |
| WebGL | `BuildTarget.WebGL` | IL2CPP, configurable compression |

## Getting started

### 1. Clone this repo

```bash
git clone https://github.com/Deep-Forest-Labs/dfl-unity-template.git MyNewGame
cd MyNewGame
rm -rf .git
git init
```

### 2. Open in Unity

Open the project in **Unity 6.4 LTS** (6000.4.3f1 or compatible).

On first open, Unity will resolve packages from `Packages/manifest.json`. The three framework packages are referenced via local `file:` paths pointing to a sibling `dfl-unity-packages` checkout. Ensure both repos are cloned as siblings:

```
parent/
  dfl-unity-packages/
  dfl-unity-template/   (this repo)
```

### 3. Verify ScriptableObject assets

The following assets in `Assets/Resources/` should load correctly:

| Asset | Script | Purpose |
|-------|--------|---------|
| `MainArgs.asset` | `MainArgs.cs` | Root DI container configuration |
| `LogFilter.asset` | `LogFilter` (from logger package) | Runtime log filtering |
| `AppContainer.asset` | `AppContainerFactory.cs` | App-scope DI container |

`BuildSettings.asset` is auto-created by the build system's `InitializeOnLoad` hook when Unity opens.

If any asset shows a "Missing Script" warning, right-click it and reimport, or delete and recreate it via **Create > ScriptableObject** in the Project window.

### 4. Configure your target platform

1. **Switch platform** via File > Build Settings
2. **Set orientation** in `BuildSettings.asset` (defaults to Portrait)
3. **Set asset load strategy** in `BuildSettings.asset` — `RemoteCDN` (default) or `LocalBundles` for offline/WebGL builds
4. **Error reporting** is configured in `MainArgs.cs` — defaults to `SentryErrorReporter`. Swap to `NullErrorReporter` for platforms without Sentry support.

### 5. Start building

Edit `AppState.cs` to add your game logic. Register new states and services in `AppContainerFactory.cs`. The framework boots automatically via the `MainArgs` → `MainState` lifecycle.

## Project structure

```
Assets/
  Scripts/
    MainArgs.cs               — root DI container (registers BuildSettings, IMain, IErrorReporter, stubs)
    AppMain.cs                 — IMain implementation (lifecycle hooks)
    AppState.cs                — first IRunnable after boot (your game starts here)
    AppContainerFactory.cs     — app-scope container (register your states/services)
    NullAnalyticsHelper.cs     — no-op IAnalyticsErrorHelper
    NullErrorController.cs     — no-op IErrorStateController
  Resources/
    MainArgs.asset             — MainArgs ScriptableObject instance
    LogFilter.asset            — log filter configuration
    AppContainer.asset         — app container factory instance
  Scenes/
    Boot.unity                 — empty boot scene (build index 0)
Packages/
  manifest.json                — UPM dependencies (framework via file: paths)
ProjectSettings/               — Unity 6.4 LTS project settings
```

## Package dependencies

The framework packages are sourced from [`dfl-unity-packages`](https://github.com/Deep-Forest-Labs/dfl-unity-packages):

- `com.deepforestlabs.framework` — core DI/MVC/async framework
- `com.deepforestlabs.logger` — structured logging
- `com.deepforestlabs.buildsystem` — multi-platform build pipeline and environment config

## Notes

### System.Runtime.CompilerServices.Unsafe.dll

Unity 6000.4 ships `System.Runtime.CompilerServices.Unsafe` as part of its managed runtime. The copy in `Assets/Plugins/` was added for compatibility with older Unity versions. If you encounter IL2CPP conflicts on WebGL or Standalone builds, remove `Assets/Plugins/System.Runtime.CompilerServices.Unsafe.dll` and its `.meta` file.

## License

Copyright © 2024 Deep Forest Labs. All rights reserved.
