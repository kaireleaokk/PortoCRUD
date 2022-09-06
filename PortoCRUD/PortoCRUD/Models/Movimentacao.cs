using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortoCRUD.Models
{
    public class Movimentacao
    {
        public long cd_movimentacao { get; set; }
        public long cd_Container { get; set; }
        public string nm_container { get; set; }
        public string ds_tipo { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }

        public Movimentacao() { }

        public Movimentacao(string nm_container, string ds_tipo, DateTime dt_inicio, DateTime dt_fim)
        {

            this.nm_container = nm_container;
            this.ds_tipo = ds_tipo;
            this.dt_inicio = dt_inicio;
            this.dt_fim = dt_fim;
        }
    }


}