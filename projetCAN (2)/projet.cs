using System;
using System.Text;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
class projet
{
	static void Main()
	{

		Dictionary<string,Dictionary<string,int>> jourA =creerlg();
		Dictionary<string,Dictionary<string,int>> jourB =creergl();
		Dictionary<string,Dictionary<string,int>> jourC =creerqlep();
		Dictionary<string,Dictionary<string,int>> jourD =creerleq();
		menu(jourA, jourB,jourC, jourD);
	}
	public struct Pass //structure d'un passager
	{
		public string nom;
		public string prenom;
		public string categorie;
		public Pass(string n, string p , string c)
		{
			nom=n;
			prenom=p;
			categorie=c;
		}
	}
	public struct Ve  // structure d'un vehicule 
	{
		public string categorie;
		public int quantite;
		public Ve(string cat, int quant)
		{
			categorie=cat;
			quantite=quant;
		}
	}
	public struct Res // structure de la reservation
	{
		public string nomfam;
		public int liaison;
		public string date;
		public string heure;
		public Res(string n,string h,string d, int l)
		{
			nomfam=n;
			liaison=l;
			date=d;
			heure=h;
		}
	}
	public static Dictionary<string,Dictionary<string,int>> creerlg()
	/*
	 une fonction qui permet de créer le tableau des posssiblités de reservations pour chacun des trajet 
	 chaque trajet est repésenté par un dico de dico qui contiend les jours les horaires et un compteur 
	 ne renvoie rien 
	 pas de parametres 
	 :exemples:
	 >>>reservation()

	 >>>reservation()

	 */
	{
		Dictionary<string,Dictionary<string,int>> jourA = new Dictionary<string,Dictionary<string,int>>();	
		//création d'un dictionnaire pour la premiere traversée
			//ouverture d'un fichier rempli avec les horaire en mode lecture
			string path="logroix.txt";
                	FileStream fs = new FileStream("logroix.txt", FileMode.Open, FileAccess.Read);
                	StreamReader logroix = new StreamReader(path);
                	if(File.Exists("logroix.txt"))
                	{
                	        while(!logroix.EndOfStream)
                	        {
					//création du dico contenant toute les horaire et la place restante 
                	                string ligne =logroix.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
					char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
					//utilisation d'un dico temporaire pour l'imbriquer dans jourA
					Dictionary<string,int> tempdik1 = new Dictionary<string,int>();
					//remplissage de jourA
					for(int i =1; i<=temp2.Length-1; i++)
					{
						tempdik1.Add(temp2[i],30);
					}
					jourA.Add(temp[0],tempdik1);
				}
				

			}
			//fermeture du fichier txt
			logroix.Close();
			return jourA;
	}
	//la fonction prend en parametre jourA,B,C ou D pour pouvoir n'avoir qu'une fonction pour les 4 horaire
	public static void afficherhoraire(Dictionary<string,Dictionary<string,int>> jour)
		//cette fonction met dans une chaine de caractère les ligne du tableau et les affiche au fur et a mesure 
	{
		//on parcours les jours 
		foreach(string j in jour.Keys)
                {
   	             string chaine = j+"  ";
		     //on parcours les horaires
                     foreach(string k in jour[j].Keys)
                     {
  	                   chaine+= k +"  "+ jour[j][k]+"  ";
                     }
                     Console.WriteLine(" "+chaine+" ");
                }
	}
	public static Dictionary<string,Dictionary<string,int>> creerqlep()
		//fonction pour creer un deuxieme tableau (aller voir L65 pour plus de précision)
	{
		 Dictionary<string,Dictionary<string,int>> jourB = new Dictionary<string,Dictionary<string,int>>();	
               		string path="quibelait.txt";
                	FileStream fs = new FileStream("quibelait.txt", FileMode.Open, FileAccess.Read);
                	StreamReader quibelait = new StreamReader(path);
                	if(File.Exists("quibelait.txt"))
                	{
                	        while(!quibelait.EndOfStream)
                	        {
                	                string ligne =quibelait.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
                	                char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
                	                Dictionary<string,int> tempdik2 = new Dictionary<string,int>();
                	                for(int i =1; i<=temp2.Length-1; i++)
                	                {
                	                        tempdik2.Add(temp2[i],30);
                	                }
                	                jourB.Add(temp[0],tempdik2);
                	        }
			}
		quibelait.Close();
		return jourB;	
	}
	public static Dictionary<string,Dictionary<string,int>> creergl()
	{
		//fonction pour creer un troisieme tableau (aller voir L65 pour plus de précision)
		 Dictionary<string,Dictionary<string,int>> jourC = new Dictionary<string,Dictionary<string,int>>();
                	string path="groalo.txt";
                	FileStream fs = new FileStream("groalo.txt", FileMode.Open, FileAccess.Read);
                	StreamReader groalo = new StreamReader(path);
                	if(File.Exists("groalo.txt"))
                	{
                	        while(!groalo.EndOfStream)
                	        {
                	                string ligne =groalo.ReadLine();
                	                char[] separateur =new char[] {';'};
                	                string[] temp =ligne.Split(separateur);
                	                char[] separateur2 =new char[] {'|'};
                	                string[] temp2 =ligne.Split(separateur2);
                	                Dictionary<string,int> tempdik3 = new Dictionary<string,int>();
                	                for(int i =1; i<=temp2.Length-1; i++)
                	                {
                	                        tempdik3.Add(temp2[i],30);
                	                }
                	                jourC.Add(temp[0],tempdik3);
                	        }
			}
		groalo.Close();
		return jourC;
	}
	public static Dictionary<string,Dictionary<string,int>> creerleq()
		//fonction pour creer un quatrieme tableau (aller voir L65 pour plus de précision)
	{
		Dictionary<string,Dictionary<string,int>> jourD = new Dictionary<string,Dictionary<string,int>>();
                	string path="lepaquiberon.txt";
               		FileStream fs = new FileStream("lepaquiberon.txt", FileMode.Open, FileAccess.Read);
                	StreamReader lepaquiberon= new StreamReader(path);
                	if(File.Exists("lepaquiberon.txt"))
                	{
                	        while(!lepaquiberon.EndOfStream)
                	        {
                       		        string ligne =lepaquiberon.ReadLine();
                               		char[] separateur =new char[] {';'};
                                	string[] temp =ligne.Split(separateur);
                                	char[] separateur2 =new char[] {'|'};
                                	string[] temp2 =ligne.Split(separateur2);
                                	Dictionary<string,int> tempdik4 = new Dictionary<string,int>();
                                	for(int i =1; i<=temp2.Length-1; i++)
                                	{
                                	        tempdik4.Add(temp2[i],30);
                                	}
                                	jourD.Add(temp[0],tempdik4);
                        	}
				lepaquiberon.Close();
			}
		lepaquiberon.Close();	
		return jourD;
	}
	public static void reservation(Dictionary<string,Dictionary<string,int>> jour)
		//fonction pour décrémenter la place sur le bateau 
	{
		//demande a l'utilisateur les modalité de son voyage 
		afficherhoraire(jour);
		Console.WriteLine("quel jour voulez vous (copiez bien pls )");
		string choixjour = Console.ReadLine();
		if(jour.ContainsKey(choixjour))
		{
			 Console.WriteLine("quelle horaire ?");
                         string choixhoraire = Console.ReadLine();
			 Console.WriteLine("cb etes vous (les vehicules compte comme un personne)");
                         int nbpersonne = int.Parse(Console.ReadLine());
			 //décrémentation du tableau 
		         jour[choixjour][choixhoraire] -= nbpersonne;
		}
	}


