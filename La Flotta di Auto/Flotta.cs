using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace La_Flotta_di_Auto
{
    internal class Flotta
    {
        public string _name { get; private set; }
        public string _autorisation { get; }
        List<Veicolo> parkList = new List<Veicolo>();
        public Flotta()
        {
            _name = "Default Name";
            _autorisation = Methods.GenerateAutorisation();
        }
        public void Add()
        {
            string marca, modello;
            NumeroPosti posti = NumeroPosti.Two;
            bool IsValid = false;

            Console.Write("Inserisci la marca : ");
            marca = Console.ReadLine();
            Console.Write("Inserisci il modello : ");
            modello = Console.ReadLine();
            while (!IsValid)
            {
                Console.Write("Inserisci il numero di posti (2 / 4 / 5 / 8) : ");
                if (Enum.TryParse<NumeroPosti>(Console.ReadLine(), true, out posti) && Enum.IsDefined(typeof(NumeroPosti), posti)) { IsValid = true; }
                else Console.WriteLine("Inserted invalid data");
            }
            try
            {
                parkList.Add(new Veicolo(marca, InsertTarga(), modello, posti));
                Console.WriteLine("New vehicle is succesfully added");
            }
            catch
            {
                Console.WriteLine("Inserted invalid data");
            }
        }
        public void SetName(string name)
        {
            _name = name;
        }
        string InsertTarga()
        {
            string targa = "";
            int choice = Menu.ChooseTarga();
            if (choice == 1)
            {
                Console.WriteLine("Insert targa (example : AA000AA)");
                targa = Console.ReadLine();
                if (Methods.ExistsTarga(targa))
                {
                    Console.WriteLine("Targa already exists!");
                    InsertTarga();
                }
                else
                {
                    Methods.AllTarga.Add(targa);
                    return targa;
                }
            }
            else if (choice == 2)
            {
                targa = Methods.CreaTarga();
                Console.WriteLine(targa);
                return targa;
            }
            else
            {
                Console.Clear();
                InsertTarga();
            }
            return null;
        }
        public void VisualizzaMenu()
        {
            int choice = Menu.CodiceOTarga();
            if (choice == 1)  //codice
            {
                Console.WriteLine("Insert codice: ");
                int index = Methods.Find(parkList, int.Parse(Console.ReadLine()));
                if (index == -1) { Console.WriteLine("Vehicle was not found"); VisualizzaMenu(); }
                else Console.WriteLine(parkList[index].ToString());
            }
            else if (choice == 2) //targa
            {
                Console.WriteLine("Insert targa: ");
                int index = Methods.Find(parkList, Console.ReadLine());
                if (index == -1) { Console.WriteLine("Vehicle was not found"); VisualizzaMenu(); }
                else Console.WriteLine(parkList[index].ToString());
            }
            else if (choice == 3) return;
            else
            {
                Console.Clear();
                VisualizzaMenu();
            }
        }
        public void Visualizza()
        {
            foreach(Veicolo i in parkList)
            {
                Console.WriteLine(i.ToString()+"\n");
            }
        }
        public void Delete()
        {
            int choice = Menu.CodiceOTarga();
            if (choice == 1)  //codice
            {
                Console.WriteLine("Insert codice: ");
                int index = Methods.Find(parkList, int.Parse(Console.ReadLine()));
                if (index == -1) { Console.WriteLine("Vehicle was not found"); VisualizzaMenu(); }
                else { parkList.RemoveAt(index); Console.WriteLine("Vehicle is deleted ");}
            }
            else if (choice == 2) //targa
            {
                Console.WriteLine("Insert targa: ");
                int index = Methods.Find(parkList, Console.ReadLine());
                if (index == -1) { Console.WriteLine("Vehicle was not found"); VisualizzaMenu(); }
                else { parkList.RemoveAt(index); Console.WriteLine("Vehicle is deleted "); }
            }
            else if (choice == 3) return;
            else
            {
                Console.Clear();
                Delete();
            }
        }

        public void RicercaDiPosti()
        {
            if (Enum.TryParse<NumeroPosti>(Console.ReadLine(), true, out var posti) && Enum.IsDefined(typeof(NumeroPosti), posti));
            Visualizza(posti);
        }

        void Visualizza(NumeroPosti n)
        {
            foreach (var p in parkList)
            {
                if(p._posti == n) Console.WriteLine(p.ToString());
            }
        }
        public void ToFile()
        {
            StreamWriter writer = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            foreach (var p in parkList)
            { 
                writer.WriteLine(p.ToString()+"\n"); 
            }
            writer.Close();
            Console.WriteLine("Data is succesfully saved in file");
        }
    }
}
