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

        public Usuario(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public override string ToString()
        {
            return Email;
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }


    }
}
