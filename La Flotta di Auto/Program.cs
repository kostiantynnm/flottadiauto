using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Flotta_di_Auto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Flotta flotta = new Flotta();
            GeneralMenu(flotta);
            Console.ReadLine();
            
        }
        static void GeneralMenu(Flotta flotta)
        {
            
            while (true)
            {
                Console.SetCursorPosition(5,1);
                Console.Write($"Flotta \"{flotta._name}\"");
                Console.SetCursorPosition(Console.CursorLeft+5, 1);
                Console.Write($"Autorizzazione statale: {flotta._autorisation}");
                Console.WriteLine("\n\nMenu:");
                Console.WriteLine("[1] Aggiungere un nuovo veicolo alla flotta"); //
                Console.WriteLine("[2] Visializzare tutti"); //
                Console.WriteLine("[3] Visualizzare le informazioni di un veicolo"); //
                Console.WriteLine("[4] Eliminare un veicolo"); //
                Console.WriteLine("[5] Ricercare i veicoli dal numero di posti"); //
                Console.WriteLine("[6] Salvare sul file"); 
                Console.WriteLine("[7] Visualizzare per la marca");
                Console.WriteLine("[8] Change the name");
                Console.WriteLine("[9] Esci");

                Console.Write("\nScelta: ");
                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        flotta.Add();
                        Console.ReadLine();
                        break;

                    case "2":
                        flotta.Visualizza();
                        Console.ReadLine();
                        break;

                    case "3":
                        flotta.VisualizzaMenu();
                        Console.ReadLine();
                        break;

                    case "4":
                        flotta.Delete();
                        Console.ReadLine();
                        break;

                    case "5":
                        flotta.RicercaDiPosti();
                        Console.ReadLine();
                        break;

                    case "6":
                        flotta.ToFile();
                        Console.ReadLine();
                        break;

                    case "7":
                        break;

                    case "8":
                        Console.Write("Inserisci nome : "); flotta.SetName(Console.ReadLine());
                        break;

                    case "9":
                        Console.WriteLine("Uscita dal programma.");
                        return;
                }
                
                Console.Clear();
            }

        }
        
    }
}
