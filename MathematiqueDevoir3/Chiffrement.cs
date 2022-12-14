using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MathematiqueDevoir3
{
    static class Chiffrement
    {
        public static int StringToByte(String message)
        {
            int y = 0;

            for (int i = message.Length-1; i >=0; i--)
            {
               y+=((int)message.ElementAt<char>(i)) * (int)Math.Pow(2,(i-message.Length+1));
            }
            Console.Write(y);
            return y;
        }
        public static String Chiffrer(String message, String cle)
        {
            int nbCol = 0;
            int nbLi = 0;
            int compt = 0;
            int compt2 = 0;
            string vi;
            
            string messageChiffrer = " ";
            
                        
            cle = Regex.Replace(cle, @"\s", "");
            nbCol = cle.Length;
            nbLi = message.Length / nbCol;
            char[,] tabMessage = new char[nbLi, nbCol];

            // Transporte le message dans un tableau 2D
            for (int i = 0; i < nbCol; i++)
            {
                for (int y = 0; y < nbLi; y++)
                {
                    if (compt != message.Length)
                    {
                        tabMessage[i, y] = message[compt];
                        compt++;
                    }                  
                }
            }          
            compt = 1;

            // Chiffrer le message a l'aide du tableau
            while (compt != cle.Length + 1)
            {
                if (compt.ToString() == cle[compt2].ToString())
                {
                    for (int i = 0; i < nbLi; i++)
                        messageChiffrer = messageChiffrer + tabMessage[i, compt2];

                    compt++;
                    compt2 = 0;
                }
                else
                    compt2++;
            }

            Console.WriteLine("Entrez la valeur du vecteur d'initialisation :");
            vi = Console.ReadLine();

            

         

            return messageChiffrer;
        }
        public static String Dechiffrer(String message, String cle)
        {
            int nbCol = 0;
            int nbLi = 0;
            int compt = 0;
            cle = Regex.Replace(cle, @"\s", "");
            nbCol = cle.Length;
            nbLi = message.Length / nbCol;
            char[,] tabdefmessage = new char[nbLi, nbCol];

            // Transporte le message chiffrer dans un tableau 2D
            for (int i = 0; i < nbCol; i++)
            {
                for (int y = 0; y < nbLi; y++)
                {
                    if (compt != message.Length)
                    {
                        tabdefmessage[i, y] = message[compt];
                        compt++;
                    }
                }
            }
            return "D";
        }
    }
}
