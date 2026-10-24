$ErrorActionPreference = "Stop"

$repoRoot = "d:\ProPresenterClone"
$srcDir   = Join-Path $repoRoot "app\ProPresenterClone"
$binDir   = Join-Path $repoRoot "bin"
New-Item -ItemType Directory -Force -Path $binDir | Out-Null

$csc = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\Roslyn\csc.exe"
$netCoreDir = "C:\Program Files\dotnet\shared\Microsoft.NETCore.App\9.0.13"
$wpfDir     = "C:\Program Files\dotnet\shared\Microsoft.WindowsDesktop.App\9.0.13"
$proInstall = "C:\Program Files\Renewed Vision\ProPresenter"

Write-Host "Collecting .NET 9.0.13 & WPF reference assemblies..." -ForegroundColor Cyan

$refDlls = @{}

foreach ($dll in Get-ChildItem -Path $netCoreDir -Filter "*.dll") {
    if ($dll.Name -notlike "*Native*" -and $dll.Name -notlike "mscordac*" -and $dll.Name -notlike "mscordbi*" -and $dll.Name -notlike "coreclr*" -and $dll.Name -notlike "hostpolicy*") {
        try {
            [void][System.Reflection.AssemblyName]::GetAssemblyName($dll.FullName)
            $refDlls[$dll.Name] = $dll.FullName
        } catch {}
    }
}

foreach ($dll in Get-ChildItem -Path $wpfDir -Filter "*.dll") {
    if ($dll.Name -notlike "*Native*" -and $dll.Name -notlike "PenImc*" -and $dll.Name -notlike "PresentationNative*" -and $dll.Name -notlike "vcruntime*" -and $dll.Name -notlike "wpfgfx*" -and $dll.Name -notlike "D3DCompiler*") {
        try {
            [void][System.Reflection.AssemblyName]::GetAssemblyName($dll.FullName)
            $refDlls[$dll.Name] = $dll.FullName
        } catch {}
    }
}

# Copy ProPresenter Protobuf serialization assemblies to bin if not present
$interopDst = Join-Path $binDir "Pro.SerializationInterop.dll"
$protoDst   = Join-Path $binDir "Google.Protobuf.dll"
if (-not (Test-Path $interopDst)) {
    Copy-Item (Join-Path $proInstall "Pro.SerializationInterop.dll") $interopDst -Force
}
if (-not (Test-Path $protoDst)) {
    Copy-Item (Join-Path $proInstall "Google.Protobuf.dll") $protoDst -Force
}

$refDlls["Pro.SerializationInterop.dll"] = (Join-Path $binDir "Pro.SerializationInterop.dll")
$refDlls["Google.Protobuf.dll"]          = (Join-Path $binDir "Google.Protobuf.dll")

$csFiles = Get-ChildItem -Path $srcDir -Filter "*.cs" -Recurse | Select-Object -ExpandProperty FullName
$outDll  = Join-Path $binDir "ProPresenterClone.dll"
$icoPath = Join-Path $repoRoot "assets\ProPresenter.ico"

$rspPath = Join-Path $binDir "build.rsp"
$rspLines = @(
    "/nostdlib+",
    "/target:winexe",
    "/out:`"$outDll`"",
    "/langversion:latest",
    "/nullable:enable",
    "/optimize+",
    "/deterministic",
    "/win32icon:`"$icoPath`""
)

foreach ($refPath in $refDlls.Values) {
    $rspLines += "/r:`"$refPath`""
}

foreach ($cs in $csFiles) {
    $rspLines += "`"$cs`""
}

Set-Content -Path $rspPath -Value $rspLines -Encoding UTF8

Write-Host "Compiling ProPresenterClone.dll with Roslyn csc.exe..." -ForegroundColor Cyan
& $csc "@$rspPath"
if ($LASTEXITCODE -ne 0) {
    throw "Compilation failed with exit code $LASTEXITCODE"
}

# Create .runtimeconfig.json for .NET 9.0 WindowsDesktop
$runtimeConfig = @"
{
  "runtimeOptions": {
    "tfm": "net9.0-windows",
    "rollForward": "LatestMinor",
    "frameworks": [
      {
        "name": "Microsoft.NETCore.App",
        "version": "9.0.0"
      },
      {
        "name": "Microsoft.WindowsDesktop.App",
        "version": "9.0.0"
      }
    ]
  }
}
"@
Set-Content -Path (Join-Path $binDir "ProPresenterClone.runtimeconfig.json") -Value $runtimeConfig -Encoding UTF8

# Generate native Windows GUI .NET 9 apphost ProPresenterClone.exe by patching ProPresenter.exe apphost slot
$srcExe = Join-Path $proInstall "ProPresenter.exe"
$dstExe = Join-Path $binDir "ProPresenterClone.exe"
$bytes  = [System.IO.File]::ReadAllBytes($srcExe)

$searchBytes = [System.Text.Encoding]::UTF8.GetBytes("ProPresenter.dll" + [char]0)
$replaceBytes = [System.Text.Encoding]::UTF8.GetBytes("ProPresenterClone.dll" + [char]0)

$foundOffset = -1
for ($i = 0; $i -lt ($bytes.Length - $searchBytes.Length); $i++) {
    $match = $true
    for ($j = 0; $j -lt $searchBytes.Length; $j++) {
        if ($bytes[$i + $j] -ne $searchBytes[$j]) {
            $match = $false
            break
        }
    }
    if ($match) {
        $foundOffset = $i
        break
    }
}

if ($foundOffset -lt 0) {
    throw "Could not locate apphost DLL slot in ProPresenter.exe"
}

for ($j = 0; $j -lt $replaceBytes.Length; $j++) {
    $bytes[$foundOffset + $j] = $replaceBytes[$j]
}
[System.IO.File]::WriteAllBytes($dstExe, $bytes)

# Also create a root shortcut launcher script
$launchBat = @"
@echo off
start "" "%~dp0bin\ProPresenterClone.exe" %*
"@
Set-Content -Path (Join-Path $repoRoot "Run-ProPresenterClone.bat") -Value $launchBat -Encoding ASCII

Write-Host "Build succeeded! Output: $dstExe" -ForegroundColor Green
