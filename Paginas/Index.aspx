<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DesafioRevista.Paginas.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <form runat="server">
        <br />
        <div class="container">
        <div class="row">

        <div class="col-md-3"></div>

        <div class="col-md-6 Textohprincipal textocolor">
        <h2>Suscripción</h2>
        <p>Para realizar la suscripción complete los siguientes datos.</p>
        </div>

        <div class="col-md-3"></div>

        </div>
        </div>
        <hr />
        <div class="container">
            <div class="row">

           


                <div class="col-md-4"> </div>

 

                <div class="col-md-3">
                <label class="form-label textocolor">DNI</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbindexdni"></asp:TextBox>
                </div>

                <div class="col-md-2">
                    <label ></label><br />
                 
                 <asp:Button runat="server" Width="100px" ID="btnBuscar" CssClass="btn btn-success form-control" Text="Buscar" OnClick="btnBuscar_Click"/>
                </div>

                <div class="col-md-3"> </div>

         
            </div>
        </div>
                    
         <hr />
        <div class="container">
            <div class="row">

            <div class="col-md-4"> </div>

            <div class="col-md-4">
            <asp:Label runat="server" CssClass="h2 textocolor" ID="lblBuscarDni"></asp:Label>
            <asp:Button runat="server" ID="btnCreate1" CssClass="btn btn-primary form-control" visible="false" Text="Registrar Suscripción" OnClick="btnCreate1_Click"/>
            </div>

            <div class="col-md-4"> </div>

            </div>
         </div>

         <br />
        <div class="container">
        <div class="container row">
            <div class="table samll  fondocolor">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Datos del suscriptor">
                            <ItemTemplate>
                                <asp:Button runat="server" Width="100px" Text="Leer" CssClass="btn btn-outline-secondary form-control" ID="btnRead" OnClick="btnRead_Click"/>
                                <br /><br />
                                <asp:Button runat="server" Width="100px" Text="Modificar" CssClass="btn btn-outline-info form-control" ID="btnUpdate" OnClick="btnUpdate_Click"/>
                                <br /><br />
                                <asp:Button runat="server" Width="100px" Text="Eliminar" CssClass="btn btn-outline-danger form-control" ID="btnDelet" OnClick="btnDelet_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
            </div>
    </form>
</asp:Content>











