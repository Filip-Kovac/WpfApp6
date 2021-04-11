using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6
{
    class Zaměstnanec : Osoba
    {
        public static List<Zaměstnanec> AllEmployers = new List<Zaměstnanec>();
        public string Education{ get; set; }
        public string Job{ get; set; }
        public int Salary { get; set; }

        public int BirthDate { get; set; }
    }
}
