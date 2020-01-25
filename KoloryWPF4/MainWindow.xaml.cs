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

    //fix do braku bibliotek System.Windows.Interactivity.dll i Microsoft.Expression.Interaction.dll z przykładu:
    //nuget package to install: PM> Install-Package MicrosoftExpressionInteractions -Version 3.0.40218
    //nuget package to install: PM> Install-Package System.Windows.Interactivity.WPF -Version 2.0.20525
    //https://stackoverflow.com/questions/8360209/how-to-add-system-windows-interactivity-to-project

    //biblioteka która zastępuje powyższe    
    //https://developercommunity.visualstudio.com/content/problem/535255/how-to-install-blend-sdk-in-visual-studio-2019.html
    //Install-Package Microsoft.Xaml.Behaviors.Wpf -Version 1.1.19 //https://developercommunity.visualstudio.com/content/problem/535255/how-to-install-blend-sdk-in-visual-studio-2019.html
    //xml ref: "http://schemas.microsoft.com/xaml/behaviors“
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


        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    ////WindowResources
        //    //EdycjaKoloru edycjaKoloru = this.Resources["edycjaKoloru"] as EdycjaKoloru;
        //    ////EdycjaKoloru2 edycjaKoloru = this.Resources["edycjaKoloru"] as EdycjaKoloru2;
        //    //edycjaKoloru.Zapisz();

        //    EdycjaKoloru edycjaKoloru = this.DataContext as EdycjaKoloru;
        //    edycjaKoloru.Zapisz();
        //}

    }

}
