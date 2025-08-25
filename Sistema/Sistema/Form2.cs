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
    public partial class Form2 : Form
    {
        public static List<Produto> listaProdutos = new List<Produto>();
        private List<Produto> produtos;
        private List<Compra> historicoCompras;

        private Usuario usuarioLogado;
        public Form2(Usuario usuario, List<Produto> listaProdutos)
        {
            InitializeComponent();
            usuarioLogado = usuario;
            produtos = listaProdutos;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string primeiroNome = usuarioLogado.PrimeiroNome();

            if (usuarioLogado.Tipo == "Funcionário")
            {
                label1.Text = $"Bem-vindo {primeiroNome} (Colaborador)!";
                button2.Visible = true;
            }
            else // Cliente
            {
                label1.Text = $"Bem-vindo {primeiroNome} (Cliente)!";
                button2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = Application.OpenForms.OfType<Form1>().FirstOrDefault();
            if (form1 != null)
            {
                form1.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(usuarioLogado);
            form4.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            List<Produto> produtosDisponiveis = listaProdutos;
            string nomeUsuario = usuarioLogado.PrimeiroNome();

            Form5 form5 = new Form5(produtos, usuarioLogado.PrimeiroNome(), usuarioLogado);
            form5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(historicoCompras, usuarioLogado, produtos);
            form6.Show();
            this.Hide();
        }
    }
}
