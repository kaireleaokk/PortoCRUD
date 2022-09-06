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
using System.Text.RegularExpressions;
using System.Collections;

namespace PortoCRUD
{
    public partial class Movimentacao : System.Web.UI.Page
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

            var movimentacoes = con.Query<Models.Movimentacao>("Select Container.nm_container, Movimentacao.cd_movimentacao, Movimentacao.ds_tipo, Movimentacao.dt_inicio, Movimentacao.dt_fim from Movimentacao INNER JOIN Container ON Movimentacao.cd_Container = Container.cd_Container ");

            con.Close();

            GridView1.DataSource = movimentacoes;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "deletar")
            {
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                long id = long.Parse(row.Cells[3].Text);

                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

                con.Open();

                con.Execute("delete from Movimentacao where cd_movimentacao = " + id.ToString());

                con.Close();

                GridView1.DataBind();

            }

            else if (e.CommandName == "editar")
            {
                ConfigurationManager.AppSettings["isEdicao"] = "true";
                GridViewRow row = (GridViewRow)((Button)e.CommandSource).NamingContainer;
                string nomeContainer = (row.Cells[2].Text);
                long id = long.Parse(row.Cells[3].Text);
                string tipo = (row.Cells[4].Text);
                DateTime dataIni = DateTime.Parse(row.Cells[5].Text);
                string dataInii = dataIni.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');
                DateTime dataFim = DateTime.Parse(row.Cells[6].Text);
                string dataFimm = dataFim.ToString("yyyy-MM-dd HH:mm:ss").Replace(' ', 'T');


                TextBox1.Text = nomeContainer; DropDownList1.SelectedValue = tipo; TextBox3.Text = dataInii; TextBox4.Text = dataFimm; TextBoxId.Text = id.ToString();

            }

        }

        private long getIdContainerByCNTR(string nm_container)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);
            con.Open();
            long idContainer = con.ExecuteScalar<long>("Select cd_Container From Container Where nm_container = '" + nm_container + "'");
            con.Close();
            return idContainer;

        }

        protected void button1_OnClick(object sender, EventArgs e)
        {

            Regex rx = new Regex(@"^[A-Z]{4}\d{7}$");

            if (String.IsNullOrWhiteSpace(TextBox1.Text) || !rx.IsMatch(TextBox1.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Verifique o número do container.');", true);
                TextBox1.Focus();
                return;
            }
            else if (DropDownList1.SelectedValue.Equals("0"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar o tipo do movimentação em branco.');", true);
                DropDownList1.Focus();
                return;
            }
            else if (String.IsNullOrWhiteSpace(TextBox3.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar a data de início em branco.');", true);
                TextBox3.Focus();
                return;
            }
            else if (String.IsNullOrWhiteSpace(TextBox4.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Opa! Você não pode deixar a data final em branco.');", true);
                TextBox4.Focus();
                return;
            }

            else
            {
                //if salvando
                if (ConfigurationManager.AppSettings["isEdicao"].Equals("false"))
                {

                    Models.Movimentacao novaMovimentacao = new Models.Movimentacao(TextBox1.Text, DropDownList1.SelectedValue, DateTime.Parse(TextBox3.Text), DateTime.Parse(TextBox4.Text));
                    long containerId = getIdContainerByCNTR(TextBox1.Text);
                    novaMovimentacao.cd_Container = containerId;

                    var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);

                    con.Open();

                    con.Execute("Insert into Movimentacao (cd_Container, ds_tipo, dt_inicio, dt_fim) values (@cd_Container, @ds_tipo, @dt_inicio, @dt_fim)", novaMovimentacao);

                    con.Close();

                    TextBox1.Text = ""; DropDownList1.SelectedValue = "0"; TextBox3.Text = ""; TextBox4.Text = "";

                    GridView1.DataBind();

                }
            }



            if (ConfigurationManager.AppSettings["isEdicao"].Equals("true"))
            {
                Models.Movimentacao novaMovimentacao = new Models.Movimentacao(TextBox1.Text, DropDownList1.SelectedValue, DateTime.Parse(TextBox3.Text), DateTime.Parse(TextBox4.Text));
                novaMovimentacao.cd_movimentacao = long.Parse(TextBoxId.Text);
                long containerId = getIdContainerByCNTR(TextBox1.Text);
                novaMovimentacao.cd_Container = containerId;
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Porto"].ConnectionString);


                con.Open();

                con.Execute("Update Movimentacao set cd_Container = @cd_Container, ds_tipo = @ds_tipo , dt_inicio = @dt_inicio, dt_fim = @dt_fim where cd_movimentacao = @cd_movimentacao", novaMovimentacao);

                con.Close();

                GridView1.DataBind();

                TextBox1.Text = ""; DropDownList1.SelectedValue = "0"; TextBox3.Text = ""; TextBox4.Text = ""; TextBoxId.Text = "";

                ConfigurationManager.AppSettings["isEdicao"] = "false";


            }
        }
        protected void buttonLimpar_OnClick(object sender, EventArgs e)
        {
            TextBox1.Text = ""; DropDownList1.SelectedValue = "0"; TextBox3.Text = ""; TextBox4.Text = "";
            ConfigurationManager.AppSettings["isEdicao"] = "false";
        }
    }
}