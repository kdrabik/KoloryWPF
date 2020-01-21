

namespace KoloryWPF2.Model
{
    public class Kolor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Kolor(byte _r, byte _g, byte _b)
        {
            this.R = _r; //this konieczne?
            this.G = _g;
            this.B = _b;
        }

    }
}
