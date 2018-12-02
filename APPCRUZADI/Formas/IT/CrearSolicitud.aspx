<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="CrearSolicitud.aspx.vb" Inherits="APPCRUZADI.CrearSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />


  

  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Crear Solicitud a Soporte </h1>
    </header>

    <div class="w3-container">
      <br/>
  
      <div class="w3-row w3-border">
       <br/><br/>
       <div class="w3-twothird w3-container">

       <label>Nombre Usuario</label>
       <input runat="server" class="w3-input" type="text" id="txtnombreusuario"  placeholder="Nombre Usuario" readonly="readonly" />
       <br/><br/>
        </div>
        <div class="w3-third w3-container">
          <label>Tipo de Gestion</label>
          <select runat="server" class="w3-input"  id="cbtipogestion"></select>
        </div> 
        <div class="w3-container">
          <fieldset>
        <legend>Descripcion De La Gestion</legend>
       <textarea runat="server" id="TxtDescripcion" class="w3-input">
       </textarea>
       </fieldset>
         </div>  
       <br/><br/>
             <div class="w3-container w3-center">
       <button runat="server" id="btnAgregar" class="w3-deep-orange btn-lg" >Guardar</button>
                 </div>
        <br/><br/>
    </div>
      </div> 
          <br/><br/>
      
    </div>

      <br/>
      <br/>

   <footer class="w3-container w3-deep-orange">
    
            <a href="/inicio.aspx" style='color: white'/>
                 <h3>INICIO</h3>
    </footer>

</asp:Content>
