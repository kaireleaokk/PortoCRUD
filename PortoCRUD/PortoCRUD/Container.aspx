<%@ Page Title="Container" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Container.aspx.cs" Inherits="PortoCRUD.Container" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <%-- Campo de preenchimento(Label e textBox) --%>


    <h1 style="text-align: center; margin-bottom: 20px">Cadastro de Container</h1>

    <section class="container flex" style="display: flex; flex-wrap: wrap">

        <div class="item flex-item-1" style="flex: 1;">
            <label>Nome do Cliente</label>
            <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium" Width="100%"></asp:TextBox>
        </div>

        <div class="item flex-item-1" style="flex: 1;">
            <label>Nome do Container</label>
            <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium" Width="100%" MaxLength="11"></asp:TextBox>
        </div>

    </section>
    <br />

    <section class="container flex" style="display: flex; flex-wrap: wrap">
        <div class="item flex-item-1" style="flex: 1;">

            <label>Tipo</label>
            <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" Height="25px">
                <asp:ListItem Selected="True" Value="0"> ... </asp:ListItem>
                <asp:ListItem Value="20"> 20 </asp:ListItem>
                <asp:ListItem Value="40"> 40 </asp:ListItem>
            </asp:DropDownList>

        </div>
        <div class="item flex-item-1" style="flex: 1;">

            <label>Status</label>
            <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" Height="25px">
                <asp:ListItem Selected="True" Value="0"> ... </asp:ListItem>
                <asp:ListItem Value="Cheio"> Cheio </asp:ListItem>
                <asp:ListItem Value="Vazio"> Vazio </asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="item flex-item-1" style="flex: 1;">

            <label>Categoria</label>
            <asp:DropDownList ID="DropDownList3" runat="server" Width="200px" Height="25px">
                <asp:ListItem Selected="True" Value="0"> ... </asp:ListItem>
                <asp:ListItem Value="Exportação"> Exportação </asp:ListItem>
                <asp:ListItem Value="Importação"> Importação </asp:ListItem>
            </asp:DropDownList>
        </div>
    </section>
    <br />

    <section class="container flex" style="display: flex; flex-wrap: wrap">
        <div class="item flex-item-1" style="flex: 1;">
            <p style="display: flex; justify-content: center;">
                <asp:Button Text="Salvar" ID="button1" runat="server" OnClick="button1_OnClick" Width="100px" Style="margin-right: 20px" class="btn btn-primary btn-sm" />
                <asp:Button Text="Cancelar" ID="button2" runat="server" OnClick="buttonLimpar_OnClick" Width="100px" class="btn btn-secondary btn-sm" />
            </p>
        </div>
    </section>

    <asp:TextBox ID="TextBoxId" runat="server" Font-Size="Medium" Width="200px" Visible="false"></asp:TextBox>



    <%-- Botões Editar e Deletar + GRID --%>
    <br />
    <asp:GridView ID="GridView1" runat="server" OnDataBinding="GridView1_OnDataBinding" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Deletar">
                <ItemTemplate>
                    <asp:Button runat="server" ID="buttonDelete" HeaderText="Deletar" Text="Deletar" CommandName="deletar" OnClientClick="return confirm('Tem certeza que deseja deletar?')" />
                </ItemTemplate>
                <ItemStyle ForeColor="Red" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:Button runat="server" ID="buttonEdit" HeaderText="Editar" Text="Editar" CommandName="editar" />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle ForeColor="Gray" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>

            <asp:BoundField DataField="cd_container" HeaderText="ID do Container" />
            <asp:BoundField DataField="nm_cliente" HeaderText="Nome do Cliente" />
            <asp:BoundField DataField="nm_container" HeaderText="Nome do Container" />
            <asp:BoundField DataField="ds_tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="ds_status" HeaderText="status" />
            <asp:BoundField DataField="ds_categoria" HeaderText="categoria" />
        </Columns>
    </asp:GridView>

</asp:Content>
