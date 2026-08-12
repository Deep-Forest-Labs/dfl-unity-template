# Store CI stub

This template does not operate real App Store / Play uploads.

Copy the full store CI from [dfl-ghostgarden/ci](https://github.com/Deep-Forest-Labs/dfl-ghostgarden/tree/master/ci) and `.github/workflows/store-build.yml` when your game is ready for TestFlight / Play internal testing.

See the template root README § **Store CI (mobile)** and ghostgarden’s `ci/README.md` for secrets, runner labels, and identity checklist.

## Analytics / Remote Config

Stay on `PlatformServiceOptions.Null` until you add a Firebase project. Ghostgarden’s `ci/firebase.md` is the opt-in reference (SDK install, configs, ATT vs Sentry split, `min_required_version` + App boot gate). Template wiring tracked in [#1](https://github.com/Deep-Forest-Labs/dfl-unity-template/issues/1).
