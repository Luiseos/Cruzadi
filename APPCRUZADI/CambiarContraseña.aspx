<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="CambiarContraseña.aspx.vb" Inherits="APPCRUZADI.CambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

  <article>
      <script >

function Espacio(campo, event) {

        CadenaaReemplazar = " ";
        CadenaReemplazo = "";
        CadenaTexto = campo.value;
        CadenaTextoNueva = CadenaTexto.split(CadenaaReemplazar).join(CadenaReemplazo);
        campo.value = CadenaTextoNueva;

    }
</script> 

    <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
      <h1>Cambiar Contraseña</h1>
    </header>

  <div class="container w3-panel w3-round-small " >
  
  <fieldset  >
<legend>Datos Del Cambio:</legend>

<div class="w3-row-padding">
  <div class="w3-section">
          <label><b>Usuario</b></label>
          <input runat="server" id="txtusuario" onkeyup="Espacio(this, event)" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese el Usuario" name="usuario" required style="text-transform: uppercase">
          <label><b>Contraseña Actual</b></label>
          <input runat="server" id="txtcontraseña" onkeyup="Espacio(this, event)" class="w3-input w3-border" type="password" placeholder="Ingrese Contraseña" name="Cactual" required>
          <label><b> Nueva Contrase&ntilde;a</b></label>
          <input runat="server" id="txtncontraseña" class="w3-input w3-border w3-margin-bottom" type="password" placeholder="Nueva Contrase&ntilde;a" name="Ncontraseña" required>
              <asp:CompareValidator ID="CVComparador" runat="server" ErrorMessage="Contraseña no son iguales" ForeColor="#FF3300" ControlToCompare="txtncontraseña" ControlToValidate="txtccontraseña"></asp:CompareValidator>
          <br/>
          <label><b>Confirme Contrase&ntilde;a</b></label>
          <input runat="server" id="txtccontraseña" onkeyup="Espacio(this, event)" class="w3-input w3-border w3-margin-bottom" type="password" placeholder="Nueva Contrase&ntilde;a" name="Ccontraseña" required>
          <button  runat="server" id="Btnguardar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Guardar</button>
          <button class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Cancelar
         </button>


  <div class="w3-container w3-center">
     
  </div>
 </div>
</div>

  </fieldset>
</div>
</div>

    <footer class="w3-container w3-deep-orange">
  <h3>  <a href="Buscar.html" class="w3-center ">Buscar</a></h3>
    </footer>


 





 </article>
</asp:Content>
