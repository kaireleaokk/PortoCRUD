<%@ Page Title="Relatório" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="PortoCRUD.Relatorio" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Relatório de Movimentações</h1>


    <asp:GridView ID="GridView1" runat="server" Width="100%" OnDataBinding="GridView1_OnDataBinding" AutoGenerateColumns="false">
        <Columns>

            <asp:BoundField DataField="nm_cliente" HeaderText="Nome do Cliente" />
            <asp:BoundField DataField="ds_tipo" HeaderText="Tipo de Movimentação" />
            <asp:BoundField DataField="ds_qtdMovimentacao" HeaderText="Total de Movimentações" />
        </Columns>
    </asp:GridView>


    <asp:GridView ID="GridView2" runat="server" Width="100%" OnDataBinding="GridView2_OnDataBinding" AutoGenerateColumns="False">
        <Columns>

            <asp:BoundField DataField="ds_categoria" HeaderText="Categoria do Container" />
            <asp:BoundField DataField="ds_categoriaTotal" HeaderText="Total de Categorias" />

        </Columns>
    </asp:GridView>

</asp:Content>
