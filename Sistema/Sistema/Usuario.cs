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
    public class Usuario 
    {


        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }

        public Usuario(string email, string senha, string tipo)
        {
            Email = email;
            Senha = senha;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Email} ({Tipo})";
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }


    }
}
