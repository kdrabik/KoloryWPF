using System.Windows.Media;


namespace KoloryWPF2.ModelWidoku
{
    using Model;

    public class EdycjaKoloru
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
    }
    static class Rozszerzenia
    {
        public static Color ToColor(this Kolor kolor)
        {
            return new Color()
            {
                A = 255,
                R = kolor.R,
                G = kolor.G,
                B = kolor.B
            };
        }
    }
    //public class EdycjaKoloru2
    //{
    //    public byte R { get; set; }
    //    public byte G { get; set; }
    //    public byte B { get; set; }


    //    public EdycjaKoloru2()
    //    {
    //        Kolor kolor = Ustawienia.Czytaj();
    //        R = kolor.R;
    //        G = kolor.G;
    //        B = kolor.B;
    //    }

    //    public Color Color
    //    {
    //        get
    //        {
    //            return Color.FromRgb(R, G, B);
    //        }
    //    }

    //    public void Zapisz()
    //    {
    //        Kolor kolor = new Kolor(R, G, B);
    //        Ustawienia.Zapisz(kolor);
    //    }
    //}

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

