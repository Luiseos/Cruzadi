<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CreacionRoles.aspx.vb" Inherits="APPCRUZADI.Roles" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="w3-card-4" style="width: 100%;">
        <header class="w3-container w3-deep-orange">
            <h1 class="w3-center">Creacion de roles </h1>
        </header>
        <fieldset>


            <div class="w3-container">
                <label><b>Rol</b></label>
                <input runat="server" id="txtrol" autocomplete="off"  class="w3-input w3-border w3-margin-bottom" onkeyup="Espacio(this,event)" onkeypress="return Letras(event)"  type="text" placeholder="Rol" name="rol" style="text-transform: uppercase" >
                <label><b>Descripcion</b></label>
                <input runat="server" id="txtdescrpcionrol"  style="text-transform: uppercase" autocomplete="off"  class="w3-input w3-border w3-margin-bottom" onkeyup="DobleEspacio(this,event)" onkeypress="return Letras(event)" type="text" placeholder="Descripcion" name="Descripcion">
                <br>

                <div class="container w3-panel w3-round-small ">
                    <h3>

                            <span style="float: right;"><small>Total de Ejecutivas :</small>
                                <asp:Label ID="lblTotalesRoles" runat="server" CssClass="label label-warning" /></span>
                        </h3>
                    <br />
                    <div class="table-responsive">

 <asp:GridView ID="GVRol" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Rol_id" AllowSorting="false">
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />
 </asp:GridView>
                 
                           </div>

                </div>

                <hr>
                <br>
            </div>
        </fieldset>
        <br />
              <div class="w3-container w3-center">

     <button   runat="server" id="btnguardar"  class="w3-deep-orange btn-lg" >Guardar</button>
      <button  runat="server" id="btnmodificar"  class="w3-deep-orange btn-lg" >Modificar</button>
    <%--  <button  runat="server" id="btneliminar"  class="btn btn-default w3-xlarge" >Eliminar</button>--%>
    </div>
        <br />
    </div>

    <footer class="w3-container w3-deep-orange">
    
<a href="/inicio.aspx"  style='color: white'><h3> INICIO</h3></a>
      
    </footer>

</asp:Content>
