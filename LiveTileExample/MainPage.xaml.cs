using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LiveTileExample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnTextLiveTile_Click(object sender, RoutedEventArgs e)
        {
            LiveTileManager.SetLiveTile("Hi!", "20 seconds", 20);

            txtStatus.Text = "Press the Windows-Key to minimize the app and see the live tile.";
        }

        private void btnImageLiveTile_Click(object sender, RoutedEventArgs e)
        {
            LiveTileManager.SetLiveTile("neptune.png", 20);

            txtStatus.Text = "Press the Windows-Key to minimize the app and see the live tile.";
        }

        private void btnAnimatedLiveTile_Click(object sender, RoutedEventArgs e)
        {
            LiveTileManager.SetLiveTileAnimated("neptune.png", "Hi, I'm an animated tile notification!", 30);

            txtStatus.Text = "Press the Windows-Key to minimize the app and see the live tile.";
        }
    }
}
