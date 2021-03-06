﻿using System.Windows.Media;
using System.ComponentModel;

namespace KoloryWPF4.ModelWidoku
{
    using Model;
    using System.Windows.Input;

    public class EdycjaKoloru : ObservedObject
    {
        private readonly Kolor kolor = Ustawienia.Czytaj();

        #region definicja własności byte RGB
        public byte R
        {
            get
            {
                return kolor.R;
            }
            set
            {
                kolor.R = value;
                OnPropertyChanged("R", "RectangleColor");
            }
        }
        public byte G
        {
            get
            {
                return kolor.G;
            }
            set
            {
                kolor.G = value;
                OnPropertyChanged("G", "RectangleColor");
            }
        }
        public byte B
        {
            get
            {
                return kolor.B;
            }
            set
            {
                kolor.B = value;
                OnPropertyChanged("B", "RectangleColor");
            }
        }
        #endregion

        public Color RectangleColor
        {
            get
            {
                return kolor.ToColor();
            }
        }

        //public void Zapisz()
        //{
        //    Ustawienia.Zapisz(kolor);
        //}

        private ICommand zapiszCommand;
        public ICommand Zapisz
        {
            get
            {
                if (zapiszCommand == null)
                {
                    zapiszCommand = new RelayCommand(argument => {
                        Ustawienia.Zapisz(kolor);
                    });
                }
                    
                return zapiszCommand;
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(params string[] sProperties)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        foreach (string sProperty in sProperties)
        //            PropertyChanged(this, new PropertyChangedEventArgs(sProperty));
        //    }
        //}


        //    //implementacja IC
        //private ICommand resetujCommand;
        //public ICommand Resetuj
        //{
        //    get
        //    {
        //        if (resetujCommand == null) resetujCommand = new ResetujCommand(this);
        //        return resetujCommand;
        //    }
        //}

        //relay command:
        private ICommand resetujCommand;
        public ICommand Resetuj
        {
            get
            {
                if (resetujCommand == null)
                {
                    resetujCommand = new RelayCommand(
                    argument =>
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    },
                    argument => (R != 0) || (G != 0) || (B != 0)
                    );
                }
                return resetujCommand;
            }
        }

        
        private ICommand losujCommand;
        public ICommand Losuj
        {
            get
            {
                if (losujCommand == null) losujCommand = new LosujCommand(this);
                return losujCommand;
            }
        }

      
        //private ICommand zakonczCommand;
        //public ICommand Zakoncz
        //{
        //    get
        //    {
        //        if (zakonczCommand == null) zakonczCommand = new ZakonczCommand(this);
        //        return zakonczCommand;
        //    }
        //}

        public ICommand ZamknijOkno
        {
            get
            {
                return new RelayCommand(argument => { App.Current.MainWindow.Close(); });

                //przesyłając referencję okna przez parametr:
                //return new RelayCommand(argument => { 
                //    (argument as System.Windows.Window).Close(); 
                //    });
            }
        }

        public ICommand KopiujKolor
        {
            get
            {
                return new RelayCommand(argument => { 
                    CopyColorToClipboard.Kopiuj(RectangleColor); 
                });
            }
        }



    }



    static class Rozszerzenia
    {
        public static Color ToColor(this Kolor kolor)
        {
            return new Color()
            {
                A = kolor.A,
                R = kolor.R,
                G = kolor.G,
                B = kolor.B
            };
        }
    }


    public class EdycjaKoloru2 : INotifyPropertyChanged
    {
        public EdycjaKoloru2()
        {
            Kolor kolor = Ustawienia.Czytaj();
            R = kolor.R;
            G = kolor.G;
            B = kolor.B;
        }
        private byte r, g, b;
        public byte R
        {
            get
            {
                return r;
            }
            set
            {
                r = value;
                OnPropertyChanged("R", "Color");
            }
        }
        public byte G
        {
            get
            {
                return g;
            }
            set
            {
                g = value;
                OnPropertyChanged("G", "Color");
            }
        }
        public byte B
        {
            get
            {
                return b;
            }
            set
            {
                b = value;
                OnPropertyChanged("B", "Color");
            }
        }
        public Color Color
        {
            get
            {                
            return Color.FromRgb(R, G, B);
            }
        }
        public void Zapisz()
        {
            Kolor kolor = new Kolor(R, G, B);
            Ustawienia.Zapisz(kolor);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(params string[] sProperties)
        {
            if (PropertyChanged != null)
            {
                foreach (string sProperty in sProperties)
                    PropertyChanged(this, new PropertyChangedEventArgs(sProperty));
            }
        }
    }

    //public class EdycjaKoloru3
    //{
    //    private readonly Kolor kolor = Ustawienia.Czytaj();
    //    public Kolor Kolor
    //    {
    //        get
    //        {
    //            return kolor;
    //        }
    //    }
    //    public Color Color
    //    {
    //        get
    //        {
    //            return Kolor.ToColor();
    //        }
    //    }
    //    public void Zapisz()
    //    {
    //        Ustawienia.Zapisz(Kolor);
    //    }
    //}
}

