using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            List<Osoba> osobe = new List<Osoba>
            {
                new Osoba { Ime = "Ivan", Prezime = "Horvat", Godine = 30 },
                new Osoba { Ime = "Ana", Prezime = "Kovačić", Godine = 25 },
                new Osoba { Ime = "Marko", Prezime = "Novak", Godine = 35 },
                new Osoba { Ime = "Lucija", Prezime = "Jurić", Godine = 20 }
            };

            Console.WriteLine("Odaberite kriterij za pretragu:");
            Console.WriteLine("1 - Ime");
            Console.WriteLine("2 - Prezime");
            Console.WriteLine("3 - Godine");

            string izbor = Console.ReadLine();

            Console.WriteLine("Unesite vrijednost za pretragu:");
            string vrijednost = Console.ReadLine();

            IEnumerable<Osoba> rezultat = Enumerable.Empty<Osoba>();

            switch (izbor)
            {
                case "1":
                    rezultat = osobe.Where(o => o.Ime.Equals(vrijednost, StringComparison.OrdinalIgnoreCase));
                    break;
                case "2":
                    rezultat = osobe.Where(o => o.Prezime.Equals(vrijednost, StringComparison.OrdinalIgnoreCase));
                    break;
                case "3":
                    if (int.TryParse(vrijednost, out int godine))
                    {
                        rezultat = osobe.Where(o => o.Godine == godine);
                    }
                    else
                    {
                        Console.WriteLine("Molimo unesite ispravan broj za godine.");
                    }
                    break;
                default:
                    Console.WriteLine("Nevažeći izbor.");
                    break;
            }

          
            if (rezultat.Any())
            {
                Console.WriteLine("Rezultati pretrage:");
                foreach (var osoba in rezultat)
                {
                    Console.WriteLine($"{osoba.Ime} {osoba.Prezime}, {osoba.Godine} godina");
                }
            }
            else
            {
                Console.WriteLine("Nema rezultata za zadanu pretragu.");
            }
        }
    }
}
