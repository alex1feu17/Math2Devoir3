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
            int NUM = 31;
            byte[] vi = new byte[1];
            vi[0] = 00110;


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

            /*Console.WriteLine("Entrez la valeur du vecteur d'initialisation :");
            vi = Console.ReadLine();*/

            int[] messagevalue = new int[messageChiffrer.Length];
            byte[] messageBite = new byte[messageChiffrer.Length];

            for (int i = 0; i < messageChiffrer.Length; i++)           
                messagevalue[i] = messageChiffrer[i] & NUM;

            for (int i = 0; i < messageChiffrer.Length; i++)           
                messageBite[i] =  (byte)messagevalue[i];

            for (int i = 0; i < messageChiffrer.Length; i++)
            {
                if (i == 0)
                    messagevalue[i] = (messagevalue[i] ^ vi[0]) + (byte)00001;
                else
                    messagevalue[i] = (messagevalue[i] ^ messagevalue[i - 1]) + (byte)00001;

                Console.WriteLine(messagevalue[i]);
            }
            

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
