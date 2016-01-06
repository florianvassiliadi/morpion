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
            Grille.PlacerPion(0,2,"X");
            Grille.PlacerPion(0, 1, "X");
            Grille.PlacerPion(0, 0, "X");
            Grille.AfficherGrille();
            Console.WriteLine(Grille.HorizontalRemporte());
        }
    }
}
