<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.master" CodeBehind="AgregarCLientes.aspx.vb" Inherits="APPCRUZADI.AgregarCLientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br /><br /> 
    <article>

    <div class="w3-card-4" style="width:100%">
    <header class="w3-container  w3-center w3-deep-orange">
      <h1>Agregar clientes</h1>
    </header>

  <div class="container w3-panel w3-round-small " >
  
  <fieldset  >
<legend>Datos Del Cliente:</legend>

<div class="w3-row-padding">

        <div class="form-group">
                    <div class="w3-container w3-center">
            
  <button runat="server" id="BtnBuscarCliente" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Buscar Cliente</button>

                    </div>
                            </div>
    
    <div class="w3-third">

      
  <label><span class="glyphicon glyphicon-plus-sign"style="font-size:24px;"></span></label>

  <%--<input  runat="server" class="w3-input"  type="text" id="txtAcliente"  placeholder="Numero de Cliente" autocomplete="off" />--%> 
<asp:TextBox id="txtAcliente" runat="server" cssclass="w3-input" AutopostBack="true" ></asp:TextBox>
<br/>
         

  <label ><span class="glyphicon glyphicon-user"style="font-size:24px;"></span></label>
        <input  runat="server" class="w3-input" type="text" id="TxttipoCliente"  autocomplete="off"/> 

<%--  <select runat="server" id="cbtcliente" class="w3-input"><option disabled selected>Tipo de cliente</option></select>--%>
  <br/>
   
  
<label><span class="glyphicon glyphicon-user"style="font-size:24px;"></span></label>
  <input  runat="server" class="w3-input" type="text" id="txtnombre"  placeholder="Nombre" autocomplete="off"/> 
  <br/> 
        <label>RTN</label>
      <input runat="server" class="w3-input" type="text" id="txtRTN"  placeholder="RTN" autocomplete="off"/> 
      <br/>     
    </div>

    <div class="w3-third">
         <label><span class="glyphicon glyphicon-globe"style="font-size:24px;"></span></label>
  <input runat="server" class="w3-input" type="text" id="txtDireccion" placeholder="Direccion" autocomplete="off"/> 
  <br/>

    <label><span class="glyphicon glyphicon-envelope" style="font-size:24px;"></span></label>  <button runat="server" type="button" id="btmmasemail" class="btn w3-right">+</button>
  <input  runat="server" class="w3-input" type="text" id="txtEmail"  placeholder="Email" autocomplete="off"/> 
  <br/>
        <label><span class="glyphicon glyphicon-earphone"style="font-size:24px;"></span></label>
   <button runat="server" type="button" id="btntelmas" class="btn w3-right" >+</button>
  <input runat="server" class="w3-input"  type="text" id="txtTelefono" placeholder="Telefono" autocomplete="off"/>
        <br/><br/>
 <%--<button  runat="server" id="btngenerar"  style="margin-left:100px" class="btn btn-default btn-lg" >Generar</button>
  <br/>--%>
    </div>

  <div class="w3-third">
  <label><span class="glyphicon glyphicon-user"style="font-size:24px;"></span></label>

  <select runat="server" id="cbejecutiva" class="w3-input" ><option disabled selected>Agregar Ejecutiva</option></select>

  <br/>
      <label> <span class="glyphicon glyphicon-calendar" style="font-size:24px;"></span></label>
  <input runat="server" class="w3-input" type="text" id="txtDcredito" name="Dcredito" placeholder="Dias de credito" autocomplete="off"/> 
  <br/>
  <label><span class=" glyphicon glyphicon-usd" style="font-size:24px;"></span></label>
  <input runat="server" class="w3-input" type="text" id="txtlcredito" placeholder="Limite de Credito" autocomplete="off"/> 
  <br/>
       <label><span class="glyphicon glyphicon-copy"style="font-size:24px;"></span></label>
  <input runat="server" class="w3-input" type="text" id="txtcontacto" placeholder="Contacto" />
  <br/>
       </div>

  <br/><br/><br/><br/>

  <div class="w3-container w3-center">
     <button runat="server" id="btnaceptar" type="button" class="btn btn-default btn-lg">
          <span class="glyphicon glyphicon-ok"></span> Aceptar 
        </button>
  <button runat="server" id="btncancelar" type="button" class="btn btn-default btn-lg">
          <span class="glyphicon glyphicon-remove"></span> Cancelar 
        </button>
      <br/><br/>
  </div>
 </div>

  </fieldset>
</div>
</div>

    <footer class="w3-container w3-deep-orange">
  <h3>  <a href="Buscar.html" class="w3-center ">Buscar</a></h3>
    </footer>


 




 </article>

</asp:Content>
