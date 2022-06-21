using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Discos
{
    public class ModelCD : Interface1
    {
        //ESTRUTURA DE DADOS
        public Dictionary<string, CD> Dados { get; set; }

        //EVENTOS
        public event MetodosSemParametros DiscoComprado;
        public event MetodosSemParametros LeituraTerminada;

        //CONSTRUTOR

        public ModelCD()
        {
            Dados = new Dictionary<string, CD>();
        }


        public void ComprarDisco(string id)
        {
            CD di;

            Dados.TryGetValue(id, out di);
            if (di != null)
                di.Comprado = !di.Comprado;

            if (DiscoComprado != null)
                DiscoComprado();
        }


        //METODOS




        public void EscritaXML(string ficheiro)
        {
            XDocument doc = new XDocument(new XDeclaration("1,0", Encoding.UTF8.ToString(), "yes"),
                            new XComment("<!--Listagem dos Albuns-->"),
                            new XElement("Albuns"),
                            new XElement("Comprado"),
                            new XElement("NãoComprado"));

            foreach (CD ya in Dados.Values)
            {
                XElement novo = new XElement("Album", new XAttribute("ID", ya.ID),
                                                      new XElement("Titulo", ya.Titulo),
                                                      new XElement("Autor", ya.Autor),
                                                      new XElement("Ano", ya.Ano),
                                                      new XElement("Preco", ya.Preco));

                if (ya.Comprado == true)
                    doc.Element("Albuns").Element("Comprado").Add(novo);
                else
                    doc.Element("Albuns").Element("NaoComprado").Add(novo);

            }

            doc.Save(ficheiro);
        }





        public void LeituraXML(string ficheiro)
        {
            Dados.Clear();

            XDocument doc = XDocument.Load(ficheiro);

            var Registo = from al in doc.Element("Albuns").Element("Comprado").Descendants("Album")
                          select al;

            foreach (var campo in Registo)
            {
                CD novoCd = new CD(campo.Attribute("Id").Value,
                            campo.Element("Titulo").Value,
                            campo.Element("Autor").Value,
                            campo.Element("Ano").Value,
                            campo.Element("Preco").Value);

                novoCd.Comprado = true;

                Dados.Add(novoCd.ID, novoCd);

            }

             Registo = from al in doc.Element("Albuns").Element("NaoComprado").Descendants("Album")
                          select al;

            foreach (var campo in Registo)
            {
                CD novoCd = new CD(campo.Attribute("Id").Value,
                            campo.Element("Titulo").Value,
                            campo.Element("Autor").Value,
                            campo.Element("Ano").Value,
                            campo.Element("Preco").Value);

                novoCd.Comprado = false;

                Dados.Add(novoCd.ID, novoCd);


            }
            if (LeituraTerminada != null)
                LeituraTerminada();


        }
            


        }
    }

