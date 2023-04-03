using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Ucenik
    {
        public string jmbg { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", jmbg, ime, prezime);
        }
    }
}
