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

namespace Sistema
{
    public partial class Form5 : Form
    {
        private List<Produto> produtos;      
        private List<Compra> historicoCompras;    
        private string usuarioLogado;
        public Form5(List<Produto> listaProdutos, string nomeUsuario)
        {
            InitializeComponent();
            usuarioLogado = nomeUsuario;
            produtos = listaProdutos;
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
            {
                listView1.BeginUpdate();
                listView1.Items.Clear();
                imageList1.Images.Clear();

                // Define o modo de exibição para Tile
                listView1.View = View.Tile;
                listView1.TileSize = new Size(250, 70);
                listView1.LargeImageList = imageList1;

                // Adiciona as colunas
                listView1.Columns.Clear();
                listView1.Columns.Add("Nome", 100);
                listView1.Columns.Add("Preço", 70);
                listView1.Columns.Add("Estoque", 70);

                foreach (var prod in produtos)
                {
                    // Gera uma chave única para a imagem
                    string key = Guid.NewGuid().ToString();
                    imageList1.Images.Add(key, prod.Foto);

                    // Cria o item com a imagem associada
                    ListViewItem item = new ListViewItem(prod.Nome)
                    {
                        ImageKey = key
                    };
                    item.SubItems.Add(prod.Preco.ToString("C"));
                    item.SubItems.Add(prod.Quantidade.ToString());

                    listView1.Items.Add(item);
                }

                listView1.EndUpdate();
            }
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(historicoCompras, usuarioLogado);
            form6.Show();
            this.Hide();
        }
    }
}
