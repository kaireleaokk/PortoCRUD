<%@ Page Title="Movimentação" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Movimentacao.aspx.cs" Inherits="PortoCRUD.Movimentacao" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <h1 style="text-align: center; margin-bottom: 25px">Cadastro de Movimentações</h1>




    <section class="container flex" style="display: flex; flex-wrap: wrap">
        <br />

        <div class="item flex-item-1" style="flex: 1;">
            <label>Número do Container</label>
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="200px" MaxLength="11"></asp:TextBox>

        </div>
        <div class="item flex-item-1" style="flex: 1;">

            <label>Tipo de Movimentação</label>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Height="25px">
                <asp:ListItem Selected="True" Value="0"> ... </asp:ListItem>
                <asp:ListItem Value="embarque"> embarque </asp:ListItem>
                <asp:ListItem Value="descarga"> descarga </asp:ListItem>
                <asp:ListItem Value="gate in"> gate in </asp:ListItem>
                <asp:ListItem Value="gate out"> gate out </asp:ListItem>
                <asp:ListItem Value="reposicionamento"> reposicionamento </asp:ListItem>
                <asp:ListItem Value="pesagem"> pesagem </asp:ListItem>
                <asp:ListItem Value="scanner"> scanner </asp:ListItem>
            </asp:DropDownList>
        </div>
    </section>
    <br />

    <section class="container flex" style="display: flex; flex-wrap: wrap">
        <div class="item flex-item-1" style="flex: 1;">

            <label>Data do Início</label>
            <asp:TextBox ID="TextBox3" Type="datetime-local" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>

        </div>

        <div class="item flex-item-1" style="flex: 1;">

            <label>Data do fim</label>
            <asp:TextBox ID="TextBox4" Type="datetime-local" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
        </div>
    </section>
    <br />

    <section class="container flex" style="display: flex; flex-wrap: wrap">
        <div class="item flex-item-1" style="flex: 1;">
            <p style="display: flex; justify-content: center;">
                <asp:Button Text="Salvar" ID="button1" runat="server" OnClick="button1_OnClick" Width="100px"
                    Style="margin-right: 20px" class="btn btn-primary btn-sm" OnClientClick="return confirm('Tem certeza que deseja salvar?')" />
                <asp:Button Text="Cancelar" ID="button2" runat="server" OnClick="buttonLimpar_OnClick" Width="100px" class="btn btn-secondary btn-sm" />
            </p>
        </div>
    </section>

    <asp:TextBox ID="TextBoxId" runat="server" Font-Size="Medium" Width="200px" Visible="false"></asp:TextBox>

    <br />
    <%-- Botões Editar e Deletar + GRID --%>

    <asp:GridView ID="GridView1" runat="server" OnDataBinding="GridView1_OnDataBinding" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Deletar">
                <ItemTemplate>
                    <asp:Button runat="server" ID="buttonDelete" HeaderText="Deletar" Text="Deletar" CommandName="deletar"
                        OnClientClick="return confirm('Tem certeza que deseja deletar?')" />
                </ItemTemplate>
                <ItemStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:Button runat="server" ID="buttonEdit" HeaderText="Editar" Text="Editar" CommandName="editar" />
                </ItemTemplate>
                <ItemStyle ForeColor="Gray" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:BoundField DataField="nm_container" HeaderText="Número do container" />
            <asp:BoundField DataField="cd_movimentacao" HeaderText="ID da movimentação" />
            <asp:BoundField DataField="ds_tipo" HeaderText="Tipo de movimentação" />
            <asp:BoundField DataField="dt_inicio" HeaderText="Data inicio" />
            <asp:BoundField DataField="dt_fim" HeaderText="Data fim" />
        </Columns>
    </asp:GridView>

</asp:Content>
