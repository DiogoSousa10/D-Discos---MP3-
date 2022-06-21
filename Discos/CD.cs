using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discos
{
    public class CD
    {

        public string ID { get; private set; }
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string Ano { get; private set; }
        public string Preco { get; private set; }
        public Boolean Comprado { get; set; }


        public CD(string id, string titulo,string autor, string ano, string preco)
        {
            ID = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Preco = preco;
            Comprado = false;
        }
        public CD()
        {
            this.ID = ID;
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.Ano = Ano;
            this.Preco = Preco;

        }



    }
}
