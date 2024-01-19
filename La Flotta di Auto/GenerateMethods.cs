using System;
using System.Collections.Generic;

namespace La_Flotta_di_Auto
{
    internal static class Methods
    {
        static List<string> AllTarga = new List<string>();
        static List<string> AllAutorisation = new List<string>();
        public static string GenerateAutorisation()
        {
            string autorisation = "";
            char[] vocali = { 'A', 'E', 'I', 'O', 'U' };
            Random random = new Random();
            for (int i = 0; i < 3; i++)
                autorisation += random.Next(0, 10);
            autorisation += vocali[random.Next(0, 5)];
            if (ExistsAu(autorisation))
                return GenerateAutorisation();
            AllAutorisation.Add(autorisation);
            return autorisation;
            
        }
        public static string CreaTarga()
        {
            string targa = "";
            char lettera;
            Random random = new Random();
            for (int i = 0; i < 2; i++)
            {
                lettera = (char)random.Next('A', 'Z' + 1);
                targa += lettera;
            }
            for (int i = 0; i < 3; i++)
                targa += random.Next(0, 10);
            for (int i = 0; i < 2; i++)
            {
                lettera = (char)random.Next('A', 'Z' + 1);
                targa += lettera;
            }
            if (ExistsTarga(targa))
                CreaTarga();
            AllTarga.Add(targa);
            return targa;
        }
        public static bool ExistsTarga(string element)
        {
            return AllTarga.Exists(x => x == element);
        }
        public static bool ExistsAu(string element)
        {
            return AllAutorisation.Exists(x => x == element);
        }
        public static int Find(List<Veicolo> parkList, int codice)
        {
            int index = parkList.FindIndex(p => p._codice == codice);
            return index;
        }
        public static int Find(List<Veicolo> parkList, string targa)
        {
            int index = parkList.FindIndex(p => p._targa == targa);
            return index;
        }

    }
}
