<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ParametrosComiVentas.aspx.vb" Inherits="APPCRUZADI.ParametrosComiVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
 <br />
      <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Parametros Comision de Ventas</h1>
    </header>

    <div class="w3-container">
      <br/>
      <br/>
      <fieldset>
            <br/>
        <label>Porcentaje  Comision</label>
        <input runat="server" class="w3-input" type="text" id="txtPorcentajeVentas" placeholder="Porcentaje De Comision" autocomplete="off" value="10" onkeypress="return filterFloat(event,this);" />
         <br/>
           <label>Porcentaje  Aceptable</label>
        <input runat="server" class="w3-input" type="text" id="txtPorcentajeAceptable"  placeholder="Porcentaje de Aceptable" autocomplete="off" value="10" onkeypress="return filterFloat(event,this);" />
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
