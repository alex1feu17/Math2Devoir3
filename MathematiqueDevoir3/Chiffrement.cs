using System.Text;
using System.Text.RegularExpressions;

namespace MathematiqueDevoir3
{
    static class Chiffrement
    {
        // On retourne un byte[] plutôt qu'un string, car la conversion en string transforme les bytes > que 126 en 63, ce qui rend le déchiffrement impossible.
        // Le résultat est donc stocké sous cette forme et converti en string lors de l'affichage.
        public static byte[] Chiffrer(string message, string cle)
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
            byte[] result = new byte[message.Length];
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
                        result[index++] = vi;
                    }
            }

            return result;
        }
        
        // On recoit un message à déchiffrer sous forme d'un byte[] pour la raison expliqué plus haut.
        public static string Dechiffrer(byte[] message, string cle)
        {
            // On retire les espaces et on convertit la clé en int[]
            int[] key = cle.Replace(" ", "").Select(e => Convert.ToInt32(e.ToString())).ToArray();

            Console.Write("Entrez le vecteur d'initialisation: ");
            byte vi = Convert.ToByte(Console.ReadLine(), 2);

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
                        tableau[l, c] ^= message[index];
                        vi = message[index++];
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
