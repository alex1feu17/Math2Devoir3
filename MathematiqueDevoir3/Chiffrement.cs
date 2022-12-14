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
            


            string messageChiffrer = " ";
           


            cle = Regex.Replace(cle, @"\s", "");
            nbCol = cle.Length;
            nbLi = message.Length / nbCol;
            char[,] tabMessage = new char[nbLi, nbCol];

            // Transporte le message dans un tableau 2D
            for (int j = 0; j < nbCol; j++)
            {
                for (int y = 0; y < nbLi; y++)
                {
                    if (compt != message.Length)
                    {
                        tabMessage[j, y] = message[compt];
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
                    for (int j = 0; j < nbLi; j++)
                        messageChiffrer = messageChiffrer + tabMessage[j, compt2];

                    compt++;
                    compt2 = 0;
                }
                else
                    compt2++;
            }

            /*Console.WriteLine("Entrez la valeur du vecteur d'initialisation :");
            vi = Console.ReadLine();*/
            byte[] vi = new byte[1];
            vi[0] = 00110;
            

            int[] messagevalue = new int[messageChiffrer.Length];
            byte[] messageBite = new byte[messageChiffrer.Length];

            //va chercher la valeur du char dans l'alphabet
            for (int j = 0; j < messageChiffrer.Length; j++)           
                messagevalue[j] = messageChiffrer[j] & NUM;

            int n, i;
            int[] a = new int[10];
           
            
            //transforme la valeur en byte 
            for (int j = 0; j < messageChiffrer.Length; j++)
            {
                n = messagevalue[j];
                for (i = 0; n > 0; i++)
                {
                    a[i] = n % 2;
                    n = n / 2;
                }
                for (i = i - 1; i >= 0; i--)
                {                   
                    messageBite[j] = (byte)a[i];
                }          
            }
                

            /*for (int j = 0; j < messageChiffrer.Length; j++)
            {
                if (j == 0)
                    messageBite[j] = (messageBite[j] ^ vi[0]) + (byte)00001;
                else
                    messageBite[j] = (messageBite[j] ^ messageBite[j - 1]) + (byte)00001;

                //Console.WriteLine(messagevalue[i]);
            }*/


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
