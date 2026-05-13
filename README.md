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

## Updating Packages

When a new version is tagged in `dfl-unity-packages` (e.g. `v1.1.0`), update the tag suffix in `Packages/manifest.json`:

```
#v1.0.0  -->  #v1.1.0
```

If Unity doesn't pick up the change, delete the affected entries from `Packages/packages-lock.json` and reopen the project.

## Documentation

Full package documentation lives in the [dfl-unity-packages docs/](https://github.com/Deep-Forest-Labs/dfl-unity-packages/tree/main/docs) folder.
