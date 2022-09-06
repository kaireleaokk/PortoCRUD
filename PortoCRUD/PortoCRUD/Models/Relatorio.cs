using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortoCRUD.Models
{
    public class Relatorio
    {
        public long cd_Container { get; set; }
        public long cd_Movimentacao { get; set; }
        public string nm_cliente { get; set; }
        public string ds_tipo { get; set; }
        public string ds_qtdMovimentacao { get; set; }
        public string ds_categoria { get; set; }
        public string ds_categoriaTotal { get; set; }

    }
}