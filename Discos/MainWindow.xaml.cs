using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Discos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private App app;


        public MainWindow()
        {
            InitializeComponent();

            app = App.Current as App;

            app.M_CD.DiscoComprado += M_CD_LeituradaTerminada;
            app.M_CD.LeituraTerminada += M_CD_LeituradaTerminada;
           
        }

        private void M_CD_LeituradaTerminada()
        {
            TreeViewItem Comprados = new TreeViewItem();
            Comprados.Header = "Comprados";

            TreeViewItem naoComprados = new TreeViewItem();
            naoComprados.Header = "Não Comprados";

            foreach (CD al in app.M_CD.Dados.Values)
            {
                if (al.Comprado == true)
                {
                    Comprados.Items.Add(al.ID + "-" + al.Titulo + "-" + al.Autor + "-" + al.Ano + "-" + al.Preco);
                }

                else
                {
                    naoComprados.Items.Add(al.ID + "-" + al.Titulo + "-" + al.Autor + "-" + al.Ano + "-" + al.Preco);
                }
            }

            tvDiscos.Items.Clear();
            tvDiscos.Items.Add(Comprados);
            tvDiscos.Items.Add(naoComprados);
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GuardarXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*-*";
            if (dlg.ShowDialog() == true)
                //invocao de metodos do model
                app.M_CD.EscritaXML(dlg.FileName);
        }

        private void AbrirXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Ficheiros XML|*.xml|Todos os ficheiros|*-*";

            if (dlg.ShowDialog() == true)
                //invocaco de metodos do model
                app.M_CD.LeituraXML(dlg.FileName);
        }
    }
}
