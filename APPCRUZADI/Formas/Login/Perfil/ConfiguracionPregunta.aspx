<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="ConfiguracionPregunta.aspx.vb" Inherits="APPCRUZADI.ConfiguracionPregunta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="w3-container">
    
    <div class="w3-card-4" style="width: 100%;">
        <header class="w3-container w3-deep-orange">
            <h1 class="w3-center">Configuracion de Pregunta de seguridad </h1>
        </header>
        <fieldset>


            <div class="w3-container">
       
              <%--  <label><b>ID_Pregunta</b></label>
                <input runat="server" id="txtIDPregunta" class="w3-input w3-border w3-margin-bottom" type="text" placeholder="Rol" name="rol" style="text-transform: uppercase"  disabled="disabled">
            --%>    
         <label><b>Seleccione una Pregunta</b></label>
          <select  runat="server" id="cbPreg" class="w3-input w3-border w3-margin-bottom" required></select>
        
                            <label><b>Respuesta</b></label>
          <input runat="server" id="TxtRespuespreg" class="w3-input w3-border w3-margin-bottom" autocomplete="off"  type="text" placeholder="Ingrese Su Respuesta" name="Respuesta" style="text-transform: uppercase" onkeyup="DobleEspacio(this, event)" required>
    
                <br />

                <hr>
                <br>
            </div>
        </fieldset>
        <br />
          <div class="w3-container w3-center">

            <button runat="server" id="btnguardar" class="w3-deep-orange btn-lg">Guardar</button>
            <button runat="server" id="btnmodificar" class="w3-deep-orange btn-lg" >Modificar</button>
  
          <%--  <asp:Button ID="btnEliminar1" runat="server" cssclass="btn btn-default w3-xlarge" OnClientClick="return confirm('¿Desea Eliminar su pregunta de seguridad?');" Text="Eliminar" />
       --%> </div>
         <br />
    </div>

    <footer class="w3-container w3-deep-orange">
                  <a href="/inicio.aspx" style='color: white'>
                <h3>INICIO</h3>
            </a>


    </footer>
  </div>

</asp:Content>
