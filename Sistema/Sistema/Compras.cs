using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema
{
    public class Compra
    {
        public string NomeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int QuantidadeComprada { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal Total => PrecoUnitario * QuantidadeComprada;
        public Usuario UsuarioComprador { get; set; }
    }
}
