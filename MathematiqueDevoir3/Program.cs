﻿using System.Linq.Expressions;
namespace MathematiqueDevoir3
{
    class Program
    {
        static void Main(string[] args)
        {
           string key = " ";
           string message = " ";
           string option;

           do
           {
            
               Console.Clear();
               Console.WriteLine("Menu ");
               Console.WriteLine("1- Entrez la clef de transposition :");
               Console.WriteLine("2- Allez chercher le document incluant le message :");
               Console.WriteLine("3- Afficher le message chiffré :");
               Console.WriteLine("4- Afficher le message déchiffré :");
               Console.WriteLine("Selectionné votre option :");

           

                switch (option = Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Entrez la clé de transposition :");
                        key = Console.ReadLine();                   

                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Entrez le nom du fichier :");

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                                    

                        break;
                    case "3":
                        Console.WriteLine("Message chiffré :");

                        break;
                    case "4":
                        Console.WriteLine("Message déchiffré :");

                        break;
                    default:
                        break;
                }

                if (!option.Equals("5"))
                {
                    Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                    Console.ReadLine();
                }

            }while (option != "5");
        }
    }
}
