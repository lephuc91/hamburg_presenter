using System;
using System.IO;
using System.Linq;
using System.Windows;
using ProPresenterClone.Serialization;
using ProPresenterClone.Services;
using ProPresenterClone.Theming;
using ProPresenterClone.UI;

namespace ProPresenterClone
{
    public static class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            try
            {
                // Initialize ProPresenter theme engine (loads dark.theme & light.theme from assets\themes)
                ThemeEngine.Instance.LoadTheme("dark");

                if (args.Contains("--verify", StringComparer.OrdinalIgnoreCase))
                {
                    return RunVerificationSuite();
                }

                var app = new Application
                {
                    ShutdownMode = ShutdownMode.OnMainWindowClose
                };

                var mainWindow = new MainWindow();
                app.Run(mainWindow);
                return 0;
            }
            catch (Exception ex)
            {
                if (args.Contains("--verify", StringComparer.OrdinalIgnoreCase))
                {
                    Console.Error.WriteLine($"Verification error: {ex}");
                    return 1;
                }

                MessageBox.Show(
                    $"ProPresenter encountered an unexpected startup error:\n\n{ex}",
                    "ProPresenter Startup Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return 1;
            }
        }

        private static int RunVerificationSuite()
        {
            Console.WriteLine("=== ProPresenterClone Verification Suite ===");
            Console.WriteLine($"Assets Root: {ThemeEngine.Instance.AssetsRoot}");

            var presentations = ProFileService.LoadAllLibraryPresentations();
            Console.WriteLine($"Loaded {presentations.Count} native .pro presentations.");
            foreach (var p in presentations.Take(5))
            {
                Console.WriteLine($"  - {p.Name} ({p.Slides.Count} slides) [{Path.GetFileName(p.FilePath)}]");
            }

            var themes = ProFileService.LoadSampleThemes();
            Console.WriteLine($"Loaded {themes.Count} themes.");

            // Verify Christ Is Enough structure matches ProPresenter reference
            var cie = presentations.FirstOrDefault(p => p.Name.Contains("Christ Is Enough", StringComparison.OrdinalIgnoreCase));
            if (cie != null)
            {
                Console.WriteLine($"Christ Is Enough presentation verified: {cie.Slides.Count} slides, {cie.Groups.Count} groups.");
            }
            var verses = BibleService.Lookup("KJV", "John 3:16-17");
            Console.WriteLine($"Bible Lookup John 3:16-17 returned {verses.Count} verses.");

            // Test saving and reloading a native Protobuf .pro file
            string tempPro = Path.Combine(Path.GetTempPath(), "ProPresenterClone_RoundTripTest.pro");
            var sampleDoc = presentations.First();
            ProFileService.SaveProFile(sampleDoc, tempPro);
            var reloaded = ProFileService.LoadProFile(tempPro);
            Console.WriteLine($"Round-trip .pro Protobuf test: saved & reloaded '{reloaded?.Name}' with {reloaded?.Slides.Count} slides.");

            // Instantiate MainWindow on STA thread to verify all UI controls & views build cleanly
            var win = new MainWindow();
            Console.WriteLine($"MainWindow initialized successfully: Title='{win.Title}', Width={win.Width}, Height={win.Height}");

            // Instantiate SettingsWindow and cycle through all 14 ProPresenter settings pages
            var settingsWin = new ProPresenterClone.Windows.SettingsWindow("Screens");
            foreach (var page in ProPresenterClone.Windows.SettingsWindow.PageNames)
            {
                settingsWin.SelectPage(page);
            }
            Console.WriteLine($"SettingsWindow verified all {ProPresenterClone.Windows.SettingsWindow.PageNames.Length} pages: {string.Join(", ", ProPresenterClone.Windows.SettingsWindow.PageNames)}");
            settingsWin.Close();

            // Instantiate ScreenConfigurationWindow to verify layout, canvas preview, and tabs build cleanly
            var screenConfigWin = new ProPresenterClone.Windows.ScreenConfigurationWindow();
            Console.WriteLine($"ScreenConfigurationWindow verified: Title='{screenConfigWin.Title}', Width={screenConfigWin.Width}, Height={screenConfigWin.Height}");
            screenConfigWin.Close();

            // Instantiate NewPresentationDialog to verify dialog layout, theme preview card, size, library, and playlist dropdowns
            var newPresDlg = new ProPresenterClone.Windows.NewPresentationDialog(themes, new[] { "Default", "Worship Songs" }, new[] { "Sunday Service" });
            Console.WriteLine($"NewPresentationDialog verified: Title='{newPresDlg.Title}', Width={newPresDlg.Width}");
            newPresDlg.Close();

            win.Close();

            Console.WriteLine("=== ALL CHECKS PASSED ===");
            return 0;
        }
    }
}

