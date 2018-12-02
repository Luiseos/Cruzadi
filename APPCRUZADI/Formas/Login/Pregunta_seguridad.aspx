<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Pregunta_seguridad.aspx.vb" Inherits="APPCRUZADI.Pregunta__segurida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <style type="text/css">
        .auto-style1 {
            width: 58%;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="w3-container w3-center" ">
    <article class=" w3-center">

   <div class="w3-card-4  w3-center" style="width:50%;" >
    <header class="w3-container  w3-center w3-deep-orange">
   <h2>Pregunta de Seguridad</h2>
    </header>

            <fieldset>
          <legend>Seleccione una Pregunta</legend>
 <div class="w3-row-padding">
          <select  runat="server" id="Cb_Pregunta" class="w3-input w3-border w3-margin-bottom" required></select>
          <label><b>Respuesta</b></label>
          <input runat="server"  autocomplete="off"  style="text-transform: uppercase"  id="TxtRespuesta" onkeyup="DobleEspacio(this, event)"  class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese Su Respuesta" name="Respuesta" required>
     </div>
                <br />
                <br />

                     <div class="w3-container w3-center">
              <div class="w3-half" >
  <button runat="server" id="BtnGuardar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Guardar</button>
                <%-- </div>
                <div class="w3-half">--%>
                   <button runat="server" id="BtnCancelar" class="w3-deep-orange btn-lg" type="reset"><span class="glyphicon glyphicon-remove"></span>Cancelar</button>
      
             </div>

            </div>

    
                </fieldset>
       
                </div>
     </article>

</div>

       
</asp:Content>
