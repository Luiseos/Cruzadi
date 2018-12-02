<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="GestionUsuario.aspx.vb" Inherits="APPCRUZADI.GestionUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <article>

    <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
    <h1>Gestion de Usuario</h1>
    </header>

        <div class="container w3-panel w3-round-small ">



            <br />

            <div class="w3-section">
                <fieldset>

                    <legend>Gestion de Usuario</legend>

                    <div class="w3-half">
                        <label><b>Nombre</b></label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                            <input runat="server" id="TxtNombre" autocomplete="off" onblur="textChanged()" onkeyup="DobleEspacio(this,event)" onkeypress="return Letras(event)" class="text-uppercase w3-input  w3-border" type="text" placeholder="Ingrese Nombre" name="Nombre" required disabled="disabled">
                        </div>
                        <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un Nombre" ControlToValidate="TxtNombre" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <label><b>Usuario</b></label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                            <input runat="server" id="TxtUsuarioR" autocomplete="off" onkeyup="Espacio(this, event)" onkeypress="return Letras(event)" class="text-uppercase w3-input  w3-border" type="text" placeholder="Ingrese el Usuario" name="usuario" required disabled="disabled">
                        </div>
                        <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un usuario" ControlToValidate="Txtusuarior" ForeColor="#FF3300" ValidateRequestMode="Inherit">


                        </asp:RequiredFieldValidator>
                        <br />

                        <label><b>Rol Usuario</b></label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <select runat="server" id="CbRol" class="text-uppercase w3-input  w3-border" style="text-transform: uppercase" required>
                                <%--  <option >Elegi rol</option>
                                --%>       <%--<option value="Gerente">Gerente</option>
                                 <option value="Creditos cobros">Creditos cobros</option>
                                     <option value="Facturacion">Facturacion</option>
                                     <option value="Usuarios Generales ">Usuarios Generales </option>--%>
                            </select>

                        </div>
                        <br />
                        <hr />
                        <hr>
                    </div>


                    <div class="w3-half">
                        <label><b>E-mail</b></label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="material-icons">email</i></span>

                            <input runat="server" id="TxtEmail" autocomplete="off" class="text-uppercase w3-input  w3-border" type="Email" placeholder="Ingrese Su Correo Electronico" name="usrname">
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un Email" ControlToValidate="TxtEmail" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="REVEmailR" runat="server" ForeColor="#FF3300" ErrorMessage="Correo Invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail"></asp:RegularExpressionValidator>
                        <br />
                        <div class='col-lg'>
                            <label>Fecha de Vencimiento</label>
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-calendar"></i></span>
                                <input runat="server" id="Vencimiento" type="date" autocomplete="on" class="text-uppercase w3-input  w3-border" />
                            </div>
                        </div>
                        <br />


                        <label><b>Estado del Usuario</b></label>
                        <div class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <select runat="server" id="CbEstado" class="text-uppercase w3-input  w3-border" required>
                                <option value="Bloqueado">Bloqueado</option>
                                <option value="Activo">Activo</option>
                                <option value="Inactivo">Inactivo</option>
                            </select>

                        </div>

                        <br />
                        <%-- ''--%>
                        <hr>
                    </div>
                    <hr />

                </fieldset>
            </div>



        </div>
        <br />
          <div class="w3-container w3-center">
              <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Usuario :</small>
                                <asp:Label ID="lblTotalesGestion" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">
                    <asp:GridView ID="GVGU" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Usuario" AllowSorting="false">
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
                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorGestionn" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />
</div></div>
              </div>

              <div class="w3-container w3-center">
      <button runat="server"  id="BtnModificar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>  Modificar</button>&nbsp&nbsp
        <button runat="server" id="BtnCancelar" class="w3-deep-orange btn-lg" type="reset"><span class="glyphicon glyphicon-remove"></span>  Cancelar</button>
             </div>
</div>  
                


  

        
             <footer class="w3-container w3-deep-orange">
       
   <h3> <a  href="../../Inicio.aspx"  style='color: white'>INICIO</a></h3>  
    </footer>
    


    
    </article>

</asp:Content>
