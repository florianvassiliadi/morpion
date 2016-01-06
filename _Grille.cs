using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORPION
{
    public class _Grille
    {
        public List<List<String>> Grille = new List<List<string>>();
        public void AfficherGrille()
        {
            foreach (var ligne in Grille)
            {
                foreach (var cas in ligne)
                {
                    Console.Write(cas);
                }
            }
        }

        public void InitialiserGrille()
        {
            Grille.Add(InitialiserLigne());
            Grille.Add(InitialiserLigne());
            Grille.Add(InitialiserLigne());
        }

        List<String> InitialiserLigne()
        {
            List<String> liste = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                liste.Add("*");
            }
            return liste;
        }
    }
}
