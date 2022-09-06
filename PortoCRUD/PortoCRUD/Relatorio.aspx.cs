using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortoCRUD
{
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                GridView1.DataBind();
                GridView2.DataBind();

            }
        }

        protected void GridView1_OnDataBinding(object sender, EventArgs e)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

            con.Open();

            var relatorios = con.Query<Models.Relatorio>("Select C.nm_cliente,M.ds_tipo, Count(C.ds_tipo) as ds_qtdMovimentacao from Container C Inner Join Movimentacao M on M.cd_container = C.cd_container Group By C.nm_cliente, M.ds_tipo Order By 1,2");
            con.Close();

            GridView1.DataSource = relatorios;

        }

        protected void GridView2_OnDataBinding(object sender, EventArgs e)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

            con.Open();

            var relatorio = con.Query<Models.Relatorio>("Select C.ds_categoria, Count(C.ds_categoria) as ds_categoriaTotal From Container C GROUP BY C.ds_categoria");

            con.Close();

            GridView2.DataSource = relatorio;
        }
    }
}