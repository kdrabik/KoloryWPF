

namespace KoloryWPF3.Model
{
    public class Kolor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }


        public Kolor(byte _r, byte _g, byte _b)
        {
            this.R = _r; //this konieczne?
            this.G = _g;
            this.B = _b;
            this.A = 255;
        }
        public Kolor(byte _r, byte _g, byte _b, byte _a)
        {
            this.R = _r; //this konieczne?
            this.G = _g;
            this.B = _b;
            this.A = _a;
        }

    }
}
