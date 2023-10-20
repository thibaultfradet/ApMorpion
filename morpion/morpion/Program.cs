using System;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace Morpion
{
    class Program
    {
        public static int[,] grille = new int[3, 3]; // matrice pour stocker les coups joués

        // Fonction permettant l'affichage du Morpion
        public static void AfficherMorpion(int j, int k)
        {
        	
        	//Affichage grille
        	 Console.Clear();
			for ( j = 0; j < grille.GetLength(0); j++)
			{
				Console.Write("\n|===|===|===|\n");
				Console.Write("|");
			  	for (k = 0; k < grille.GetLength(1); k++)	
			  	{
			    	if (grille[j,k] == 10)
			  		{
			    		Console.Write(" - ");
			    		Console.Write("|");
			  		}
			  		
			  		else if (grille[j,k] == 1)
			  		{
			  			Console.Write(" X ");
			  			Console.Write("|");
			  		}
			  		else
			  		{
			  			Console.Write(" O ");
			  			Console.Write("|");
			  		}
			    }
			}
			Console.Write("\n|===|===|===|");
			Console.WriteLine("\n");
        }

        // Fonction permettant de changer
        // dans le tableau qu'elle est le 
        // joueur qui à jouer
        // Bien vérifier que le joueur ne sort
        // pas du tableau et que la position
        // n'est pas déjà jouée
        public static bool AJouer(int j, int k, int joueur)
        {
           //Si les indices sont en dehors de la limite 
        	if (j < 0 || j >= 3 || k < 0 || k >= 3)
        	{
        		Console.WriteLine("Mauvaise positionnement");
        		//On retourne false ,sortie de fonction
        		return false;
        	}
        	
        	
        	//Cas endroit libre
        	if (grille[j,k] != 1 && grille[j,k] !=2)
        	{
        		//Mise de la grille a l'emplacement voulu a joueur
        		grille[j,k] = joueur;
        		
        		//On retourne true le joueur a jouer ,sortie de fonction
        		return true;
        	}
        	
        	//La fonction n'a rien pas etait quitter on a rien retourner donc l'emplacement est deja prie on retourne false
        	return false;
        }

        // Fonction permettant de vérifier
        // si un joueur à gagner
        public static bool Gagner(int l, int c, int joueur)
        {
            //Partie Vertical
           	
           	
            //Methode utiliser : chiffre direct 
            
            if (grille[0,0] == joueur && grille[1,0] == joueur && grille[2,0] == joueur)
            {
            	Console.Clear();
            	Console.WriteLine("Win vertical");
            	return true;
            }
            
            if (grille[0,1] == joueur && grille[1,1] == joueur && grille[2,1] == joueur)
            	
            {
            	Console.Clear();
            	Console.WriteLine("Win vertical");
            	return true;
            }
            
            if (grille[0,2] == joueur && grille[1,2] == joueur && grille[2,2] == joueur)
            {
            	Console.Clear();
            	Console.WriteLine("Win vertical");
            	return true;	
            }
            
            
            
            //Partie horizontale
            
             //Methode utiliser : chiffre direct 
            
             if (grille[0,0] == joueur && grille[0,1] == joueur && grille[0,2] == joueur)
            {
            	Console.Clear();
            	Console.WriteLine("Win horizontale");
            	return true;
            }
            
             if (grille[1,0] == joueur && grille[1,1] == joueur && grille[1,2] == joueur)
            	
            {
            	Console.Clear();
            	Console.WriteLine("Win vertical");
            	return true;
            }
            
             if (grille[2,0] == joueur && grille[2,1] == joueur && grille[2,2] == joueur)
            {
            	Console.Clear();
            	Console.WriteLine("Win vertical");
            	return true;	
            }
            
            //Partie diagonale
            
          //Diagonale gauche vers droite
            //Methode utiliser : parcours (chiffre direct)
           
            if (grille[0,0] == joueur && grille[1,1] == joueur && grille [2,2] == joueur)
            {
            	Console.WriteLine("Win diagonale");
            	return true;
            }
            	
           //Diagonale droite vers gauche
           //Methode utiliser : parcours (chiffre direct)
			
           if (grille[2,0] == joueur && grille[1,1] == joueur && grille[0,2] == joueur) {
           		Console.WriteLine("Win diagonale");
           		return true;
			}

           
            
            return false;
        }

        // Programme principal
        static void Main(string[] args)
        {
            //--- Déclarations et initialisations --
            int LigneDébut = Console.CursorTop;     // par rapport au sommet de la fenêtre
            int ColonneDébut = Console.CursorLeft; // par rapport au sommet de la fenêtre

            int essais = 0;    // compteur d'essais
	        int joueur = 1 ;   // 1 pour la premier joueur, 2 pour le second
	        int l, c = 0;      // numéro de ligne et de colonne
            int j, k = 0;      // Parcourir le tableau en 2 dimensions
            bool gagner = false; // Permet de vérifier si un joueur à gagné 
            bool bonnePosition = false; // Permet de vérifier si la position souhaité est disponible

	        //--- initialisation de la grille ---
            // On met chaque valeur du tableau à 10
	        for (j=0; j < grille.GetLength(0); j++)
		        for (k=0; k < grille.GetLength(1); k++)
			        grille[j,k] = 10;
					while(!gagner && essais != 9)
					{
						
						//Affichage de la grille
        				AfficherMorpion(j,k);
						
						
						try
						{
							Console.WriteLine("Ligne   =    ");
							Console.WriteLine("Colonne =    ");
							// Peut changer en fonction de comment vous avez fait votre tableau.
							Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 9); // Permet de manipuler le curseur dans la fenêtre 
							l = int.Parse(Console.ReadLine()) - 1; 
							// Peut changer en fonction de comment vous avez fait votre tableau.
							Console.SetCursorPosition(LigneDébut + 10, ColonneDébut + 10); // Permet de manipuler le curseur dans la fenêtre 
							c = int.Parse(Console.ReadLine()) - 1;

							
							//Mise bonne position(booleen retour fonction) a retour de AJouer
							bonnePosition = AJouer(l,c,joueur);
								
							
						}
						
						
						catch (Exception e)
						{
							Console.WriteLine(e.ToString());
						}
						
						
						//Test si joueur gagnant début d'iteration
						if (Gagner(j,k,joueur)==true) {
							gagner = true;
						}

						
						//Cas le jeu a etait fait correctement et joueur est 1
						if (bonnePosition == true && joueur == 1)
						{
							//Incremente nb essaie car tour est bon
							essais +=1;
							
							//On change de joueur a 2
							joueur = 2;
						}
						
						//Cas la jeu a etait fait correctement et joueur est 2
						else if (bonnePosition == true && joueur == 2)
						{
							//Incremente nb essaie car tour est bon
							essais +=1;
							
							//On change de joueur a 1
							joueur = 1;
						}
					
						
						
					};
					 // Fin de la partie
            	//Cas égalité car la boucle c'est arreter et gagner est toujours a false
            	if (gagner == false)
            	{
            		//Annonce égalité
            		Console.WriteLine("Egalité");
            	}
            
            	//Cas où la boucle cest arreter car gagner est a true donc quelqun a gagner 
           		 else
           	 	{
            		//Annonce du gagnant
            		Console.WriteLine("Felicitations le gagnant est : "+ joueur);
           		}
					
					
			//A completer
            Console.ReadKey();
    }
  }
}
