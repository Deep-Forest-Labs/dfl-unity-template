# DFL Unity Template

A ready-to-go Unity project template pre-configured with all Deep Forest Labs packages, OpenUPM dependencies, and a minimal app scaffold.

## Prerequisites

- **Unity 2022.3 LTS** or later
- **GitHub access** to [dfl-unity-packages](https://github.com/Deep-Forest-Labs/dfl-unity-packages) (private repo)
- **Git credentials** configured -- run `gh auth login` or ensure [Git Credential Manager](https://github.com/git-ecosystem/git-credential-manager) is installed

## Quick Start

```bash
git clone https://github.com/Deep-Forest-Labs/dfl-unity-template.git
cd dfl-unity-template
```

Open the project in Unity Hub. On first open, Unity will resolve all packages via Git URLs -- no additional repositories need to be cloned.

## What's Included

- All DFL packages (framework, audio, build system, logger) pinned to `v1.0.0`
- OpenUPM scoped registry for UniTask, ZString, and ZLinq
- `MainArgs` asset at `Assets/Resources/MainArgs`
- `AppContainerFactory` scaffold at `Assets/Scripts/AppContainerFactory.cs`
- `AppState` entry point at `Assets/Scripts/AppState.cs`
- Sentry error reporting integration
- NuGetForUnity + ZLinq drop-in generator

## Creating a New Game From This Template

1. Use GitHub's "Use this template" button or clone and re-init:
   ```bash
   git clone https://github.com/Deep-Forest-Labs/dfl-unity-template.git my-game
   cd my-game
   rm -rf .git && git init
   ```
2. Open in Unity
3. Run the **Project Setup Wizard** (menu: Deep Forest Labs > Project Setup) to rename assemblies and configure your project identity
4. Start building services in `AppContainerFactory`

## Local Package Development

To edit DFL packages alongside your game, temporarily replace a Git URL in `Packages/manifest.json` with a local `file:` path:

```json
"com.deepforestlabs.framework": "file:../../dfl-unity-packages/Packages/com.deepforestlabs.framework"
```

This requires [dfl-unity-packages](https://github.com/Deep-Forest-Labs/dfl-unity-packages) cloned as a sibling directory. Revert to the Git URL before committing.

## Store CI (mobile)

Ghostgarden is the proof consumer for store builds. To add the same pattern to a new game:

1. Set iOS/Android bundle IDs and portrait-only orientation in Project Settings
2. Copy `ci/` (envlist, scripts, README) and `.github/workflows/store-build.yml` from [dfl-ghostgarden](https://github.com/Deep-Forest-Labs/dfl-ghostgarden)
3. Register (or reuse) the Deep Forest Labs org self-hosted Mac runner labels: `self-hosted`, `macOS`, `unity`, `store-ci`
4. Configure per-repo GitHub Actions secrets listed in ghostgarden `ci/README.md`
5. Keep using `AddPlatformServices` from `com.deepforestlabs.platform`

### Firebase Analytics + Remote Config (optional)

The template stays on `PlatformServiceOptions.Null`. To opt a game into Firebase (ghostgarden is the reference):

1. Create a per-game Firebase project; commit `google-services.json` + `GoogleService-Info.plist`
2. Install Firebase Unity App + Analytics + Remote Config (see [ghostgarden ci/firebase.md](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/blob/master/ci/firebase.md))
3. Switch device builds to `AddPlatformServices(PlatformServiceOptions.Firebase)` (keep Editor on `Null`)
4. Keep **Sentry** for crashes/errors — do not wire `IAnalyticsErrorHelper` to Firebase
5. Config / force-update opt-in (E3):
   - RC key `min_required_version` (string; console default `1.0.0`)
   - Override `IBootConfigClient` in App scope with a local catalog → `BootSnapshot` mapping (no managed economy JSON required)
   - App-scope gate: parallel RC refresh ∥ boot fetch → `AppVersionGate` → Update Required UI
   - Debug offline escape: `NOT_RELEASE_BUILD` + PlayerPrefs `dfl.debug.allow_offline_boot`
6. Tracking for wiring this into the template project itself: [dfl-unity-template#1](https://github.com/Deep-Forest-Labs/dfl-unity-template/issues/1)
7. Account / cloud save opt-in (E6):
   - Install `com.google.firebase.auth` + `com.google.firebase.firestore` (same tarball script as Analytics / RC)
   - Device `PlatformServiceOptions.Firebase` registers Auth + Firestore adapters; Editor stays `Null`
   - Game owns save schema and Settings account chrome (status, email/password, Create / Sign in / Sign out / Forgot password, conflict)
   - Local-authoritative: upload after save; download on Sign in or empty local; ask **Use cloud** vs **Keep this device** when both have progress
   - Apple / Google Sign-In later (needs store accounts / bundle IDs)
   - Reference: [ghostgarden ci/firebase.md](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/blob/master/ci/firebase.md), [platform.md](https://github.com/Deep-Forest-Labs/dfl-unity-packages/blob/master/docs/platform.md) Account / Cloud save, epic [#35](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/issues/35)
8. Ads / MAX opt-in (E4):
   - Stay on `NullAdService` until AppLovin MAX signup (needs a live store URL)
   - Game App scope (after ATT) registers `IAdPlacementConfig` + `IMaxSdkClient` + `MaxAdService`; keep Editor on Null
   - MAX plugin + `DFL_MAX_SDK` live in the game — do not commit the plugin or the define until MAX is a real dependency
   - Reference: [ghostgarden ci/ads-max.md](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/blob/master/ci/ads-max.md), [platform.md](https://github.com/Deep-Forest-Labs/dfl-unity-packages/blob/master/docs/platform.md) Ads, epic [#33](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/issues/33)

The template itself does **not** upload to TestFlight/Play. DFL packages resolve from GitHub `dfl-unity-packages` (`#master` for framework / buildsystem / platform — `com.deepforestlabs.platform` is not on `v1.0.0`). Use a local `file:` path only while editing packages.

Also see [platform.md](https://github.com/Deep-Forest-Labs/dfl-unity-packages/blob/master/docs/platform.md) and [build-system.md](https://github.com/Deep-Forest-Labs/dfl-unity-packages/blob/master/docs/build-system.md).

## Updating Packages

When a new version is tagged in `dfl-unity-packages` (e.g. `v1.1.0`), update the tag suffix in `Packages/manifest.json`:

```
#v1.0.0  -->  #v1.1.0
```

If Unity doesn't pick up the change, delete the affected entries from `Packages/packages-lock.json` and reopen the project.

## Documentation

Full package documentation lives in the [dfl-unity-packages docs/](https://github.com/Deep-Forest-Labs/dfl-unity-packages/tree/main/docs) folder.
