using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discos
{
    public interface Interface1
    {
        event MetodosSemParametros DiscoComprado;

        void LeituraXML(string ficheiro);

        void EscritaXML(string ficheiro);

        void ComprarDisco(string id);
    }
}
