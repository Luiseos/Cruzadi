<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="RecuperarContraseña.aspx.vb" Inherits="APPCRUZADI.RecuperarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

  <article>

    <div class="w3-card-4" style="width:100%;">
    <header class="w3-container  w3-center w3-deep-orange">
      <h1>Recuperar Contraseña</h1>
    </header>

  <div class="container w3-panel w3-round-small " >
  
  <fieldset  >
<legend>Datos Del Usuario:</legend>

<div class="w3-row-padding">
  <div class="w3-section">
          <label><b>Usuario</b></label>
          <input runat="server"  id="txtusuario" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese el Usuario" name="usuario" required onkeyup="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()">
          <button runat="server"  id="Btncorreo" onclick="document.getElementById('id01').style.display='block'" class="w3-button w3-block w3-deep-orange w3-section w3-padding">Via Correo</button>
      


  <div id="id01" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-animate-zoom" style="max-width:600px">

      <div class="w3-center"><br>
        <span onclick="document.getElementById('id01').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright" title="Close Modal">&times;</span>
      </div>
        <br/>
        
          <div class="w3-section">
              <fieldset  >
                  <label><b>Usuario</b></label>
                  <input runat="server" id="txtusuario1" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese el Usuario" name="usuario" required onkeyup="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()">
                  <label><b>E-mail</b></label>
                  <input runat="server" id="txtcorreo" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese Su Correo Electronico" name="usrname" required>
         
                 <button runat="server" id="Btnaceptar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Guardar</button>
                 <button runat="server" id="Btcancelar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Cancelar
                 </button>
            </fieldset  >  
          <input class="w3-check w3-margin-top" type="checkbox" checked="checked"> Recuerdame
          </div>
        
      <div class="w3-container w3-border-top w3-padding-16 w3-deep-orange">
        <button onclick="document.getElementById('id01').style.display='none'" type="button" class="w3-button w3-white">Cancel</button>
        <span class="w3-right w3-padding w3-hide-small">Forgot <a href="#">password?</a></span>
      </div>

    </div>
  </div>
          <button  runat="server" id="Btnpregunta" onclick="document.getElementById('id02').style.display='block'" class="w3-button w3-block w3-deep-orange w3-section w3-padding">Via Pregunta
         </button>
         <div id="id02" class="w3-modal">
    <div class="w3-modal-content w3-card-4 w3-animate-zoom" style="max-width:600px">

      <div class="w3-center"><br>
        <span onclick="document.getElementById('id02').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright" title="Close Modal">&times;</span>
      </div>

     
        <div class="w3-section">
            <fieldset  >
              <label><b>Usuario</b></label>
              <input runat="server" id="txtusuario2" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese el Usuario" name="usuario" required onkeyup="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()">
              <label><b>Seleccione una Pregunta</b></label>
              <select runat="server" id="Cbpregunta" class="w3-input w3-border w3-margin-bottom" required></select>
              <label><b>Respuesta</b></label>
              <input runat="server" id="txtrespuesta" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese Su Respuesta" name="Respuesta" required>
              <button runat="server" id="Btnaceptar1" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Guardar</button>
              <button runat="server" id="Btncancelar1" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="submit">Cancelar
              </button>
             </fieldset  >
          <input class="w3-check w3-margin-top" type="checkbox" checked="checked"> Recuerdame
        </div>
     

      <div class="w3-container w3-border-top w3-padding-16 w3-deep-orange">
        <button onclick="document.getElementById('id02').style.display='none'" type="button" class="w3-button w3-white">Cancel</button>
        <span class="w3-right w3-padding w3-hide-small">Forgot <a href="#">password?</a></span>
      </div>

    </div>
  </div>


  <div class="w3-container w3-center">
     
  </div>
 </div>
    </div>
  </fieldset>
</div>
<div>

    <footer class="w3-container w3-deep-orange">
  <h3>  <a href="Buscar.html" class="w3-center ">Buscar</a></h3>
    </footer>


</div>
</div>
 





 </article>
</asp:Content>
