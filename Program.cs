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
            Console.WriteLine();
            Grille.PlacerPion(2,0,"X");
            Grille.PlacerPion(1, 0, "X");
            Grille.PlacerPion(0, 0, "X");
            Grille.AfficherGrille();
            Console.WriteLine();
            //List<List<String>> grille2 = Grille.Renverser();
            //Grille.Grille = grille2;
            Grille.AfficherGrille();
            Console.WriteLine(Grille.VerticalRemporte());
        }
    }
}
