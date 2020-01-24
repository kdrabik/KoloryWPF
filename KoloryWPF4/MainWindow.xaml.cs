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

namespace KoloryWPF4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using Model;
    using ModelWidoku;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        //private void Window_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //Color TestColor = Color.FromRgb(255,255,255);
        //    //MessageBox.Show($"{TestColor.R}");

        //    if (e.Key == Key.Escape)
        //    {
        //        Close();
        //    }
        //    else
        //    {
        //        MessageBoxResult result = MessageBox.Show("Naciśnij escape aby zamknąć aplikacje", "Test Box", MessageBoxButton.OKCancel, MessageBoxImage.Information);
        //        switch (result)
        //        {
        //            case MessageBoxResult.OK:
        //                MessageBox.Show("you pressed ok", "another test", MessageBoxButton.OK);
        //                return;
        //            case MessageBoxResult.Cancel:
        //                MessageBox.Show("you pressed cancel", "another test", MessageBoxButton.OK);
        //                return;
        //            default:
        //                MessageBox.Show("WTF", "another test", MessageBoxButton.OK);
        //                return;
        //        }
        //    }
        //}


        private void Window_Closed(object sender, EventArgs e)
        {
            EdycjaKoloru edycjaKoloru = this.Resources["edycjaKoloru"] as EdycjaKoloru;
            //EdycjaKoloru2 edycjaKoloru = this.Resources["edycjaKoloru"] as EdycjaKoloru2;
            edycjaKoloru.Zapisz();
        }

    }

}
