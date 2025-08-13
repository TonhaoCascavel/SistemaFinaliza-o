using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Sistema
{
    public class Usuario 
    {


        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string NomeCompleto { get; set; }
        public Image Foto { get; set; } 


        public Usuario(string email, string senha, string tipo, string nomeCompleto, Image foto)
        {
            Email = email;
            Senha = senha;
            Tipo = tipo;
            NomeCompleto = nomeCompleto;
            Foto = foto;
        }

        public string PrimeiroNome()
        {
            if (string.IsNullOrWhiteSpace(NomeCompleto)) return "";
            return NomeCompleto.Trim().Split(' ')[0];
        }

        public override string ToString()
        {
            return $"{PrimeiroNome()} - {Tipo}";
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }


    }
}
