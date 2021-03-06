﻿using System;
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
using Microsoft.Xaml.Behaviors;

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
    public class ZamknięcieOknaPoNaciśnięciuKlawisza : Behavior<Window>
    {
        public Key Klawisz { get; set; }
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null) window.PreviewKeyDown += Window_PreviewKeyDown;
        }
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Key == Klawisz) window.Close();
        }

    }

    public class PrzyciskZamykającyOkno : Behavior<Window>
    {
        public static readonly DependencyProperty PrzyciskProperty =
        DependencyProperty.Register(
                                    "Przycisk",     //nazwa własności
                                    typeof(Button), //typ własności
                                    typeof(PrzyciskZamykającyOkno), //typ właściciela
                                    new PropertyMetadata(null, PrzyciskZmieniony)
                                    //obiekt typu PropertyMetadata.
                                    //argument 1: domyślna wartość własności
                                    //argument 2: metoda która będzie wykonywana, gdy wartość własności zostanie zmieniona.
                                    );
        public Button Przycisk
        {
            get { return (Button)GetValue(PrzyciskProperty); }
            set { SetValue(PrzyciskProperty, value); }
        }

        public static readonly DependencyProperty PolecenieProperty =
                                    DependencyProperty.Register(
                                                                "Polecenie",
                                                                typeof(ICommand),
                                                                typeof(PrzyciskZamykającyOkno)
                                                                );
        public ICommand Polecenie
        {
            get { return (ICommand)GetValue(PolecenieProperty); }
            set { SetValue(PolecenieProperty, value); }
        }
        public static readonly DependencyProperty ParametrPoleceniaProperty =
                                    DependencyProperty.Register(
                                                                "ParametrPolecenia",
                                                                typeof(object),
                                                                typeof(PrzyciskZamykającyOkno)
                                                                );
        public object ParametrPolecenia
        {
            get { return GetValue(ParametrPoleceniaProperty); }
            set { SetValue(ParametrPoleceniaProperty, value); }
        }
        private static void PrzyciskZmieniony(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            Window window = (d as PrzyciskZamykającyOkno).AssociatedObject;
            RoutedEventHandler button_Click =
            (object sender, RoutedEventArgs _e) =>
            {
                ICommand polecenie = (d as PrzyciskZamykającyOkno).Polecenie;
                object parametrPolecenia =
                (d as PrzyciskZamykającyOkno).ParametrPolecenia;
                if (polecenie != null) polecenie.Execute(parametrPolecenia);
                window.Close();
            };
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }

    public static class KlawiszWyłączBehavior
    {
        public static Key GetKlawisz(DependencyObject d)
        {
            return (Key)d.GetValue(KlawiszProperty);
        }
        public static void SetKlawisz(DependencyObject d, Key value)
        {
            d.SetValue(KlawiszProperty, value);
        }
        public static readonly DependencyProperty KlawiszProperty =
        DependencyProperty.RegisterAttached(
        "Klawisz",
        typeof(Key),
        typeof(KlawiszWyłączBehavior),
        new PropertyMetadata(Key.None, KlawiszZmieniony));
        private static void KlawiszZmieniony(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            Key klawisz = (Key)e.NewValue;
            if (d is Window)
            {
                (d as Window).PreviewKeyDown +=
                (object sender, KeyEventArgs _e) =>
                {
                    if (_e.Key == klawisz)
                        (sender as Window).Close();
                };
            }
            else
            {
                (d as UIElement).PreviewKeyDown +=
                (object sender, KeyEventArgs _e) =>
                {
                    if (_e.Key == klawisz)
                        (sender as UIElement).IsEnabled = false;
                };
            }
        }
    }
}
