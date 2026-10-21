using Microsoft.Maui.Controls;

namespace IDownloader
{
    /// <summary>
    /// Main application GUI structure containing navigation tabs for iOS sideloading utility.
    /// </summary>
    public class GuiMain : TabbedPage
    {
        public GuiMain()
        {
            Title = "IDownloader";

            // 1. Downloads Tab (Core UI for managing tasks)
            var downloadsPage = new ContentPage
            {
                Title = "Downloads",
                BackgroundColor = Color.FromArgb("#000000"), // True black for iOS OLED screens
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
                        // URL input for downloading .ipa or other payloads
                        new Entry 
                        { 
                            Placeholder = "Paste download URL (e.g. .ipa file)...",
                            BackgroundColor = Color.FromArgb("#1C1C1E"),
                            TextColor = Colors.White
                        },
                        // Trigger download button
                        new Button 
                        { 
                            Text = "Start Download", 
                            BackgroundColor = Color.FromArgb("#007AFF"), // iOS Blue accent
                            TextColor = Colors.White,
                            CornerRadius = 10
                        },
                        // Real-time progress bar for background chunks
                        new ProgressBar 
                        { 
                            Progress = 0.0, 
                            ProgressColor = Color.FromArgb("#34C759") // iOS Green accent
                        }
                    }
                }
            };

            // 2. Settings Tab (Configuration like concurrent chunks/threads)
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
                        new Label 
                        { 
                            Text = "Download Settings", 
                            FontSize = 22, 
                            TextColor = Colors.White 
                        },
                        new Label 
                        { 
                            Text = "Max Concurrent Downloads (Threads):", 
                            TextColor = Color.FromArgb("#8E8E93") 
                        },
                        // Input for chunking thread count
                        new Entry 
                        { 
                            Text = "4", 
                            Keyboard = Keyboard.Numeric,
                            BackgroundColor = Color.FromArgb("#1C1C1E"),
                            TextColor = Colors.White
                        }
                    }
                }
            };

            // 3. About Tab (Project details)
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
                        new Label 
                        { 
                            Text = "IDownloader v1.0", 
                            FontSize = 20, 
                            TextColor = Colors.White,
                            HorizontalTextAlignment = TextAlignment.Center
                        },
                        new Label 
                        { 
                            Text = "Fast background downloader built with C# & .NET for iOS sideloading.", 
                            TextColor = Color.FromArgb("#8E8E93"),
                            HorizontalTextAlignment = TextAlignment.Center
                        }
                    }
                }
            };

            // Register tabs into the main navigation view
            Children.Add(downloadsPage);
            Children.Add(settingsPage);
            Children.Add(aboutPage);
        }
    }
}
