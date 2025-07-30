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
    public partial class Form1 : Form
    {
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (var usuario in listaUsuarios)
            {
                listBox1.Items.Add(usuario); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
            {
                if (radioButton1.Checked) // Funcionário
                {
                    if (email.EndsWith("@ecopolis.com.pr"))
                    {
                        Usuario usuario = new Usuario(email, senha, "Funcionário");
                        listaUsuarios.Add(usuario);
                        listBox1.Items.Add(usuario);

                        Form2 form2 = new Form2(usuario);
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Para Funcionário, o e-mail deve ser do domínio @ecopolis.com.pr.");
                    }
                }
                else if (radioButton2.Checked) // Cliente
                {
                    if (email.EndsWith("@gmail.com"))
                    {
                        Usuario usuario = new Usuario(email, senha, "Cliente");
                        listaUsuarios.Add(usuario);
                        listBox1.Items.Add(usuario);

                        Form2 form2 = new Form2(usuario);
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Para Cliente, o e-mail deve ser do domínio @gmail.com.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o tipo de usuário: Funcionário ou Cliente.");
                }
            }
            else
            {
                MessageBox.Show("Preencha e-mail e senha.");
            }
        }



        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
    
}

