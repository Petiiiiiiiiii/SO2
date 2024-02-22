using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA240222
{
    internal class Nap
    {
        public Dictionary<int,int> OrakEsDB { get; set; }

        public Nap(string sor)
        {
            var atmeneti = sor.Split(';');
            this.OrakEsDB = new();
            for (int i = 0; i < atmeneti.Length; i++)
                this.OrakEsDB.Add(i + 1, Convert.ToInt32(atmeneti[i]));
        }
        public override string ToString()
        {
            return $"{string.Join(" ",this.OrakEsDB.Values)}";
        }
    }
}
