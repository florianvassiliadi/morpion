﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORPION
{
    public class _Grille
    {
        public List<List<String>> Grille = new List<List<string>>();

        public _Grille()
        {
            InitialiserGrille();
        }

        public void AfficherGrille()
        {
            foreach (var ligne in Grille)
            {
                foreach (var cas in ligne)
                {
                    Console.Write(cas);
                }
                Console.WriteLine();
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

        public void PlacerPion(int ligne,int colonne, String pion)
        {
            Grille[ligne][colonne] = pion;
        }

        public bool HorizontalRemporte()
        {
            bool result = false;
            foreach(var ligne in Grille)
            {
                int xCount = 0;
                int oCount = 0;
                foreach(var cas in ligne)
                {
                    if(cas=="X")
                    {
                        xCount++;
                    }
                    if(cas =="O")
                    {
                        oCount++;
                    }
                }
                if(xCount>2 || oCount>2)
                {
                    result = true;
                }
            }
            return result;
        }

        public bool VerticalRemporte()
        {
            List<List<String>> GrilleRenverse = Renverser();
            bool result = false;
            foreach (var ligne in GrilleRenverse)
            {
                int xCount = 0;
                int oCount = 0;
                foreach (var cas in ligne)
                {
                    if (cas == "X")
                    {
                        xCount++;
                    }
                    if (cas == "O")
                    {
                        oCount++;
                    }
                }
                if (xCount > 2 || oCount > 2)
                {
                    result = true;
                }
            }
            return result;
        }

        public List<List<String>> Renverser()
        {
            List<List<String>> GrilleRecup = new List<List<string>>();
            GrilleRecup.Add(InitialiserLigne());
            GrilleRecup.Add(InitialiserLigne());
            GrilleRecup.Add(InitialiserLigne());

            int lIndex=0;
            int cIndex=0;
            foreach (var ligne in Grille)
            {
                cIndex = 0;
                foreach (var cas in ligne)
                {
                    if(cas!="*")
                    {
                        GrilleRecup[cIndex][lIndex] = cas;
                    }
                    cIndex++;
                }
                lIndex++;
            }
            return GrilleRecup;
        }

    }
}