	public static void menu(Dictionary<string,Dictionary<string,int>> jourA, Dictionary<string,Dictionary<string,int>> jourB,Dictionary<string,Dictionary<string,int>> jourC,Dictionary<string,Dictionary<string,int>> jourD)
	{
		//le menu est la plus grosse fonction elle fait le déroulement de la reservation
		if(File.Exists("final.json"))
		{
			//ouverture d'un fichier en mode ajout (il aura ete vidé de tout test avant le rendu )
			FileStream fs = new FileStream("final.json ",FileMode.Append, FileAccess.Write);
			StreamWriter final = new StreamWriter(fs);
			final.WriteLine("[{");
			//demande a l'utilisateur ce qu'il veut faire 
		Console.WriteLine("que voulez vous faire \n 1- voir les horaire \n 2- voir les tarifs \n 3- reserver une traversée \n ne rien faire  (les espaces ne sont utile a aucun moment )");
		int n=int.Parse(Console.ReadLine());
		//choix de voir les horaire 
		if(n==1)
		{
			//demande quels horaires il veut voir 
			Console.WriteLine("quelle traversée voulez vous voir?\n 1-lorient->groix \n 2-groix->lorient \n 3-quiberon->le palais \n 4-le palais ->quiberon ");
			int m=int.Parse(Console.ReadLine());
			//en fonction de la reponse on appelle afficher horaire avec un parametre different 
			if(m==1)
			{
				afficherhoraire(jourA);
			}
			else if(m==2)
			{
				afficherhoraire(jourB);
			}
			else if(m==3)
			{
				afficherhoraire(jourC);
			}
			else if(m==4)
			{
				afficherhoraire(jourD);
			}
			
		}
		//choix de voir les horaire 
		else if(n==2)
		{
			//voir la fin du code pour la fonction afficher tarifs 
			affichertarifs();
		}
		//choix de faire une reservation 
		else if(n==3)
		{
			//demande pour quelle horaire il souhaite faire un reservation 
			Console.WriteLine("quelle traversée voulez vous reserver?\n 1-lorient->groix \n 2-groix->lorient \n 3-quiberon->le palais \n 4-le palais ->quiberon ");
                        int m=int.Parse(Console.ReadLine());
			
                        if(m==1)
                        {
                                reservation(jourA);
				//recupération de la date local de l'ordi 
				DateTime localdate = DateTime.Now;
				//demande de précision
				Console.WriteLine("veuillez donnez votre nom");
                                string nomfam = Console.ReadLine();
                                Console.WriteLine("veuiller valider le jour");
                                string choixjour = Console.ReadLine();
                                Console.WriteLine("veuillervalider l'heure");
                                string choixhoraire = Console.ReadLine();
				//création de l'objet resa1 de type reservation
                                Res resa1 = new Res(nomfam, choixhoraire, choixjour, 1);
				//ajout dans le fichier json
				final.WriteLine("	\"reservation\":\n		{\n			\"nom\":\""+resa1.nomfam+"\",\n			\"idLiaison\":1,\n			\"date\":\""+resa1.date+"\",\n			\"heure\":\""+resa1.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");
				Console.WriteLine("veuiller reprécisez combien vous etes");
                                int nbpers = int.Parse(Console.ReadLine());
                                double apayer=0;
				Console.WriteLine("cb de gens");
				int nbgens = int.Parse(Console.ReadLine());
				final.WriteLine("	\"passagers\": [");
                                for(int i=0; i<nbgens; i++)
                                {
					//en fonction du type de la personne on va creer le passagers et l'ajouter dans le json tout en incrémentant letotal a payer 
                 	               Console.WriteLine("de quel type est elle : adu26p/jeu1825/enf417/bebe/ancomp");
                                       string type = Console.ReadLine();
                                       if(type == "adu26p")
                                       {
						Console.WriteLine("nom");
                                       		 string nompers=Console.ReadLine();
                                       		Console.WriteLine("prenom");
                                       		string prenompers=Console.ReadLine();
                                       		Pass personne = new Pass(nompers, prenompers, type);
                                       		apayer += 18.75;
						final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
					}
                                               else if(type == "jeu1825")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 13.80;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }                                   
                                                else if(type == "enf417")	
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.25;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                 }
					if(i==nbgens-1)
					{
						final.WriteLine("		}");
					}
					else
					{
						final.WriteLine("		},");
					}
					}
					Console.WriteLine("cb de vehicules");
					int nbvoit = int.Parse(Console.ReadLine());
					final.WriteLine("	],");
					final.WriteLine("	\"vehicules\": [");
					for(int i=0; i<nbvoit; i++)
						//pareil pour les vehicule 
					{
						Console.WriteLine("de quel type est-il: trot/velo/velelec/cartand/mobil/moto/cat1/cat2/cat3/cat4/camp");
                                                string type = Console.ReadLine();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
						}
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.10*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.05*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 96.05*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 114.80*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 174.45*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 210.90*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 330.20*nbveh;
							final.WriteLine("		{\n            		\"codeCategorie\":\""+bagnole.categorie+"\",\n           		\"quantite\":\""+bagnole.quantite+"\"");
                                                }
					 if(i==nbvoit-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
					}
					final.WriteLine(	"]");
					//on renvoit le total a payer
					Console.WriteLine("vous aurez donc a payer" + apayer + "$ bande de malotru");
			}
                        else if(m==2)
				//meme chose pour un horaire différent voir L265
                        {
                                reservation(jourB);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("veuillez donnez votre nom");
                                string nomfam = Console.ReadLine();
                                Console.WriteLine("veuiller valider le jour");
                                string choixjour = Console.ReadLine();
                                Console.WriteLine("veuillervalider l'heure");
                                string choixhoraire = Console.ReadLine();
                                Res resa2 = new Res(nomfam, choixhoraire, choixjour, 2);
				final.WriteLine("       \"reservation\":\n          {\n                  \"nom\":\""+resa2.nomfam+"\",\n                  \"idLiaison\":\"1\",\n                  \"date\":\""+resa2.date+"\",\n                  \"heure\":\""+resa2.heure+"\",\n                  \"horodatage\":\""+localdate+"\"\n            },");
				Console.WriteLine("veuiller reprécisez combien vous etes");
                                int nbpers = int.Parse(Console.ReadLine());
                                double apayer=0;
				Console.WriteLine("comboien de personne?");
                                int limite = int.Parse(Console.ReadLine());
				final.WriteLine("       \"passagers\": [");
                                for(int i=0; i<nbpers; i++)
                                {
                                        Console.WriteLine("personne ou vehicule?");
                                        string binairetype=Console.ReadLine();
                                        if(binairetype == "personne")
                                        {
                                                Console.WriteLine("de quel type est elle : adu26p/jeu1825/enf417/bebe/ancomp");
                                                string type = Console.ReadLine();
                                                if(type == "adu26p")
                                                {
							Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							apayer += 18.75;
							final.WriteLine("       		{\n             		\"nom:\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n		        \"codeCategorie\":\""+personne.categorie+"\"");
						}
                                                else if(type == "jeu1825")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 13.80;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "enf417")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.25;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                              	if(i==limite-1)
                                        	{
                                                	final.WriteLine("		}");
                                        	}
                                        	else
                                        	{
                                                	final.WriteLine("		},");
                                        	}
					
                                        }
                                        else
                                        {
						final.WriteLine("	],");
                                                final.WriteLine("	\"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
						i+=1;
                                                Console.WriteLine("de quel type est-il: trot/velo/velelec/cartand/mobil/moto/cat1/cat2/cat3/cat4/camp");
                                                string type = Console.ReadLine();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.10*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.05*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 96.05*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 114.80*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 174.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 210.90*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 330.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"\n		}");
                                                }
					if(i==nbpers-1)
                                        {
                                                final.WriteLine("		},");
                                        }
                                        else
                                        {
                                                final.WriteLine("		}");
                                        }
						}
                                        }
                                }
				final.WriteLine("	]");
				Console.WriteLine("vous aurez donc a payer" + apayer + "$ bande de malotru");
			}
                        else if(m==3)
                        {
				//meme chose pour un horaire différent voir L265
                                reservation(jourC);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("veuillez donnez votre nom");
                                string nomfam = Console.ReadLine();
                                Console.WriteLine("veuiller valider le jour");
                                string choixjour = Console.ReadLine();
                                Console.WriteLine("veuillervalider l'heure");
                                string choixhoraire = Console.ReadLine();
                                Res resa3 = new Res(nomfam, choixhoraire, choixjour, 3);
				final.WriteLine("       \"reservation\":\n          	{\n			\"nom\":\""+resa3.nomfam+"\",\n			\"idLiaison\":1,\n			\"date\":\""+resa3.date+"\",\n			\"heure\":\""+resa3.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");
				Console.WriteLine("veuiller reprécisez combien vous etes");
                                int nbpers = int.Parse(Console.ReadLine());
                                double apayer=0;
				Console.WriteLine("combien de personne");
				int limite = int.Parse(Console.ReadLine());
				final.WriteLine("       \"passagers\": [");
                                for(int i=0; i<nbpers; i++)
                                {
                                        Console.WriteLine("personne ou vehicule?");
                                        string binairetype=Console.ReadLine();
                                        if(binairetype == "personne")
                                        {
                                                Console.WriteLine("de quel type est elle : adu26p/jeu1825/enf417/bebe/ancomp");
                                                string type = Console.ReadLine();
                                                if(type == "adu26")
                                                {
							Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 14.1;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
						}
                                               else if(type == "jeu1825")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 14.1;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "bebe")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else if(type == "enf417")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.65;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
                                                else
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("		{\n			\"nom\":\""+personne.nom+"\",\n			\"prenom\":\""+personne.prenom+"\",\n			\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
					if(i==limite-1)
                                        {
                                                final.WriteLine("		},");
                                        }
                                        else
                                        {
                                                final.WriteLine("		}");
                                        }
                                        }
                                        else
                                        {
						final.WriteLine("	],");
                                                final.WriteLine("	\"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
						i+=1;
                                                Console.WriteLine("de quel type est-il: trot/velo/velelec/cartand/mobil/moto/cat1/cat2/cat3/cat4/camp");
                                                string type = Console.ReadLine();
                                                if(type == "trot")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "velo")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 8.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "velelec")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cartand")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "mobil")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "moto")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.40*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat1")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 98.50*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat2")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 117.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "cat3")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 176.90*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                 else if(type == "cat4")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 213.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
                                                else if(type == "camp")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 332.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						 if(i==nbpers-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
						}
                                        }
                                }
				final.WriteLine("	]");
				Console.WriteLine("vous aurez donc a payer" + apayer + "$ bande de malotru");
			}
                        else if(m==4)
                        {
				//meme chose pour un horaire différent voir L265
                                reservation(jourD);
				DateTime localdate = DateTime.Now;
				Console.WriteLine("veuillez donnez votre nom");
                                string nomfam = Console.ReadLine();
                                Console.WriteLine("veuiller valider le jour");
                                string choixjour = Console.ReadLine();
                                Console.WriteLine("veuillervalider l'heure");
                                string choixhoraire = Console.ReadLine();
                                Res resa4 = new Res(nomfam, choixhoraire, choixjour, 4);
				final.WriteLine("       \"reservation\":\n		{\n			\"nom\":\""+resa4.nomfam+"\",\n			\"idLiaison\":1,\n			\"date\":\""+resa4.date+"\",\n			\"heure\":\""+resa4.heure+"\",\n			\"horodatage\":\""+localdate+"\"\n		},");

				Console.WriteLine("veuiller reprécisez combien vous etes");
				int nbpers = int.Parse(Console.ReadLine());
				double apayer=0;
				Console.WriteLine("combien de personne");
				int limite =int.Parse(Console.ReadLine());
				final.WriteLine("       \"passagers\": [");
				for(int i=0; i<nbpers; i++)
				{
					Console.WriteLine("personne ou vehicule?");
					string binairetype=Console.ReadLine();
					if(binairetype == "personne")
					{
						Console.WriteLine("de quel type est elle : adu26p/jeu1825/enf417/bebe/ancomp");
						string type = Console.ReadLine();
						if(type == "adu26p")
						{
							Console.WriteLine("nom");
							string nompers=Console.ReadLine();
							Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
							Pass personne = new Pass(nompers, prenompers, type);
							apayer += 18.8;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
								
						}
						else if(type == "jeu1825")
						{
							Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 14.1;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
						}
						else if(type == "enf417")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 11.65;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else if(type == "bebe")
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
						else
                                                {
                                                        Console.WriteLine("nom");
                                                        string nompers=Console.ReadLine();
                                                        Console.WriteLine("prenom");
                                                        string prenompers=Console.ReadLine();
                                                        Pass personne = new Pass(nompers, prenompers, type);
                                                        apayer += 3.35;
							final.WriteLine("       		{\n             		\"nom\":\""+personne.nom+"\",\n         		\"prenom\":\""+personne.prenom+"\",\n           		\"codeCategorie\":\""+personne.categorie+"\"");
                                                }
					if(i==limite-1)
                                        {
                                                final.WriteLine("		},");
                                        }
                                        else
                                        {
                                                final.WriteLine("		}");
                                        }
					}
					else
					{
						final.WriteLine("	],");
                                                final.WriteLine("       \"vehicules\": [");
						for(int j=i; j<nbpers; j++)
						{
						i+=1;
						Console.WriteLine("de quel type est-il: trot/velo/velelec/cartand/mobil/moto/cat1/cat2/cat3/cat4/camp");
                                                string type = Console.ReadLine();
						if(type == "trot")
						{
							Console.WriteLine("combien ? ");
							int nbveh = int.Parse(Console.ReadLine());
							Ve bagnole = new Ve(type,nbveh);
							apayer += 4.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
						}
						else if(type == "velo")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
							apayer += 8.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "velelec")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 11*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "cartand")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 16.45*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "mobil")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 23.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "moto")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 66.40*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "cat1")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 98.50*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "cat2")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 117.20*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "cat3")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 176.90*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "cat4")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 213.35*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						else if(type == "camp")
                                                {
                                                        Console.WriteLine("combien ? ");
                                                        int nbveh = int.Parse(Console.ReadLine());
                                                        Ve bagnole = new Ve(type,nbveh);
                                                        apayer += 332.70*nbveh;
							final.WriteLine("		{\n			\"codeCategorie\":\""+bagnole.categorie+"\",\n			\"quantite\":\""+bagnole.quantite+"\"");
                                                }
						 if(i==nbpers-1)
                                        {
                                                final.WriteLine("		}");
                                        }
                                        else
                                        {
                                                final.WriteLine("		},");
                                        }
						}
					}
					final.WriteLine("	]");
					Console.WriteLine("vous aurez donc a payer" + apayer + "$ bande de malotru");
				}
			}
		}
		// on demande si la personne souhaite s'arreter auquel cas on ferme le fichier sinon on relance le menu 
			Console.WriteLine("voulez vous quitter O/N");
                        string test=Console.ReadLine();
                        if(test=="N")
                        {
				final.Close();
				menu(jourA, jourB, jourC, jourD);
                        }
			else
			{
				final.WriteLine("}]");
				final.Close();
			}
		}

	}
	public static void affichertarifs()
	{
		// juste un gros affichage en dur 
		Console.WriteLine("prix pour une traversé  : \n adulte (26 ans et plus): groix 18,75 bellile 18,80 \n jeune (18-25 ans ): groix 13.80 bellile 14.10 \n enfant (4-17 ans): groix 11.25 bellile 11.65 \n bebe(-de 4 ans): gratuit \n animal: 3.35 \n trotinette éléctrique: 4.70 \n velo: 8.20 \n velo electrique: 11 \n tandem/velo cargo: 16.45 \n mobilette: groix 23.10 bellile 23.35 \n moto: groix 66.05 bellile 66.40 \n voiture de - de 4m: groix 96.05 bellile 98.50 \n voiture entre 4-4.39 m: groix 114.80 bellile 117.20 \n voiture entre 4.40 - 4.79 m: groix 174.45 bellile 176.90 \n voiture de + de 4.80 m: groix 210.90 bellile 213.35 \n camping car : groix 330.20 bellile 332.70 \n");
	}


}
	


	
