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
            // Remove a borda padrão
            this.FormBorderStyle = FormBorderStyle.None;

            // Criar barra personalizada
            Panel barra = new Panel();
            barra.BackColor = Color.FromArgb(45, 45, 48); // Cor escura
            barra.Dock = DockStyle.Top;
            barra.Height = 35;
            barra.MouseDown += Barra_MouseDown; // Permitir arrastar a janela
            this.Controls.Add(barra);

            // Botão fechar
            Button btnFechar = new Button();
            btnFechar.Text = "X";
            btnFechar.ForeColor = Color.White;
            btnFechar.BackColor = Color.FromArgb(25, 25, 28);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Size = new Size(45, 35);
            btnFechar.Location = new Point(this.Width - 45, 0);
            btnFechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFechar.Click += (s, e) => this.Close();
            barra.Controls.Add(btnFechar);

            // Botão maximizar/restaurar
            Button btnMax = new Button();
            btnMax.Text = "⬜";
            btnMax.ForeColor = Color.White;
            btnMax.BackColor = Color.FromArgb(25, 25, 28);
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.Size = new Size(45, 35);
            btnMax.Location = new Point(this.Width - 90, 0);
            btnMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == FormWindowState.Normal)
                    this.WindowState = FormWindowState.Maximized;
                else
                    this.WindowState = FormWindowState.Normal;
            };
            barra.Controls.Add(btnMax);

            // Botão minimizar
            Button btnMin = new Button();
            btnMin.Text = "_";
            btnMin.ForeColor = Color.White;
            btnMin.BackColor = Color.FromArgb(25, 25, 28);
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.Size = new Size(45, 35);
            btnMin.Location = new Point(this.Width - 135, 0);
            btnMin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMin.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            barra.Controls.Add(btnMin);
        }

        // Permitir arrastar a janela segurando o painel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void Barra_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    
}

