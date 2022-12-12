using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            for (int i = 0; i < nbCol; i++)
            {
                for (int y = 0; y < nbLi; y++)
                {
                    Console.Write(tabMessage[i, y]);
                }
                Console.Write("\n");
            }
            return "C";
        }
        public static String Dechiffrer(String message, String cle)
        {
            return "D";
        }
    }
}
