# AGENTS.md — ProPresenterClone Workspace Guide

This document provides essential instructions, build commands, verification patterns, architectural conventions, and styling rules for AI coding agents and developers working in `d:\ProPresenterClone`.

---

## 1. Workspace Overview

This repository contains two primary parts:

1. **Runnable ProPresenter 7 Desktop Application (`app\ProPresenterClone\`)**:
   - A standalone C# `.NET 9.0` WPF application compiled into `bin\ProPresenterClone.exe` and `bin\ProPresenterClone.dll`.
   - Powered directly by Renewed Vision's `Pro.SerializationInterop.dll` and `Google.Protobuf.dll` for authentic `.pro` presentation and theme serialization.
2. **Decompiled ProPresenter Reference Source (`src\`)**:
   - All 39 managed ProPresenter `.NET 9` assemblies (`ProPresenter.UI`, `Pro.UI`, `ProPresenter.DO`, `Pro.SerializationInterop`, etc.) decompiled into `10,374` `.cs` files and `636` `.xaml` views/styles.
   - **Read-Only Reference**: Treat `src\` strictly as a reference for inspecting official ProPresenter XAML layouts, vector path geometries (`src\ProPresenter.UI\resources\paths\paths.xaml`), view models, and behavior. All active development happens in `app\ProPresenterClone\`.

### Directory Map

| Path | Purpose |
| :--- | :--- |
| `app\ProPresenterClone\` | Main C# .NET 9 WPF application source code |
| `app\ProPresenterClone\Models\` | Domain models (`ProModels.cs`: presentations, slides, elements, playlists, output state) |
| `app\ProPresenterClone\Serialization\` | Native `.pro` & Theme Protobuf reader/writer and RTF parser (`ProFileService.cs`) |
| `app\ProPresenterClone\Rendering\` | 16:9 slide and multi-layer output compositor (`SlideCanvasRenderer.cs`) |
| `app\ProPresenterClone\Services\` | Bible scripture lookup service across KJV, WEB, Vietnamese, and German (`BibleService.cs`) |
| `app\ProPresenterClone\Theming\` | `.theme` parser (`dark.theme` / `light.theme`), brush cache, and icon loader (`ThemeEngine.cs`) |
| `app\ProPresenterClone\UI\` | `MainWindow` partial classes and custom WPF controls (`ToggleSwitchControl.cs`) |
| `app\ProPresenterClone\Windows\` | Secondary windows & dialogs (`AudienceWindow.cs`, `StageWindow.cs`, `SettingsWindow.cs`, `ScreenConfigurationWindow.cs`, `NewPresentationDialog.cs`) |
| `assets\` | Extracted ProPresenter `.theme` files, 594 UI icons, sample `.pro` libraries, and `ProPresenter.ico` |
| `src\` | Read-only decompiled ProPresenter 7 reference source (`ProPresenter.UI`, `Pro.UI`, etc.) |
| `bin\` | Build output directory (`ProPresenterClone.exe`, `ProPresenterClone.dll`, interop DLLs) — git-ignored |
| `build.ps1` | Primary build script invoking Visual Studio 2022 Roslyn `csc.exe` against `.NET 9.0.13` |
| `Run-ProPresenterClone.bat` | Launches `bin\ProPresenterClone.exe` |

---

## 2. Build & Run Commands

### Critical Build Rule: Always Use `build.ps1`

> **IMPORTANT**: Do **NOT** use `dotnet build` to compile this project. The system `dotnet` CLI on `PATH` resolves to an older .NET Core 3.1 SDK that does not recognize `net9.0-windows` (`NETSDK1013`). Always build using `build.ps1`.

```powershell
# Compile ProPresenterClone.dll and generate native bin\ProPresenterClone.exe
powershell -ExecutionPolicy Bypass -File d:\ProPresenterClone\build.ps1
```

How `build.ps1` works:
- Collects `.NET 9.0.13` (`Microsoft.NETCore.App` and `Microsoft.WindowsDesktop.App`) reference assemblies from `C:\Program Files\dotnet\shared\`.
- Copies `Pro.SerializationInterop.dll` and `Google.Protobuf.dll` from `C:\Program Files\Renewed Vision\ProPresenter` into `bin\`.
- Compiles all `.cs` files under `app\ProPresenterClone\` using Roslyn `csc.exe` (`Visual Studio 2022 BuildTools`) with `/langversion:latest`, `/nullable:enable`, and `/optimize+`.
- Generates `bin\ProPresenterClone.runtimeconfig.json` and patches the native `.NET 9` apphost executable `bin\ProPresenterClone.exe`.

> **Rule for Agents**: Whenever you modify any `.cs` file in `app\ProPresenterClone\`, you **must** run `build.ps1` so `bin\ProPresenterClone.exe` and `bin\ProPresenterClone.dll` are updated before finishing your turn.

### Running the Application

```powershell
# Launch the GUI application
d:\ProPresenterClone\bin\ProPresenterClone.exe
# or via batch launcher:
d:\ProPresenterClone\Run-ProPresenterClone.bat
```

---

## 3. Test & Verification Patterns

The project includes a built-in headless/STA verification suite in [`Program.cs`](app/ProPresenterClone/Program.cs) triggered via the `--verify` flag.

### Running the Verification Suite

```powershell
cmd /c "d:\ProPresenterClone\bin\ProPresenterClone.exe --verify"
```

### What `--verify` Tests

`Program.RunVerificationSuite()` runs on an `[STAThread]` and verifies:
1. **Theme Engine Initialization**: Loads `dark.theme` and resolves `AssetsRoot`.
2. **Library `.pro` Loading**: Parses all native `.pro` Protobuf presentations from `Documents\ProPresenter\Libraries\Default` and `assets\sample-libraries`.
3. **Theme Template Loading**: Loads sample themes via `ProFileService.LoadSampleThemes()`.
4. **Slide & Group Fidelity**: Verifies slide and cue group counts on reference presentations (e.g., `Christ Is Enough`).
5. **Bible Service Lookup**: Queries multi-verse scripture ranges (e.g., `John 3:16-17`).
6. **Protobuf `.pro` Round-Trip Serialization**: Saves a presentation to a temporary `.pro` file via `ProFileService.SaveProFile()` and reloads it via `ProFileService.LoadProFile()` to ensure zero data loss.
7. **STA Window & Control Tree Instantiation**: Instantiates `MainWindow`, `SettingsWindow` (cycling through all 14 settings pages), `ScreenConfigurationWindow`, and `NewPresentationDialog` to ensure all XAML templates, vector paths, and WPF visual trees construct without runtime exceptions.

### Adding New Tests

- When adding a new window, dialog, service, or serialization feature, add a verification step inside `Program.RunVerificationSuite()` in [`app/ProPresenterClone/Program.cs`](app/ProPresenterClone/Program.cs).
- Always run `cmd /c "d:\ProPresenterClone\bin\ProPresenterClone.exe --verify"` after building and confirm `=== ALL CHECKS PASSED ===` with exit code `0`.

---

## 4. Frameworks & Architecture Conventions

### Target Framework & Libraries
- **Runtime**: `.NET 9.0` (`net9.0-windows`) with **WPF** (`System.Windows.*`).
- **Protobuf Serialization**: Uses `Pro.SerializationInterop.RVProtoData` (`Presentation`, `Cue`, `Slide`, `Action`, `Graphics`, `Template`) and `Google.Protobuf`.
  - When both `System.Windows.Media.Color` and `Pro.SerializationInterop.RVProtoData.Color` are in scope, alias them explicitly:
    ```csharp
    using WpfColor = System.Windows.Media.Color;
    using RvColor = Pro.SerializationInterop.RVProtoData.Color;
    ```

### Partial Class Architecture for `MainWindow`
`MainWindow` (`namespace ProPresenterClone.UI`) is split into focused partial class files by functional area:
- [`MainWindow.cs`](app/ProPresenterClone/UI/MainWindow.cs): Window lifecycle, top toolbar (`ToolbarLayout`), 3-column workspace grid, left column (`Libraries`, `Playlists`, presentation dropdown, and bottom `Filter` bar), keyboard shortcuts, and output triggering.
- [`MainWindow.MenuBar.cs`](app/ProPresenterClone/UI/MainWindow.MenuBar.cs): Custom window chrome, top menu bar (`File`, `Edit`, `Presentation`, `Screens`, `View`, `Window`, `Help`), and menu command handlers.
- [`MainWindow.ShowView.cs`](app/ProPresenterClone/UI/MainWindow.ShowView.cs): Center presentation header, slide thumbnail grid & table view, slide right-click context menu (`SlideMenuSource.xaml` replica), bottom `ViewerStatusBar` (transitions, view mode toggles, `FillSlider`), and media bin.
- [`MainWindow.Editors.cs`](app/ProPresenterClone/UI/MainWindow.Editors.cs): Inline views (`Edit` WYSIWYG slide canvas & inspector, `Reflow` editor, `Themes` editor, `Bibles` scripture lookup, `More` / CCLI / Stage layout editors).
- [`MainWindow.RightDock.cs`](app/ProPresenterClone/UI/MainWindow.RightDock.cs): Live 16:9 Audience/Stage preview monitor, 8-layer Clear button bank, Media/Audio transport bar, 6-tab Show Controls (`Timers`, `Messages`, `Props`, `Stage`, `Macros`, `Audio`), and bottom item/duration status bar.

### Code-First WPF + Inline XAML Templates
- Because `build.ps1` compiles `.cs` files directly via `csc.exe` without a BAML XAML markup compilation step, all Windows and UI views are constructed in **C# code-first WPF**.
- When custom WPF `ControlTemplate`s or `Style`s are needed (such as dark `ContextMenu`/`MenuItem` popups without white Win32 gutters, or the custom `FillSlider`), parse them at runtime with `System.Windows.Markup.XamlReader.Parse(xaml)` and cache the resulting `ResourceDictionary` or `ControlTemplate` in a static field (see `GetDarkMenuResourceDictionary()` and `GetProFillSliderTemplate()` in `MainWindow.ShowView.cs`).

### Consulting Decompiled ProPresenter Reference (`src\`)
- Before implementing or redesigning any ProPresenter UI component, inspect the corresponding decompiled XAML/C# file in `src\ProPresenter.UI\` or `src\Pro.UI\`:
  - Slide Context Menu: `src\ProPresenter.UI\ProPresenter\UI\PresentationView\SlideMenuSource.xaml`
  - Bottom Viewer Status Bar: `src\ProPresenter.UI\ProPresenter\UI\PresentationView\ViewerStatusBar.xaml`
  - Transition Segmented Buttons: `src\ProPresenter.UI\ProPresenter\UI\Transitions\SegmentedButton.xaml`
  - Library & Filter Controls: `src\ProPresenter.UI\ProPresenter\UI\LibraryView\LibraryView.xaml`
  - Official Vector Paths: `src\ProPresenter.UI\resources\paths\paths.xaml`

---

## 5. Coding & UI Style Rules

### C# Coding Conventions
- **Language & Nullability**: C# latest with `#nullable enable` project-wide. Avoid compiler warnings and guard nullable references appropriately.
- **Naming**:
  - `PascalCase` for classes, methods, properties, constants, and public fields.
  - `_camelCase` for private instance fields.
  - `camelCase` for local variables and parameters.
- **Event Handlers**: Use concise lambdas (`(_, _) => ...` or `(_, e) => ...`) for UI event wiring.

### ProPresenter 7 Visual & Theme Standards
Maintain strict visual fidelity to ProPresenter 7's dark UI theme:
- **Theme Engine**: Prefer `ThemeEngine.Instance.GetBrush("KEY", fallbackColor)` and `ThemeEngine.Instance.GetIcon("relative/path.png")` when accessing theme tokens or icons.
- **Core Surface Palette**:
  - Window / Header Chrome: `#121212` – `#18181B`
  - Main Workspace / Canvas Background: `#1E1E22`
  - Panel / Outline Detail Surface: `#232429` – `#2F2F2F`
  - Dividers & Subtle Borders: `#2D2D35` – `#383842`
  - Context Menu Surface: `#3C3C40` background, `#56565C` border, `#255999` hover highlight
- **Accent & Semantic Colors**:
  - **Active UI Selection / Grid & Table Mode Toggle / FillSlider Track**: `#007AFF` (ProPresenter Blue)
  - **Foreground Slide Transitions (`Cut` / `Dissolve` / `Advanced`)**: `#FF9500` (Orange)
  - **Background Media Transitions (`Cut` / `Dissolve` / `Advanced`)**: `#AF52DE` (Purple)
  - **Live Triggered Slide Border**: `#33FD00` (Vibrant Green)
  - **Selected Presentation / Stage Accent**: `#F7821C` (Orange)
  - **Active Layer Clear Button**: `#571B1B` fill with `#E53935` indicator
- **Context Menus**: Always assign `menu.Resources = GetDarkMenuResourceDictionary();` on every `ContextMenu` so top-level menus and nested submenus (`PART_Popup`) render with ProPresenter's dark theme rather than default white system chrome.
- **Vector Icons**: Use `System.Windows.Shapes.Path` with `Geometry.Parse(...)` and `Stretch = Stretch.Uniform` using path figures from `src\ProPresenter.UI\resources\paths\paths.xaml` for crisp rendering at any DPI.

