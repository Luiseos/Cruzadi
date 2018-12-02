<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ParametrosComiCC.aspx.vb" Inherits="APPCRUZADI.ParametrosComiCC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
 <br />


  

  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Parametros Comision de Credito</h1>
    </header>

    <div class="w3-container">
      <br/>
      <br/>
      <fieldset>
            <br/>
        <label>Porcentaje Comision</label>
        <input runat="server" id="TxtPorComision" class="w3-input" type="text"  value="10" onkeypress="return filterFloat(event,this);"   autocomplete="off" />
            <br/>
          <label>Porcentaje Credito</label>
        <input  runat="server" id="TxtPorCredito" class="w3-input" type="text" value="10"  onkeypress="return filterFloat(event,this);"   autocomplete="off" />
            <br/>
          <label>Porcentaje Facturacion</label>
        <input runat="server" id="TxtPorFacturacion" class="w3-input" type="text"  value="10" onkeypress="return filterFloat(event,this);"  autocomplete="off" />
        <br/> 
        <br/>
        </fieldset>
        <br/> 
        <br/>
        
        <div class="w3-container w3-center">
                            <button runat="server" id="BtnModificar" class="w3-deep-orange btn-lg" >Modificar</button>
                        </div>

    </div>
    </div>

      <br/>
      <br/>
  <footer class="w3-container w3-deep-orange">
    
            <a href="/inicio.aspx" style='color: white'>
                 <h3>INICIO</h3>
            </a>

        </footer>


</asp:Content>
