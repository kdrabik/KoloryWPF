using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace KoloryWPF4.Model
{
    static class CopyColorToClipboard
    {
        
        public static void Kopiuj(Color kolor)
        {
            //MessageBox.Show(kolor.ToString());
            Clipboard.SetText(kolor.ToString());
        }
    }
}
