<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="RespuestaIT.aspx.vb" Inherits="APPCRUZADI.RespuestaIT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            padding: 8px;
            display: block;
            border-bottom: 1px solid #ccc;
            width: 100%;
            height: 150px;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: medium;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: medium;
        }
        .auto-style3 {
            height: 138px;
            width: 1194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br /> <br />

  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Responder Gestion </h1>
    </header>

    <div class="w3-container">
       <br/>
  
       <div class="w3-row w3-border">


       <div class="w3-twothird w3-container">
       <label>Ticket Soporte</label>
       <input runat="server" class="w3-input" type="text" id="TxtTicket"  placeholder="Numero Ticket" autocomplete="off" readonly="readonly"  />
       <label>Nombre Usuario</label>
       <input runat="server" class="w3-input" type="text" id="txtnombreusuario"  placeholder="Nombre Usuario" autocomplete="off" readonly="readonly" />
         </div>


       <div class="w3-third w3-container">
            <label>Gestion</label>
       <input runat="server" class="w3-input" type="text" id="txtgestion"  placeholder="Gestion" autocomplete="off" readonly="readonly" />
    
       <%--<label>asignado a:</label>
                      <input runat="server" class="w3-input" type="text" id="TxtAsignado"  autocomplete="off" readonly="readonly" />
      --%>
       <label>Estado</label>
            <input runat="server" class="w3-input" type="text" id="TxtEstado"  autocomplete="off" readonly="readonly" />
      
 <%--    <select runat="server" class="w3-input"  id="cbEstado">

     </select>
--%>

       </div>
           <br />
       <div class="w3-container">
       <fieldset class="auto-style3">
        <legend>Descripcion De La Gestion</legend>
       <textarea  class="auto-style2" runat="server" id="TxtDescripcion" readonly="readonly">
       </textarea>
       </fieldset>
           <br />           <br />
<hr />
       <fieldset>
        <legend>Respuesta De La Gestion</legend>
       <textarea  class="auto-style2" runat="server" id="TxtRespuesta">
Buenos Dias Estimados 

Su caso esta en proceso.

Sin mas que decir,
Saludos.
       </textarea>
       </fieldset>
       </div>
       <br/><br/>
                  <div class="w3-container w3-center">
       <button runat="server" id="btnProceso" class="w3-deep-orange btn-lg" >Proceso</button>
       <button runat="server" id="btnEnviar" class="w3-deep-orange btn-lg" >Finalizado</button>
                      </div>
        <br/><br/>
            </div>
       <br/>
    </div>
   <footer class="w3-container w3-deep-orange">

       <a href="/ITPrincipal.aspx" style='color: white'></a>
            <h3>IT Principal</h3>
      </footer>
  </div>



</asp:Content>
