using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sistema
{
    public partial class Form4 : Form
    {

        private List<Produto> produtos = new List<Produto>();
        private Image imagemProdutoSelecionada = null;
        private Usuario UsuarioLogado;
        public Form4(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogado = usuario;

            listView1.Columns.Add("Nome", 100);
            listView1.Columns.Add("Preço", 70);
            listView1.Columns.Add("Quantidade", 80);

            imageList1.ImageSize = new Size(64, 64); 
            listView1.LargeImageList = imageList1;

            listView1.View = View.Tile;
            listView1.TileSize = new Size(300, 70); 
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificações de preenchimento
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                imagemProdutoSelecionada == null)
            {
                MessageBox.Show("Preencha todos os campos e selecione uma imagem!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Conversões seguras
            if (!decimal.TryParse(textBox2.Text, out decimal preco))
            {
                MessageBox.Show("Preço inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBox3.Text, out int quantidade))
            {
                MessageBox.Show("Quantidade inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Criação do produto
            Produto novoProduto = new Produto(textBox1.Text, preco, quantidade);
            novoProduto.Foto = imagemProdutoSelecionada;


            produtos.Add(novoProduto);
            AdicionarProdutoNaListView(novoProduto);

            // Limpar campos
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            imagemProdutoSelecionada = null;

            MessageBox.Show("Produto registrado com sucesso!");
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(UsuarioLogado);
            form2.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagens|*.jpg;*.png;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagemProdutoSelecionada = Image.FromFile(ofd.FileName);
                    pictureBox2.Image = imagemProdutoSelecionada; // ← Mostra imagem
                    pictureBox2.SizeMode = PictureBoxSizeMode.Zoom; // ← Ajusta tamanho
                }
            }
        }

        private void AdicionarProdutoNaListView(Produto produto)
        {
            // Gera uma chave única para a imagem
            string key = Guid.NewGuid().ToString();

            // Adiciona a imagem ao imageList1
            imageList1.Images.Add(key, produto.Foto);

            // Cria o item com a imagem associada
            ListViewItem item = new ListViewItem(produto.Nome);
            item.ImageKey = key;

            // Opcional: incluir mais info no texto se estiver usando View = Tile
            item.SubItems.Add($"Preço: {produto.Preco:C}");
            item.SubItems.Add($"Qtd: {produto.Quantidade}");

            listView1.Items.Add(item);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
