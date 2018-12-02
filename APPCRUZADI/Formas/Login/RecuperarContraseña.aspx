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

      
    <div class="w3-container">
    	<br/><br/>
        <div class="w3-row-padding">
          <div class="w3-section">
             
      <label><b>Usuario</b></label>
                  <div class="input-group">
                  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
              
                     <input runat="server" id="txtusuario" autocomplete="off"  class="w3-input w3-border " type="text" placeholder="Ingrese el Usuario" name="usuario" style="text-transform: uppercase"  onkeyup="es_vacio(), Espacio(this, event)" onkeypress="return Letras(event)">
           </div>
          <button   runat="server" id="BtnCorreo"   class="w3-button w3-block w3-deep-orange w3-section w3-padding" disabled="disabled"><h3>Via Correo</h3></button>


           <button  runat="server" id="BtnPregunta"  class="w3-button w3-block w3-deep-orange w3-section w3-padding" disabled="disabled"><h3>Via Pregunta </h3>
         </button>
    </div>
                
  </div>
        </div>
      </fieldset>
</div>

    <footer class="w3-container w3-deep-orange">
  <h3>  <a href="/login.aspx" class="w3-center"  style='color: white'>Regresar</a></h3>
    </footer>

 
        </div>

 </article>



 
    <script  type="text/javascript">
function es_vacio()
  {
  
    if (document.getElementById('<%=txtusuario.ClientID%>').value=="")
      {   
        document.getElementById('<%=btncorreo.ClientID%>').disabled=true;
       document.getElementById('<%=btnpregunta.ClientID %>').disabled=true;
      }
  
   else {
         document.getElementById('<%=btncorreo.ClientID%>').disabled=false;
         document.getElementById('<%=btnpregunta.ClientID %>').disabled=false;
         }
   }  
        
</script>
</asp:Content>
