﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CambiarContraseña.aspx.vb" Inherits="APPCRUZADI.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

  <article>
      

    <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
      <h1>Cambiar Contraseña</h1>
    </header>

  <div class="container w3-panel w3-round-small " >
  
  <fieldset >
      <legend>Datos Del Cambio:</legend>

      <div class="w3-row-padding">
          <div class="w3-section">

              <label><b>Contraseña Actual</b></label>
              <div class="input-group">
                  <span class="input-group-addon" onclick="myFunction('<%=txtcontraseña.ClientID%>')"><i class="glyphicon glyphicon-lock " ></i></span>
                  <input runat="server" id="txtcontraseña" autocomplete="off" onkeyup="Espacio(this, event)" class="w3-input w3-border" type="password" placeholder="Ingrese Contraseña" name="Cactual" required>
              </div>
              <asp:RequiredFieldValidator ID="RFVContraseña" runat="server" ErrorMessage="RequiredFieldValidator" Text="Debe de ingresar una Contraseña" ControlToValidate="TxtContraseña" ForeColor="#FF3300"></asp:RequiredFieldValidator>
              <br />
              <label><b>Nueva Contraseña</b></label>
              <div class="input-group">
                  <span class="input-group-addon" onclick="myFunction('<%=txtncontraseña.ClientID%>')"><i class="glyphicon glyphicon-lock" ></i></span>
                  <input runat="server" id="txtncontraseña"  autocomplete="off"  onkeyup="Espacio(this, event)" class="w3-input w3-border " type="password" placeholder="Nueva Contrase&ntilde;a" name="Ncontraseña" required>
              </div>
          </div>

          <asp:CompareValidator ID="CVComparador" runat="server" ErrorMessage="Contraseña no son iguales" ForeColor="#FF3300" ControlToCompare="txtncontraseña" ControlToValidate="txtccontraseña"></asp:CompareValidator>
          <br />
          <label><b>Confirme Contrase&ntilde;a</b></label>
          <div class="input-group">
              <span class="input-group-addon" onclick="myFunction('<%=txtccontraseña.ClientID%>')" ><i class="glyphicon glyphicon-lock" ></i></span>
              <input runat="server" id="txtccontraseña" autocomplete="off"  onkeyup="Espacio(this, event)" class="w3-input w3-border " type="password" placeholder="Nueva Contrase&ntilde;a" name="Ccontraseña" required>
          </div>
            <asp:CustomValidator ID="CstContraseñaRecu" runat="server" ErrorMessage="Contraseña Valida" ForeColor="#FF3300" ControlToValidate="txtccontraseña"></asp:CustomValidator>
                  <br />

       <br />
      </div>
    
         <div class="w3-container w3-center">
             <br />
             <div class="w3-half" >
  <button runat="server" id="BtnGuardar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Guardar</button>
  <button runat="server" id="BtnCancelar" class="w3-deep-orange btn-lg" type="reset"><span class="glyphicon glyphicon-remove"></span>Cancelar</button>
      

<%--             </div>
                <div class="w3-half">--%>
                 
             </div>
          </div>
      
 </fieldset>
 </div>
</div>




    <footer class="w3-container w3-deep-orange">
  <h3>  <a runat="server" id="Atras"  class="w3-center" style='color: white'>Regresar</a></h3>
    </footer>


 





 </article>
</asp:Content>
