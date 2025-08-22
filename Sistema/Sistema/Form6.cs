using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Form6 : Form
    {
        private List<Compra> compras;
        private string usuario;
        public Form6(List<Compra> historicoCompras, string usuarioLogado)
        {
            InitializeComponent();
            compras = historicoCompras;
            usuario = usuarioLogado;
        }
        public void CarregarDados(List<Compra> historicoCompras, string usuarioLogado)
        {
            compras = historicoCompras;
            usuario = usuarioLogado;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
