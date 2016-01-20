using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MORPION
{
    class _IA
    {
        public List<List<String>> jouer(List<List<String>> grille, int profondeur)
        {
            int max = -10000;
            int tmp, maxi=0, maxj=0;
            int i, j;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (grille[i][j] == "*")
                    {
                        grille[i][j] = "X";
                        tmp = Min(grille, profondeur - 1);

                        if (tmp > max)
                        {
                            max = tmp;
                            maxi = i;
                            maxj = j;
                        }
                        grille[i][j] = "*";
                    }
                }
            }

            grille[maxi][maxj] = "X";
            return grille;
        }
        public int Min(List<List<String>> grille, int profondeur)
        {
            if (profondeur == 0 || gagnant(grille) != 0)
            {
                return eval(grille);
            }

            int min = 10000;
            int i, j, tmp;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (grille[i][j] == "*")
                    {
                        grille[i][j] = "X";
                        tmp = Max(grille, profondeur - 1);

                        if (tmp < min)
                        {
                            min = tmp;
                        }
                        grille[i][j] = "*";
                    }
                }
            }

            return min;
        }
        public Series nb_series(List<List<String>> jeu,int n)
        {
            int compteur1, compteur2, i, j;

            int series_j1 = 0;
            int series_j2 = 0;

            compteur1 = 0;
            compteur2 = 0;

            //Diagonale descendante
            for (i = 0; i < 3; i++)
            {
                if (jeu[i][i] == "X")
                {
                    compteur1++;
                    compteur2 = 0;

                    if (compteur1 == n)
                    {
                        series_j1++;
                    }
                }
                else if (jeu[i][i] == "O")
                {
                    compteur2++;
                    compteur1 = 0;

                    if (compteur2 == n)
                    {
                        series_j2++;
                    }
                }
            }

            compteur1 = 0;
            compteur2 = 0;

            //Diagonale montante
            for (i = 0; i < 3; i++)
            {
                if (jeu[i][2 - i] == "X")
                {
                    compteur1++;
                    compteur2 = 0;

                    if (compteur1 == n)
                    {
                        series_j1++;
                    }
                }
                else if (jeu[i][2 - i] == "O")
                {
                    compteur2++;
                    compteur1 = 0;

                    if (compteur2 == n)
                    {
                        series_j2++;
                    }
                }
            }

            //En ligne
            for (i = 0; i < 3; i++)
            {
                compteur1 = 0;
                compteur2 = 0;

                //Horizontalement
                for (j = 0; j < 3; j++)
                {
                    if (jeu[i][j] == "X")
                    {
                        compteur1++;
                        compteur2 = 0;

                        if (compteur1 == n)
                        {
                            series_j1++;
                        }
                    }
                    else if (jeu[i][j] == "O")
                    {
                        compteur2++;
                        compteur1 = 0;

                        if (compteur2 == n)
                        {
                            series_j2++;
                        }
                    }
                }

                compteur1 = 0;
                compteur2 = 0;

                //Verticalement
                for (j = 0; j < 3; j++)
                {
                    if (jeu[j][i] == "X")
                    {
                        compteur1++;
                        compteur2 = 0;

                        if (compteur1 == n)
                        {
                            series_j1++;
                        }
                    }
                    else if (jeu[j][i] == "O")
                    {
                        compteur2++;
                        compteur1 = 0;

                        if (compteur2 == n)
                        {
                            series_j2++;
                        }
                    }
                }
            }
            Series result = new Series();
            result.j2 = series_j2;
            result.j1 = series_j1;
            return result;
        }
        public int eval(List<List<String>> jeu)
        {
            int vainqueur, nb_de_pions = 0;
            int i, j;

            //On compte le nombre de pions présents sur le plateau
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (jeu[i][j] != "*")
                    {
                        nb_de_pions++;
                    }
                }
            }

            if ((vainqueur = gagnant(jeu)) != 0)
            {
                if (vainqueur == 1)
                {
                    return 1000 - nb_de_pions;
                }
                else if (vainqueur == 2)
                {
                    return -1000 + nb_de_pions;
                }
                else
                {
                    return 0;
                }
            }

            //On compte le nombre de séries de 2 pions alignés de chacun des joueurs

            Series series=nb_series(jeu, 2);

            return series.j1 - series.j2;

        }
        public int Max(List<List<String>> grille, int profondeur)
            {
            if (profondeur == 0 || gagnant(grille) != 0)
            {
                return eval(grille);
            }

            int max = -10000;
            int i, j, tmp;

            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    if (grille[i][j] == "*")
                    {
                        grille[i][j] = "O";
                        tmp = Min(grille, profondeur - 1);

                        if (tmp > max)
                        {
                            max = tmp;
                        }
                        grille[i][j] = "*";
                    }
                }
            }

            return max;
        }
        int gagnant(List<List<String>> jeu)
        {
            int i, j;
            Series series=nb_series(jeu,3);

            if (series.j1>series.j2)
            {
                return 1;
            }
            else if (series.j2>series.j1)
            {
                return 2;
            }
            else
            {
                //Si le jeu n'est pas fini et que personne n'a gagné, on renvoie 0
                for (i = 0; i < 3; i++)
                {
                    for (j = 0; j < 3; j++)
                    {
                        if (jeu[i][j] == "*")
                        {
                            return 0;
                        }
                    }
                }
            }

            //Si le jeu est fini et que personne n'a gagné, on renvoie 3
            return 3;
        }

    }
}
