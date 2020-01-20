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

namespace KoloryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rectangle.Fill = new SolidColorBrush(Colors.Black);

        }

        private void sliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color kolor = Color.FromRgb(
                (byte)sliderR.Value,
                (byte)sliderG.Value,
                (byte)sliderB.Value
                );
            // rectangle.Fill = new SolidColorBrush(kolor);
            (rectangle.Fill as SolidColorBrush).Color = kolor;
        }

        private void sliderG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void sliderB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }
            else
            {
                MessageBoxResult result= MessageBox.Show("Naciśnij escape aby zamknąć aplikacje","Test Box",MessageBoxButton.OKCancel,MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.OK:
                        MessageBox.Show("you pressed yes", "another test", MessageBoxButton.OK);
                        return;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("you pressed cancel", "another test", MessageBoxButton.OK);
                        return;
                    default:
                        MessageBox.Show("WTF", "another test", MessageBoxButton.OK);
                        return;
                }
            }
        }
        private Color KolorProstokąta
        {
            get
            {
                return (rectangle.Fill as SolidColorBrush).Color;
            }
            set
            {
                (rectangle.Fill as SolidColorBrush).Color = value;
            }
        }
    }
}
