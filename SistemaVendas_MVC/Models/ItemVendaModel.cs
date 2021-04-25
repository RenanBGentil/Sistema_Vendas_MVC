using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas_MVC.Models
{
    public class ItemVendaModel
    {
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string QtdeProduto { get; set; }
        public string PrecoProduto { get; set; }
        public string TotalVenda { get; set; }
    }
}
