using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MathematiqueDevoir3
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";

            string selection;
            do
            {
                Console.Clear();
                Console.WriteLine("[1] Chiffrer");
                Console.WriteLine("[2] Déchiffrer");
                Console.WriteLine("[3] Quitter");
                Console.Write("\nSelectionnez une option: ");

                switch (selection = Console.ReadLine())
                {
                    case "1":
                        Console.Write("Entrez le message à chiffrer: ");
                        string message = Console.ReadLine();
                        Console.Write("Entrez la clé de transposition: ");

                        result = Chiffrement.Chiffrer(message, Console.ReadLine());
                        Console.WriteLine();

                        Console.WriteLine("Message chiffré: " + new string(result.Where(c => c >= 32).ToArray()));
                        break;
                    case "2":
                        if (String.IsNullOrEmpty(result)) {
                            Console.WriteLine("Aucun message à déchiffrer.");
                            break;
                        }
                        Console.Write("Entrez la clé de transposition: ");
                        string res = Chiffrement.Dechiffrer(result, Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Message déchiffré: " + res);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("Sélection invalide.");
                        break;
                }

                if (!selection.Equals("3"))
                {
                    Console.Write("\nAppuyez sur une touche pour continuer...");
                    Console.ReadLine();
                }
            } while (selection != "3");
        }
    }
}
