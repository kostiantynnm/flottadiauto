using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Flotta_di_Auto
{
    internal static class Menu
    {
        public static int ChooseTarga()
        {
            Console.WriteLine("[1] Insert Targa\n" +
                "[2] Generate Targa automaticamente");
            return int.Parse(Console.ReadLine()) ;
        }
        public static int CodiceOTarga()
        {
            Console.WriteLine("[1] Con il codice \n" +
                "[2] Con la targa\n" +
                "[3] Exit");
            return int.Parse(Console.ReadLine());
        }
    }
}
