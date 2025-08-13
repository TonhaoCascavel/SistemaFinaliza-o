using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            listView1.Items.Clear();
            imageList1.Images.Clear();

            foreach (var usuario in listaUsuarios)
            {
                string key = Guid.NewGuid().ToString();
                imageList1.Images.Add(key, usuario.Foto);
                ListViewItem lvi = new ListViewItem($"{usuario.PrimeiroNome()} - {usuario.Tipo}");
                lvi.ImageKey = key;
                lvi.Tag = usuario;
                listView1.Items.Add(lvi);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string senha = textBox2.Text;
            string nomeCompleto = textBox3.Text.Trim(); // nova textbox para nome

            // validações básicas: email/senha/nome/foto
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Preencha e-mail e senha.");
                return;
            }

            if (string.IsNullOrWhiteSpace(nomeCompleto))
            {
                MessageBox.Show("Informe o nome completo.");
                return;
            }

            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Selecione uma foto de perfil.");
                return;
            }

            // continua com sua lógica de domínio de e-mail...
            if (radioButton1.Checked) // Funcionário
            {
                if (!email.EndsWith("@ecopolis.com.pr"))
                {
                    MessageBox.Show("Para Funcionário, o e-mail deve ser do domínio @ecopolis.com.pr.");
                    return;
                }
            }
            else if (radioButton2.Checked) // Cliente
            {
                if (!email.EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Para Cliente, o e-mail deve ser do domínio @gmail.com.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Selecione o tipo de usuário: Funcionário ou Cliente.");
                return;
            }

            string classe = radioButton1.Checked ? "Funcionário" : "Cliente";

            // clona a imagem do PictureBox para guardar no objeto
            Image fotoClone = new Bitmap(pictureBox2.Image);

            Usuario usuario = new Usuario(email, senha, classe, nomeCompleto, fotoClone);
            listaUsuarios.Add(usuario);



            // ----- (Opcional/recomendado) se usar ListView com imagem, use o código na seção 4 -----

            // abrir Form2
            Form2 form2 = new Form2(usuario);
            form2.Show();
            this.Hide();
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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

       private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
                    }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Imagens|*.png;*.jpg;*.jpeg;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Ler a imagem com FileStream para não deixar o arquivo bloqueado
                    using (var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                    {
                        Image img = Image.FromStream(fs);
                        // Clonar para evitar travar o arquivo original
                        pictureBox2.Image = new Bitmap(img);
                        pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}

