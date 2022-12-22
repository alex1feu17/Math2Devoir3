using System.Text;
using System.Text.RegularExpressions;

namespace MathematiqueDevoir3
{
    static class Chiffrement
    {
        public static string Chiffrer(string message, string cle)
        {
            // On retire les espaces et on convertit la clé en int[]
            int[] key = cle.Replace(" ", "").Select(e => Convert.ToInt32(e.ToString())).ToArray();

            Console.Write("Entrez le vecteur d'initialisation: ");
            byte vi = Convert.ToByte(Console.ReadLine(), 2);

            // On convertit le message en byte[]
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            byte[,] tableau = new byte[(int)Math.Ceiling((double)bytes.Length / key.Length), key.Length];

            // On remplit le tableau
            int index = 0;
            for (int l = 0; l < tableau.GetLength(0); l++)
                for (int c = 0; c < tableau.GetLength(1); c++)
                    if (bytes.Length > index) tableau[l, c] = bytes[index++];

            // On alimente le résultat en parcourant le tableau
            string result = "";
            index = 0;
            for (int i = 1; i <= key.Length; i++)
            {
                // On va déterminer la colonne grace à son index dans la clé
                int c = Array.IndexOf(key, i);
                for (int l = 0; l < tableau.GetLength(0); l++)
                    if (tableau[l, c] > 0)
                    {
                        // On applique le chiffrement CBC en même temps qu'on alimente le résultat
                        vi ^= tableau[l, c];
                        result += Convert.ToChar(vi);
                    }
            }

            return result;
        }
        
        public static string Dechiffrer(string message, string cle)
        {
            // On retire les espaces et on convertit la clé en int[]
            int[] key = cle.Replace(" ", "").Select(e => Convert.ToInt32(e.ToString())).ToArray();

            Console.Write("Entrez le vecteur d'initialisation: ");
            byte vi = Convert.ToByte(Console.ReadLine(), 2);

            // On convertit le message en byte[]
            byte[] bytes = Encoding.ASCII.GetBytes(message);
            byte[,] tableau = new byte[(int)Math.Ceiling((double)message.Length / key.Length), key.Length];

            // On alimente le tableau
            int index = 0;
            for (int i = 1; i <= key.Length; i++)
            {
                // On va déterminer la colonne grace à son index dans la clé
                int c = Array.IndexOf(key, i);
                for (int l = 0; l < tableau.GetLength(0); l++)
                    if (message.Length > index && (l * tableau.GetLength(1)) + c < message.Length)
                    {
                        // On applique le déchiffrement CBC en même temps qu'on alimente le tableau
                        tableau[l, c] = vi;
                        tableau[l, c] ^= bytes[index];
                        vi = bytes[index++];
                    }
            }

            // On alimente le résulat en parcourant le tableau
            string result = "";
            for (int l = 0; l < tableau.GetLength(0); l++)
                for (int c = 0; c < tableau.GetLength(1); c++)
                    if (tableau[l, c] > 0) result += Convert.ToChar(tableau[l, c]);

            return result;
        }
    }
}
