using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class Form5 : Form
    {
        private List<Produto> produtos;      
        private List<Compra> historicoCompras;
        private Usuario usuarioLogado;
        private List<Produto> listaProdutos;
        public Form5(List<Produto> listaProdutos, string usuarioNome, Usuario usuarioLogado)
        {
            InitializeComponent();
            produtos = listaProdutos;
            this.usuarioLogado = usuarioLogado;  
            historicoCompras = new List<Compra>();

            imageList1.ImageSize = new Size(64, 64);
            listView1.LargeImageList = imageList1;
            listView1.View = View.Details;
            listView1.TileSize = new Size(250, 70);
            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("Preço", 70);
            listView1.Columns.Add("Estoque", 70);

            CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            imageList1.Images.Clear();

            foreach (var prod in produtos)
            {
                // Gera uma chave única para a imagem
                string key = Guid.NewGuid().ToString();
                imageList1.Images.Add(key, prod.Foto); // Adiciona a imagem ao ImageList

                // Cria o item com a imagem associada
                ListViewItem item = new ListViewItem(prod.Nome)
                {
                    ImageKey = key // Associa a imagem ao item
                };
                item.SubItems.Add(prod.Preco.ToString("C"));
                item.SubItems.Add(prod.Quantidade.ToString());

                listView1.Items.Add(item);  // Adiciona o item na ListView
            }

            listView1.EndUpdate();
        }

            private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um produto!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selecionado = produtos[listView1.SelectedItems[0].Index];
            int qtdDesejada = (int)numericUpDown1.Value;

            if (qtdDesejada <= 0)
            {
                MessageBox.Show("Selecione uma quantidade válida!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (qtdDesejada > selecionado.Quantidade)
            {
                MessageBox.Show("Estoque insuficiente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Registra a compra
            var compra = new Compra
            {
                NomeProduto = selecionado.Nome,
                PrecoUnitario = selecionado.Preco,
                QuantidadeComprada = qtdDesejada,
                DataCompra = DateTime.Now,
                UsuarioComprador = usuarioLogado
        };
            historicoCompras.Add(compra);

            // Atualiza estoque
            selecionado.Quantidade -= qtdDesejada;
            CarregarProdutos();

            MessageBox.Show("Compra realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(usuarioLogado, listaProdutos);
            form2.Show();
            this.Hide(); ;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(historicoCompras, usuarioLogado, produtos);
            form6.Show();
            this.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
