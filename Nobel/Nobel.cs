using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Nobel
{
    class Nobel
    {
        static void Main(string[] args)
        {
            //2.
            List<NobelDíj> nobelDíjak = new List<NobelDíj>();
            foreach (var sor in File.ReadAllLines("nobel.csv").Skip(1))
            {
                nobelDíjak.Add(new NobelDíj(sor));
            }
            //Console.WriteLine($"Sorok száma: {nobelDíjak.Count}");

            //3.
            var ABM = nobelDíjak.FirstOrDefault(x => x.TeljesNév == "Arthur B. McDonald");
            Console.WriteLine($"3. feladat: {ABM.Típus}");

            //4.
            Console.WriteLine($"4. feladat: { nobelDíjak.First(x => x.Évszám == 2017 && x.Típus == NobelDíj.NobelDíjTípus.irodalmi).TeljesNév}");

            //5. feladat: Feltétel: Szervezet, 1990-től, béke
            Console.WriteLine($"5. feladat: ");
            nobelDíjak
                .Where(x => x.Vezetéknév == "" && x.Évszám >= 1990 && x.Típus == NobelDíj.NobelDíjTípus.béke)
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Évszám}: {x.Keresztnév}"));

            Console.ReadKey();
        }
    }
}
