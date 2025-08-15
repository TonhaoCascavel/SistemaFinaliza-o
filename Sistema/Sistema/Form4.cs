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
    public partial class Form4 : Form
    {
        private Usuario UsuarioLogado;
        public Form4(Usuario usuario)
        {
            InitializeComponent();
            UsuarioLogado = usuario;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            AtualizarListBox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            decimal preco;

            if (string.IsNullOrWhiteSpace(nome) || !decimal.TryParse(textBox2.Text, out preco))
            {
                MessageBox.Show("Preencha corretamente o nome e o preço do produto.");
                return;
            }

            Produto produto = new Produto(nome, preco);
            Form2.listaProdutos.Add(produto); // Usando a lista pública do Form2

            AtualizarListBox();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void AtualizarListBox()
        {
            listBox1.Items.Clear();
            foreach (var produto in Form2.listaProdutos)
            {
                listBox1.Items.Add(produto);
            }
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

        }
    }
}
