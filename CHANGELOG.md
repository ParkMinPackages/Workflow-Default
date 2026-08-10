# Changelog
All notable changes to this package will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/)
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [7.0.2] - 2026-08-10

### Added
- Added metadata for the required empty `Actors` folder.

### Changed
- Updated the reusable UIs preset package after removing the default message UI implementations.

## [7.0.1] - 2026-08-10

### Changed
- Renamed the button-based confirmation implementation method from `ConfirmByButtonAsync` to `ConfirmAsyncByButton` for implementation-name consistency.

## [7.0.0] - 2026-08-10

### Breaking Changes
- Removed the default `MessageUI` and `YesOrNoUI` components so applications can provide UI implementations suited to their own presentation requirements.

### Added
- Added composable interfaces and shared implementations for messages, icons, confirmation, yes-or-no answers, and layout rebuilding.
- Added `WithMessage` and `WithIcon` fluent extensions that preserve the concrete receiver type regardless of chaining order.
- Added reusable message and yes-or-no UI flow extensions.
- Added the standalone `YesOrNo` result enum.

### Changed
- Added the direct TextMesh Pro assembly reference required by TMP-based message views.

## [6.1.0] - 2026-07-29

### Added
- Added the reusable `UIRoot` actor component.
- Added `CanvasResolutionHelper` for configuring CanvasScaler and UI root dimensions.

### Changed
- Updated the UIs and WorkSpace preset packages with current namespaces, Foundation components, and Main Canvas structure.
- Updated the Foundation dependency to `5.2.0`.
## [6.0.0] - 2026-07-28

### Breaking Changes
- Moved `EditorPlayBehaviour`, `InstantiateOnceOnRuntime`, and `TargetFrameSetting` to Foundation and changed their namespaces to `ParkMinPackages.Foundation.Components`.

### Changed
- Updated the Foundation dependency to `5.1.0`.

## [5.1.0] - 2026-07-25

### Changed
- Repackaged the reusable UI and workspace presets as importable `UIs.unitypackage` and `WorkSpace.unitypackage` assets.
- Removed the unpacked preset source assets now distributed through the Unity packages.

## [5.0.0] - 2026-07-25

### Breaking Changes
- Changed runtime and editor namespaces to the `ParkMinPackages.Workflow.Default` convention.

### Added
- Added the Actor, binding, UI, editor-play, bootstrap, and target-frame workflow components.
- Added reusable UI and general project presets.
- Added project context menus for Scripts and Domain folder structures.
- Added Build Settings Profile creation, capture, and safe application workflows.

### Changed
- Added explicit dependencies on Foundation, UGUI, UniTask, R3, Input System, and Unity UGUI.
## [1.0.0] - 2026-07-25

### Added
- Added the initial Unity package and assembly structure.
