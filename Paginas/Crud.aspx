<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="DesafioRevista.Paginas.Crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

     <br />
        <div class="mx-auto" style="width:450px">
            <asp:Label runat="server" CssClass="h2 textocolor" ID="lbltitulo"></asp:Label>
           
        </div>

     <br />
     <div class="container">
        <form runat="server" class="row g-3">

             <div class="col-md-6">
                <label class="form-label textocolor">Tipo Documento</label>
                 <br />
                 <asp:DropDownList ID="drop_TipoDocum" runat="server" Width="200px"></asp:DropDownList>
                 <asp:TextBox runat="server" CssClass="form-control" id="tbtipodni"  Visible="false"  Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">DNI</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbdni" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbnombre"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbapellido"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Direccion</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbdireccion"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbemail"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Telefono</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbtelefono"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Estado</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbestado" Enabled="false"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Nombre de Usuario</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbusuario"></asp:TextBox>
            </div>

            <div class="col-md-6">
                <label class="form-label textocolor">Contraseña</label>
                <asp:TextBox runat="server" CssClass="form-control" id="tbcontrasena"></asp:TextBox>
            </div>



             <div class="col-md-5">

            </div>
            <div class="col-md-2">
            <asp:Button runat="server" Text="Registrar" CssClass="btn btn-primary form-control" ID="btnCreate" Visible="false" OnClick="btnCreate_Click"/>
            <asp:Button runat="server" type="button" Text="Modficar" CssClass="btn btn-primary form-control" ID="btnUpdate" Visible="false" OnClick="btnUpdate_Click"/>
            <asp:Button runat="server" Text="Eliminar" CssClass="btn btn-primary form-control" ID="btnDelete" Visible="false" OnClick="btnDelete_Click"/>
                 <br /><br />
            <asp:Button runat="server" Text="Cancelar" CssClass="btn btn-primary form-control btn-dark" ID="btnVolver" Visible="true" OnClick="btnVolver_Click"/>
           
            </div>
            <div class="col-md-5">

            </div>
           
  
        </form>
     </div>
<!-- Button trigger modal -->

<%--<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
  Lanzar demo de modal
</button>--%>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Exito al Modificar datos los del Suscriptor</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...hllla
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
        <button type="button" class="btn btn-primary">Guardar cambios</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>
