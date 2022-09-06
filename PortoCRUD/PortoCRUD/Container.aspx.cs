using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using System.Configuration;
using System.Drawing;
using PortoCRUD.Models;
using Microsoft.Ajax.Utilities;
using System.Text;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace PortoCRUD
{
    public partial class Container : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ConfigurationManager.AppSettings["isEdicao"] = "false";
                GridView1.DataBind();
            }

        }

        protected void GridView1_OnDataBinding(object sender, EventArgs e)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

            con.Open();

            var containers = con.Query<Models.Container>("Select * from Container");

            con.Close();

            GridView1.DataSource = containers;
        }

        //Salva os dados do campo de preenchimento no banco
        protected void button1_OnClick(object sender, EventArgs e)
        {

            Regex rx = new Regex(@"^[A-Z]{4}\d{7}$");

            if (String.IsNullOrWhiteSpace(TextBox1.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar o nome do cliente em branco.');", true);
                TextBox1.Focus();
                return;
            }
            else if (String.IsNullOrWhiteSpace(TextBox2.Text) || !rx.IsMatch(TextBox2.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Verifique o número do container.');", true);
                TextBox2.Focus();
                return;
            }
            else if (DropDownList1.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar o tipo do container em branco.');", true);
                DropDownList1.Focus();
                return;
            }
            else if (DropDownList2.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar o status do container em branco.');", true);
                DropDownList2.Focus();
                return;
            }
            else if (DropDownList3.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar a categoria do container em branco.');", true);
                DropDownList3.Focus();
                return;
            }
            else
            {

                //if salvando
                if (ConfigurationManager.AppSettings["isEdicao"].Equals("false"))
                {

                    Models.Container novoContainer = new Models.Container(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue);

                    var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

                    con.Open();

                    con.Execute("Insert into Container (nm_cliente, nm_container, ds_tipo, ds_status, ds_categoria) values (@nm_cliente, @nm_container, @ds_tipo, @ds_status, @ds_categoria)", novoContainer);

                    con.Close();

                    TextBox1.Text = ""; TextBox2.Text = ""; DropDownList1.SelectedValue = "0"; DropDownList2.SelectedValue = "0"; DropDownList3.SelectedValue = "0";

                    GridView1.DataBind();

                }

                if (ConfigurationManager.AppSettings["isEdicao"].Equals("true"))
                {
                    Models.Container novoContainer = new Models.Container(TextBox1.Text, TextBox2.Text, DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue);
                    novoContainer.cd_Container = long.Parse(TextBoxId.Text);

                    var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

                    con.Open();

                    con.Execute("Update Container set nm_cliente = @nm_cliente, nm_container = @nm_container, ds_tipo = @ds_tipo , ds_status = @ds_status, ds_categoria = @ds_categoria where cd_container = @cd_container", novoContainer);

                    con.Close();

                    GridView1.DataBind();

                    TextBox1.Text = ""; TextBox2.Text = ""; DropDownList1.SelectedValue = "0"; DropDownList2.SelectedValue = "0"; DropDownList3.SelectedValue = "0";

                    ConfigurationManager.AppSettings["isEdicao"] = "false";


                }
            }


        }


        //Limpa os campos de preenchimento
        protected void buttonLimpar_OnClick(object sender, EventArgs e)
        {
            TextBox1.Text = ""; TextBox2.Text = ""; DropDownList1.SelectedValue = "0"; DropDownList2.SelectedValue = "0"; DropDownList3.SelectedValue = "0";
            ConfigurationManager.AppSettings["isEdicao"] = "false";
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletar")
            {
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                long id = long.Parse(row.Cells[2].Text);

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

                con.Open();

                con.Execute("delete from Movimentacao where cd_Container = " + id.ToString());
                var containers = con.Execute("delete from container where cd_Container = " + id.ToString());

                con.Close();

                GridView1.DataBind();


            }
            else if (e.CommandName == "editar")
            {
                ConfigurationManager.AppSettings["isEdicao"] = "true";
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                long id = long.Parse(row.Cells[2].Text);
                string nomeCliente = HttpUtility.HtmlDecode(row.Cells[3].Text);
                string nomeContainer = (row.Cells[4].Text);
                string tipo = (row.Cells[5].Text);
                string status = (row.Cells[6].Text);
                string categoria = HttpUtility.HtmlDecode(row.Cells[7].Text);



                TextBox1.Text = nomeCliente; TextBox2.Text = nomeContainer; DropDownList1.SelectedValue = tipo; DropDownList2.SelectedValue = status; DropDownList3.SelectedValue = categoria; TextBoxId.Text = Convert.ToString(id);

            }
        }

    }
}