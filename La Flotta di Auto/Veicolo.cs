using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_Flotta_di_Auto
{
    internal class Veicolo
    {
        string _marca;
        string _modello;
        static int codiceCount = 0;
        public string _targa { get; private set; }
        public NumeroPosti _posti { get; private set; }
        public int _codice { get; }
        public override string ToString()
        {
            return $"Marca : {_marca} \n" +
                $"Targa : {_targa} \n" +
                $"Modello : {_modello} \n" +
                $"Numero di posti : {_posti} \n" +
                $"Codice : {_codice}";
        }

        public Veicolo(string marca, string targa, string modello, NumeroPosti posti)
        {
            codiceCount++;
            _marca = marca;
            _targa = targa;
            _modello = modello;
            _posti = posti;
            _codice = codiceCount;
        }
    }
}
