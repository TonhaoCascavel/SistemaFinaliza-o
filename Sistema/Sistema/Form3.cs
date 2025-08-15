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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.Load += Form3_Load;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            foreach (var usuario in Form1.listaUsuarios)
            {
                listBox1.Items.Add(usuario);
            }
            MessageBox.Show($"Total de usuários: {Form1.listaUsuarios.Count}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            var usuario = Form1.listaUsuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                Form2 form2 = new Form2(usuario);
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("E-mail ou senha incorretos.");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
