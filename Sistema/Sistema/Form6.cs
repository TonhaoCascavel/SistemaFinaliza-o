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
        private Usuario usuarioLogado;
        private List<Produto> produtos;
        public Form6(List<Compra> historicoCompras, Usuario usuarioLogado, List<Produto> produtos)
        {
            InitializeComponent();
            this.compras = historicoCompras;
            this.usuarioLogado = usuarioLogado;
            this.produtos = produtos;


            listView1.View = View.Details;
            listView1.Columns.Add("Produto", 150);
            listView1.Columns.Add("Quantidade", 80);
            listView1.Columns.Add("Preço", 80);
            listView1.Columns.Add("Data", 150);

            CarregarHistorico();
        }

        private void CarregarHistorico()
        {
            // Limpar o ListView antes de carregar os novos dados
            listView1.Items.Clear();

            foreach (var compra in compras)
            {

                var item = new ListViewItem(compra.NomeProduto);  // Nome do produto
                item.SubItems.Add(compra.QuantidadeComprada.ToString());  // Quantidade comprada
                item.SubItems.Add(compra.PrecoUnitario.ToString("C"));  // Preço unitário formatado
                item.SubItems.Add(compra.DataCompra.ToString("dd/MM/yyyy HH:mm"));  // Data da compra

                listView1.Items.Add(item);
            }
        }
        public void CarregarDados(List<Compra> historicoCompras, string usuarioLogado)
        {
            compras = historicoCompras;
            usuario = usuarioLogado;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(usuarioLogado, produtos);
            form2.Show();
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
