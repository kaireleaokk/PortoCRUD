using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortoCRUD.Models
{
    public class Container
    {
        public long cd_Container { get; set; }
        public string nm_cliente { get; set; }
        public string nm_container { get; set; }
        public string ds_tipo { get; set; }
        public string ds_status { get; set; }
        public string ds_categoria { get; set; }

        public Container() { }
   
        public Container(string nm_cliente, string nm_container, string ds_tipo, string ds_status, string ds_categoria)
        {
            this.nm_cliente = nm_cliente;
            this.nm_container = nm_container;
            this.ds_tipo = ds_tipo;
            this.ds_status = ds_status;
            this.ds_categoria = ds_categoria;
        }
    }

}