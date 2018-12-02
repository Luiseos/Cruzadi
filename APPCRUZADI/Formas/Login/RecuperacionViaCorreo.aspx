<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="RecuperacionViaCorreo.aspx.vb" Inherits="APPCRUZADI.RecuperacionViaCorreo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div class="w3-container">
 

  <div class="w3-card-4" style="width:100%;">
    <header class="w3-container w3-deep-orange">
      <h1 class=w3-center>Via Correo</h1>
    </header>

      <div class="w3-container">
          <br />
          <br />
          <fieldset>
            <%--  <label><b>Usuario</b></label>
              <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                  <input runat="Server" id="Txtusercorreo" class="w3-input w3-border " type="text" name="usuario" style="text-transform: uppercase" onkeyup="Espacio(this, event)" onkeypress="return Letras(event)" required>
              </div>--%>
            <br />

                  <label><b>Email</b></label>
                <div class="input-group">
                  <span class="input-group-addon"><i class="material-icons">email</i></span>

                  <input id="txtcorreo" runat="server" autocomplete="off"  class="w3-input w3-border" type="Email" placeholder="Ingrese Su Correo Electronico" name="correo" required>
              </div>
          </fieldset>
          <br>
             <div class="w3-container w3-center">
              <div class="w3-half" >
          <button runat="server" id="btnRecuperarcorreo" class="w3-deep-orange btn-lg" type="submit">Recuperar</button>
          <button class="w3-deep-orange btn-lg" type="reset">Cancelar</button>
                   </div> </div>
      </div>

    <footer class="w3-container w3-deep-orange">
          <h3>  <a href="RecuperarContraseña.aspx" class="w3-center"  style='color: white' >Recuperacion</a></h3>

     </footer>
  </div>
</div>

</asp:Content>
