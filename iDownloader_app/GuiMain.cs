using Microsoft.Maui.Controls;

namespace IDownloader
{
    /// <summary>
    /// Main application GUI structure containing navigation tabs for iOS sideloading utility.
    /// </summary>
    public class GuiMain : TabbedPage
    {
        // Declare the Entry control at the class level so we can access it from anywhere in this class
        private Entry _urlEntry;
        private ProgressBar _progressBar;

        public GuiMain()
        {
            Title = "IDownloader";

            // 1. Downloads Tab (Core UI for managing tasks)
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

            // Hook up the button click event
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
                        _urlEntry,         // Added text input to the layout
                        downloadButton,    // Added button with click event
                        _progressBar       // Added progress bar
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
        /// Event handler triggered when the user clicks the "Start Download" button.
        /// </summary>
        private void OnDownloadButtonClicked(object sender, EventArgs e)
        {
            // Get the text from the URL input field
            string targetUrl = _urlEntry.Text;

            // Simple validation check
            if (string.IsNullOrWhiteSpace(targetUrl))
            {
                // You could show an alert popup here later
                return;
            }

            // At this point, `targetUrl` contains the link entered by the user!
            // TODO: Pass `targetUrl` to your background downloader engine.
        }
    }
}
            Children.Add(aboutPage);
        }
    }
}
