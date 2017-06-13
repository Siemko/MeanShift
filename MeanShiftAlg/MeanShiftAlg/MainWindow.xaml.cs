using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MeanShiftAlg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BitmapImage imageSource;
        public MainWindow()
        {
            InitializeComponent();
            FullImageRadio.Checked += FullImageRadio_Checked;
            LocalWindowRadio.Checked += LocalWindowRadio_Checked;
        }

        private void LocalWindowRadio_Checked(object sender, RoutedEventArgs e)
        {
            LocalWindowParameters.Visibility = Visibility.Visible;
        }

        private void FullImageRadio_Checked(object sender, RoutedEventArgs e)
        {
            LocalWindowParameters.Visibility = Visibility.Collapsed;
        }

        private void LoadImageButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                BaseImage.Source = imageSource;
            }
        }

        private void SegmentationButton_Click(object sender, RoutedEventArgs e)
        {
            bool isLocalWindow = false;

            if (imageSource != null && !string.IsNullOrWhiteSpace(ParameterHBox.Text))
            {
                if (LocalWindowRadio.IsChecked == true)
                {
                    if (!string.IsNullOrWhiteSpace(WindowHeightBox.Text)
                        && !string.IsNullOrWhiteSpace(WindowWidthBox.Text))
                    {
                        var windowHeight = Convert.ToDouble(WindowHeightBox.Text);
                        var windowWidth = Convert.ToDouble(WindowWidthBox.Text);
                        isLocalWindow = true;
                    }
                    else
                        isLocalWindow = false;
                }
                else
                    isLocalWindow = false;

                var image = imageSource;
                var paramH = Convert.ToDouble(ParameterHBox.Text);
            }
        }
    }
}
