using System.Windows.Media;
using System.ComponentModel;

namespace KoloryWPF3.ModelWidoku
{
    using Model;
    

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
                OnPropertyChanged("R", "Color");
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
                OnPropertyChanged("G", "Color");
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
                OnPropertyChanged("B", "Color");
            }
        }
        #endregion

        public Color Color
        {
            get
            {
                return kolor.ToColor();
            }
        }

        public void Zapisz()
        {
            Ustawienia.Zapisz(kolor);
        }


        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(params string[] nazwyWłasności)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        foreach (string nazwaWłasności in nazwyWłasności)
        //            PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
        //    }
        //}

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
        private void OnPropertyChanged(params string[] nazwyWłasności)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWłasności in nazwyWłasności)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
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

