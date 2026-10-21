using Microsoft.Maui.Controls;
using System;

namespace IDownloader
{
    /// <summary>
    /// Main application GUI structure containing navigation tabs for iOS sideloading utility.
    /// </summary>
    public class GuiMain : TabbedPage
    {
        // Shared static variable so DownloaderEngine can read it directly
        public static string SharedUrl { get; set; } = string.Empty;

        private Entry _urlEntry;
        private ProgressBar _progressBar;
        
        // Instance of the downloader engine
        private readonly DownloaderEngine _downloaderEngine = new DownloaderEngine();

        public GuiMain()
        {
            Title = "IDownloader";

            // 1. Downloads Tab
            _urlEntry = new Entry 
            { 
                Placeholder = "Paste download URL (e.g. .ipa file)...",
                BackgroundColor = Color.FromArgb("#1C1C1E"),
                TextColor = Colors.White
            };

            _progressBar = new ProgressBar 
            { 
                Progress = 0.0, 
                ProgressColor = Color.FromArgb("#34C759") 
            };

            var downloadButton = new Button 
            { 
                Text = "Start Download", 
                BackgroundColor = Color.FromArgb("#007AFF"), 
                TextColor = Colors.White,
                CornerRadius = 10
            };

            // Hook up click event
            downloadButton.Clicked += OnDownloadButtonClicked;

            var downloadsPage = new ContentPage
            {
                Title = "Downloads",
                BackgroundColor = Color.FromArgb("#000000"),
                Content = new VerticalStackLayout
                {
                    Padding = 25,
                    Spacing = 20,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label 
                        { 
                            Text = "IDownloader Engine", 
                            FontSize = 24, 
                            TextColor = Colors.White,
                            HorizontalTextAlignment = TextAlignment.Center 
                        },
                        _urlEntry,
                        downloadButton,
                        _progressBar
                    }
                }
            };

            // 2. Settings Tab
            var settingsPage = new ContentPage
            {
                Title = "Settings",
                BackgroundColor = Color.FromArgb("#000000"),
                Content = new VerticalStackLayout
                {
                    Padding = 25,
                    Spacing = 15,
                    Children =
                    {
                        new Label { Text = "Download Settings", FontSize = 22, TextColor = Colors.White },
                        new Label { Text = "Max Concurrent Downloads (Threads):", TextColor = Color.FromArgb("#8E8E93") },
                        new Entry { Text = "4", Keyboard = Keyboard.Numeric, BackgroundColor = Color.FromArgb("#1C1C1E"), TextColor = Colors.White }
                    }
                }
            };

            // 3. About Tab
            var aboutPage = new ContentPage
            {
                Title = "About",
                BackgroundColor = Color.FromArgb("#000000"),
                Content = new VerticalStackLayout
                {
                    Padding = 25,
                    Spacing = 10,
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label { Text = "IDownloader v1.0", FontSize = 20, TextColor = Colors.White, HorizontalTextAlignment = TextAlignment.Center },
                        new Label { Text = "Fast background downloader built with C# & .NET for iOS sideloading.", TextColor = Color.FromArgb("#8E8E93"), HorizontalTextAlignment = TextAlignment.Center }
                    }
                }
            };

            Children.Add(downloadsPage);
            Children.Add(settingsPage);
            Children.Add(aboutPage);
        }

        /// <summary>
        /// Event triggered when the download button is clicked.
        /// </summary>
        private async void OnDownloadButtonClicked(object sender, EventArgs e)
        {
            // Save the entered URL into the shared static property
            SharedUrl = _urlEntry.Text;

            if (string.IsNullOrWhiteSpace(SharedUrl))
                return;

            // Trigger the download engine
            bool success = await _downloaderEngine.DownloadFileAsync();

            if (success)
            {
                System.Diagnostics.Debug.WriteLine("[GUI] Download task completed successfully.");
            }
        }
    }
}
            Children.Add(aboutPage);
        }
    }
}
