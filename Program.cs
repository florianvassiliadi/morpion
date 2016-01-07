using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORPION
{
    class Program
    {
        public static _Grille Grille;
        static void Main(string[] args)
        {
            Grille = new _Grille();
            Grille.AfficherGrille();
            while (!Grille.EstJeuTermine())
            {
                Console.WriteLine();
                String point = Console.ReadLine();
                string[] recup = point.Split(':');
                Grille.PlacerPion(Int32.Parse(recup[0]),Int32.Parse(recup[1]),"X");
                Grille.AfficherGrille();
            }
            Console.WriteLine("JEU TERMINE");
        }
    }
}
