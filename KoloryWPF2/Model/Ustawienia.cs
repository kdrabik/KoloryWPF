using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media; //Color


namespace KoloryWPF2.Model
{
    static class Ustawienia
    {
        public static Kolor Czytaj()
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            return new Kolor(ustawienia.R, ustawienia.G, ustawienia.B); //zwraca obiekt klasy Kolor
            //Color kolor = new Color()
            //{
            //    A = 255,
            //    R = ustawienia.R,
            //    G = ustawienia.G,
            //    B = ustawienia.B
            //};
            //return kolor;
        }

        public static void Zapisz(Kolor kolor)
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            ustawienia.R = kolor.R;
            ustawienia.G = kolor.G;
            ustawienia.B = kolor.B;
            ustawienia.Save();
        }
    }
}
