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

            //6.
            Console.WriteLine($"6. feladat: ");
            nobelDíjak.Where(x => x.Vezetéknév.Contains("Curie")).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Évszám}: {x.TeljesNév}({x.Típus})"));

            //7.
            Console.WriteLine($"7. feladat:");
            nobelDíjak.GroupBy(x => x.Típus)
                .Select(gr => new { Típus = gr.Key, db = gr.Count() }).ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Típus,-25}{x.db} db"));

            //8.
            Console.WriteLine($"8. feladat: orvosi.txt");
            string filename = "orvosi.txt";
            List<string> orvosi = new List<string>();
            nobelDíjak.Where(x => x.Típus == NobelDíj.NobelDíjTípus.orvosi)
                .OrderBy(x => x.Évszám)
                .Select(x => x.Évszám + ":" + x.TeljesNév).ToList()
                .ForEach(x => orvosi.Add(x));
            File.WriteAllLines(filename, orvosi);

            Console.ReadKey();
        }
    }
}
