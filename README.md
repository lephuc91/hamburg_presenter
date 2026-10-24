# ProPresenter Desktop Clone & Full Decompiled Source Repository

This workspace (`d:\ProPresenterClone`) contains both:

1. **Runnable ProPresenter Desktop Application (`bin\ProPresenterClone.exe` & `app\ProPresenterClone\`)** — A compilable, standalone C# .NET 9 WPF desktop application built directly on top of Renewed Vision's `Pro.SerializationInterop.dll` + `Google.Protobuf.dll`, theming system (`dark.theme` / `light.theme`), extracted UI icons, fonts, and `.pro` presentation library.
2. **Full Decompiled ProPresenter Source Solution (`src\ProPresenter.sln`)** — All **39 managed .NET 9 assemblies** from `C:\Program Files\Renewed Vision\ProPresenter` decompiled into **10,374 C# source files (`.cs`)**, **636 WPF XAML views/controls (`.xaml`)**, and **594 embedded icons/images**.

---

## Quick Start — Running the App

Double-click `d:\ProPresenterClone\Run-ProPresenterClone.bat` or run:

```powershell
d:\ProPresenterClone\bin\ProPresenterClone.exe
```

To rebuild from source at any time:

```powershell
powershell -ExecutionPolicy Bypass -File d:\ProPresenterClone\build.ps1
```

To run the automated verification & `.pro` Protobuf round-trip suite:

```powershell
dotnet d:\ProPresenterClone\bin\ProPresenterClone.dll --verify
```

---

## Directory Structure

| Path | Description |
| :--- | :--- |
| `bin\ProPresenterClone.exe` | Native Windows GUI `.NET 9.0` executable with the ProPresenter icon |
| `app\ProPresenterClone\` | Standalone compilable C# .NET 9 WPF ProPresenter clone source code |
| `src\ProPresenter.sln` | Full Visual Studio solution containing all 39 decompiled ProPresenter projects (`10,374` `.cs` files + `636` `.xaml` files) |
| `assets\themes\` | Official `dark.theme` and `light.theme` color & variable definitions |
| `assets\ui-icons\icons\` | 594 extracted UI icons (`clearlayer`, `toolbar`, `transportcontrols`, `slideelements`, `timers`, etc.) |
| `assets\sample-libraries\` | 24 real `.pro` worship presentations imported from `Documents\ProPresenter\Libraries\Default` |
| `assets\resources\` | Sample Themes, Masks, Stage Layouts, and shader resources (`GLSL`) |
| `build.ps1` | One-command build script using Visual Studio 2022 Roslyn `csc.exe` + `.NET 9.0.13` WPF references |

---

## Core Features Implemented in `ProPresenterClone`

- **Show View (`MainWindow.ShowView.cs`)**:
  - **Left Dock**: Libraries search & category filter + Service Playlists (`Sunday Morning Worship`, `Vietnamese & International Worship`) with colored section headers, presentations, and media cues.
  - **Center Presentation Grid & Table View**: 16:9 slide cards with ProPresenter's `#F7821C` active border (`THUMBNAILPRESENTATION`), group color strips, arrangement group pills, hotkeys, auto-advance slideshow timer, transition selector, and thumbnail zoom slider.
  - **Bottom Media Bin**: Procedural worship motion loops (`Midnight Sapphire Particles`, `Golden Amber Dust`, `Royal Violet Nebula`, etc.), video assets, still backgrounds from `Documents\ProPresenter\Media`, and Live Camera Video Input layer trigger.
- **Multi-Screen Output (`AudienceWindow.cs` & `StageWindow.cs`)**:
  - **Live Audience Output Window**: Multi-layer compositor (`Video Input -> Media Background -> Slide -> Props -> Stage/Audience Messages -> Clear to Logo`) with crossfade transitions, Lower-Thirds Look override, and fullscreen toggle (`Double-Click` or `F11`).
  - **Live Stage Display Confidence Monitor**: Real-time Wall Clock, Countdown/Elapsed Timers, Current Slide text, Next Slide preview, Chord/Sermon Notes, and Stage Alert Banner with 3 switchable stage layouts.
- **WYSIWYG Slide Editor & Reflow Editor (`MainWindow.Editors.cs`)**:
  - **Slide Editor**: Interactive 16:9 canvas with rule-of-thirds guides, click-and-drag element positioning, `+ Text Box`, `+ Lower-Third Bar`, `+ Countdown Token`, `+ Live Clock`, and a full Typography/Fill/Position Inspector.
  - **Reflow Editor**: Continuous lyric script editor with live side-by-side 16:9 slide thumbnails and `Split Slide` support.
- **Bible Scripture Lookup (`BibleService.cs` & `MainWindow.Editors.cs`)**:
  - Instant verse lookup and keyword search across **KJV**, **WEB**, **Vietnamese (Kinh Thánh Truyền Thống)**, and **German (Lutherbibel 1912)** with one-click live projection and `+ Save to Library & Open`.
- **Native `.pro` Protobuf Import/Export (`ProFileService.cs`)**:
  - Directly uses `Pro.SerializationInterop.dll` (`Pro.SerializationInterop.RVProtoData.Presentation`, `Cue`, `Slide`, `Graphics`, `Template`) and `Google.Protobuf.dll` to parse and write authentic `.pro` files and `Theme` templates, including full Unicode RTF decoding (`\uc1`, `\uN?`).
- **Right Dock Preview, 8 Layer Clear Buttons & Show Controls (`MainWindow.RightDock.cs`)**:
  - Live 16:9 Preview Monitor (toggleable between Audience & Stage views), vertical bank of **8 Layer Clear Buttons** (`All`, `Slide`, `Media`, `Props`, `Msgs`, `Audio`, `Video`, `Logo`) with active red glow (`#571B1B`), Media/Audio Transport Bar, and 6-tab Show Controls (`Timers`, `Messages`, `Props`, `Stage`, `Macros`, `Audio`).

