# Deep Forest Labs Unity Template

A bootstrapped Unity 6.4 LTS project template with the DFL DI/MVC framework pre-configured and ready to go.

## What's included

- **DI container** with parent-child scoping and request scopes
- **MVC architecture** with reactive model binding and view pooling
- **Async lifecycle** powered by UniTask with CancellationToken scoping
- **Addressables management** for asset loading
- **Build system** with environment configuration and multi-platform support
- **Sentry integration** for crash reporting
- **Structured logging** with compile-time stripping and runtime filtering

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

On first open, Unity will resolve packages from `Packages/manifest.json`. The three framework packages are pulled from the [`dfl-unity-packages`](https://github.com/Deep-Forest-Labs/dfl-unity-packages) repo via Git URLs pinned to `v1.0.0`.

### 3. Verify ScriptableObject assets

The following assets in `Assets/Resources/` should load correctly:

| Asset | Script | Purpose |
|-------|--------|---------|
| `MainArgs.asset` | `MainArgs.cs` | Root DI container configuration |
| `LogFilter.asset` | `LogFilter` (from logger package) | Runtime log filtering |
| `AppContainer.asset` | `AppContainerFactory.cs` | App-scope DI container |

`BuildSettings.asset` is auto-created by the build system's `InitializeOnLoad` hook when Unity opens.

If any asset shows a "Missing Script" warning, right-click it and reimport, or delete and recreate it via **Create > ScriptableObject** in the Project window.

### 4. Start building

Edit `AppState.cs` to add your game logic. Register new states and services in `AppContainerFactory.cs`. The framework boots automatically via the `MainArgs` → `MainState` lifecycle.

## Project structure

```
Assets/
  Scripts/
    MainArgs.cs               — root DI container (registers BuildSettings, IMain, stubs)
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
  manifest.json                — UPM dependencies (framework via Git URLs)
ProjectSettings/               — Unity 6.4 LTS project settings
```

## Package dependencies

The framework packages are sourced from [`dfl-unity-packages`](https://github.com/Deep-Forest-Labs/dfl-unity-packages):

- `com.deepforestlabs.framework` — core DI/MVC/async framework
- `com.deepforestlabs.logger` — structured logging
- `com.deepforestlabs.buildsystem` — build pipeline and environment config

To update to a newer version, change the `#v1.0.0` tag in `Packages/manifest.json`.

## License

Copyright © 2024 Deep Forest Labs. All rights reserved.
