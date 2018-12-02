<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Registro.aspx.vb" Inherits="APPCRUZADI.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <div id="Registro" class="w3-modal" data-backdrop="static" role="main"    >
        <div class="w3-modal-content w3-card-4 w3-animate-zoom " style="max-width:500px">
        --%>
     <article>

    <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
    <h1>Registrese</h1>
    </header>

  <div class="container w3-panel w3-round-small " >
  
      <fieldset>

          <br />

          <div class="w3-section">
              <fieldset>
                  <label><b>Nombre</b></label>
                  <div class="input-group">
                      <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                      <input runat="server" id="TxtNombre" autocomplete="off"  onblur="textChanged()" onkeyup="DobleEspacio(this,event)" onkeypress="return Letras(event)" class="text-uppercase w3-input  w3-border" type="text" placeholder="Ingrese Nombre" name="Nombre" required>
                  </div>
                  <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un Nombre" ControlToValidate="TxtNombre" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                  <br />
                  <label><b>Usuario</b></label>
                  <div class="input-group">
                      <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                      <input runat="server" id="TxtUsuarioR" autocomplete="off"  onkeyup="Espacio(this, event)" onkeypress="return Letras(event)" class="text-uppercase w3-input  w3-border" type="text" placeholder="Ingrese el Usuario" name="usuario" required>
                  </div>
                  <asp:RequiredFieldValidator ID="RFVUsuario" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un usuario" ControlToValidate="Txtusuarior" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                  <br />
                  <label><b>Contrase&ntilde;a</b></label>
                  <div class="input-group">
                      <span class="input-group-addon" onclick="myFunction('<%=TxtContraseñaR.ClientID%>')"><i class="glyphicon glyphicon-lock" ></i></span>

                      <input runat="server" autocomplete="off"  onkeyup="Espacio(this, event)" id="TxtContraseñaR" class=" w3-input  w3-border" type="password" placeholder="Ingrese Contrase&ntilde;a" name="usrname" required>
                  </div>
                  <asp:RequiredFieldValidator ID="RFVContraseña" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar una Contraseña" ControlToValidate="TxtContraseñaR" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                  <br />
                  <asp:CustomValidator ID="CstContraseñaR" runat="server" ErrorMessage="Contraseña Valida" ForeColor="#FF3300" ControlToValidate="TxtContraseñaR"></asp:CustomValidator>
                  <br />

                  <label><b>Confirme Contrase&ntilde;a</b></label>
                  <div class="input-group">
                      <span class="input-group-addon" onclick="myFunction('<%=TxtContraseñaConfirmar.ClientID%>')"><i class="glyphicon glyphicon-lock" ></i></span>

                      <input runat="server" autocomplete="off"  onkeyup="Espacio(this, event)" id="TxtContraseñaConfirmar" class=" w3-input  w3-border" type="password" placeholder="Confirme Contrase&ntilde;a" name="" required>
                  </div>
                  <asp:CompareValidator ID="CVComparador" runat="server" ErrorMessage="Contraseña no son iguales" ForeColor="#FF3300" ControlToCompare="TxtContraseñaR" ControlToValidate="TxtContraseñaConfirmar"></asp:CompareValidator>
                  <br />
                  <label><b>E-mail</b></label>
                  <div class="input-group">
                      <span class="input-group-addon"><i class="material-icons">email</i></span>

                      <input runat="server" id="TxtEmail" autocomplete="off"  class="text-uppercase w3-input  w3-border" type="Email" placeholder="Ingrese Su Correo Electronico" name="usrname" required>
                  </div>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar un Email" ControlToValidate="TxtEmail" ForeColor="#FF3300" ValidateRequestMode="Inherit"></asp:RequiredFieldValidator>
                  <br />
                  <asp:RegularExpressionValidator ID="REVEmailR" runat="server" ForeColor="#FF3300" ErrorMessage="Correo Invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail"></asp:RegularExpressionValidator>
              </fieldset>
          </div>
              <div class="w3-container w3-center">
      <button runat="server" id="BtnGuardar" class="w3-deep-orange btn-lg"  type="button"><span class="glyphicon glyphicon-ok"></span>  Guardar</button>&nbsp&nbsp
        <button runat="server" id="BtnCancelar" class="w3-deep-orange btn-lg"  type="reset"><span class="glyphicon glyphicon-remove"></span>  Cancelar</button>
             </div>
         
      </fieldset>
</div>
        </div>

        
             <footer class="w3-container w3-deep-orange">
       
   <h3> <a  href="../../Login.aspx"  style='color: white'>Login</a></h3>  
    </footer>
    

 </article>
    <%--  </div>
    </div>
     --%>
</asp:Content>
