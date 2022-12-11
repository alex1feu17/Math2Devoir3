using System.Linq.Expressions;
namespace MathematiqueDevoir3
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Menu ");
           Console.WriteLine("1- Entrez la clef de transposition :");
           Console.WriteLine("2- Allez chercher le document incluant le message :");
           Console.WriteLine("3- Afficher le message chiffré :");
           Console.WriteLine("4- Afficher le message déchiffré :");

           Console.WriteLine("Selectionné votre option :");
           string number = Console.ReadLine();

            switch (number)
            {
                case "1":
                    Console.WriteLine("Entrez la clé de transposition :");
                    string key = Console.ReadLine();                   

                    break;
                case "2":
                    Console.WriteLine("Chercher le document incluant le message :");                    

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
        }
    }
}
