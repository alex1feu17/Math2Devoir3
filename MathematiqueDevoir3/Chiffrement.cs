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
        public static String Chiffrer(String message, String cle)
        {
            int nbCol = 0;
            int nbLi = 0;
            string messageChiffrer = " ";
            cle = Regex.Replace(cle, @"\s", "");

            nbCol = cle.Length;
            nbLi = message.Length / nbCol;

            char[,] tabMessage = new char[nbLi,nbCol];

            int compt = 0;

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
            int compt2 = 0;
            while (compt != cle.Length+1)
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
            return messageChiffrer;
        }
        public static String Dechiffrer(String message, String cle)
        {
            return "D";
        }
    }
}
