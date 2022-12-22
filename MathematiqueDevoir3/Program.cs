using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MathematiqueDevoir3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] result = new byte[0];

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

                        Console.WriteLine("Message chiffré: " + Encoding.ASCII.GetString(result.Where(b => b >= 32).ToArray()));
                        Console.WriteLine("Représentation binaire: [" + String.Join(", ", result.Select(b => Convert.ToString(b, 2)).ToArray()) + "]");
                        break;
                    case "2":
                        if (result.Length == 0) {
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
