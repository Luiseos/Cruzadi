<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Pregunta_seguridad.aspx.vb" Inherits="APPCRUZADI.Pregunta__segurida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="w3-container">
  <h2>W3.CSS Login Modal</h2>
  <button onclick="document.getElementById('Pregunta').style.display='block'" class="w3-button w3-deep-orange w3-large">Login</button>
 <div id="Pregunta" class="w3-modal" data-backdrop="static" role="main"    >
        <div class="w3-modal-content w3-card-4 w3-animate-zoom " style="max-width:500px">
        
            <header class="w3-container w3-deep-orange">
                <span onclick="document.getElementById('Pregunta').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright" title="Close Modal">&times;</span>

                <h2>Pregunta de Seguridad</h2>
            </header>
       <br />

        <div class="w3-section">
            <fieldset>
          
 <label><b>Seleccione una Pregunta</b></label>
          <select  runat="server" id="Cb_Pregunta" class="w3-input w3-border w3-margin-bottom" required></select>
          <label><b>Respuesta</b></label>
          <input runat="server"  id="TxtRespuesta" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese Su Respuesta" name="Respuesta" required>

                </fieldset>
            
            <button runat="server" id="BtnGuardar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="button"  >Guardar</button>
          <button runat="server" id="BtnCancelar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="reset">Cancelar
         </button>
           </div>
         </div>
    </div>
     

</div>

</div>
       
</asp:Content>
