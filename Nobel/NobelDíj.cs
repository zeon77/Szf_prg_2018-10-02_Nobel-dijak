using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nobel
{
    class NobelDíj
    {
        public enum NobelDíjTípus
        {
            fizikai,
            kémiai,
            orvosi,
            irodalmi,
            béke,
            közgazdaságtani
        }

        public int Évszám { get; set; }
        public NobelDíjTípus Típus { get; set; }
        public string Keresztnév { get; set; }
        public string Vezetéknév { get; set; }

        public NobelDíj(string sor)
        {
            string[] s = sor.Split(';');
            Évszám = int.Parse(s[0]);
            Enum.TryParse(s[1], out NobelDíjTípus nt);
            Típus = nt;
            Keresztnév = s[2];
            Vezetéknév = s[3];
        }
    }
}
