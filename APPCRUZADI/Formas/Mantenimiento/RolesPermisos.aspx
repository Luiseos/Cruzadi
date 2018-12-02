<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="RolesPermisos.aspx.vb" Inherits="APPCRUZADI.Roles1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1 {
            width: 24px;
            height: 24px;
            position: relative;
            top: 6px;
            left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
<div class="w3-container">
  

  <div class="w3-card-4" style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1> Permisos de Roles y Pantallas</h1>
    </header>

    <div class="w3-container">
      <div class="container w3-panel w3-round-small">
     <fieldset>
          <legend> Elegir Rol</legend>
         <label>Rol</label>
         <select  runat="server" id="CbRol" class="w3-input"><option disabled selected>Selecciona una opcion</option></select>
         <br/> 
         </fieldset>

      </div>
      <div class="container w3-panel w3-round-small">
      <fieldset>
        <legend> Asignar Permisos Del Rol</legend>
         <label>Objeto</label>
         <select  runat="server" id="cbobjetos" class="w3-input"><option disabled selected>Selecciona una opcion</option></select>
         <br/>
        <input runat="server" id="ckconsulta" class="w3-check" type="checkbox" checked="" style="margin-left:20% "/>Consulta
        <input runat="server" id="ckinsertar" class="w3-check" type="checkbox" checked="" style="margin-left:100px "/>Insertar
        <input runat="server" id="ckmodificar" class="w3-check" type="checkbox" checked="" style="margin-left:100px "/>Modificar
        <%--<input runat="server" id="ckeliminar" class="auto-style1" type="checkbox" checked="" style="margin-left:100px "/>Eliminar--%>
        <br/><br/>
        
          
          
         <%--  <table class="w3-table w3-striped">
    <tr>
      <th>Objeto</th>
      <th>Consulta</th>
      <th>Insertar</th>
      <th>Modificar</th>
      <th>Eliminar</th>
    </tr>
    <tr>
      <td>Jill</td>
      <td>Smith</td>
      <td>50</td>
    </tr>
    <tr>
      <td>Eve</td>
      <td>Jackson</td>
      <td>94</td>
    </tr>
    <tr>
      <td>Adam</td>
      <td>Johnson</td>
      <td>67</td>
    </tr>
  </table>--%>
      </fieldset>
      </div>   
    <br/>
            <br/>
  <div class="w3-container w3-center">
    <button runat="server" id="btnagregar" class="w3-deep-orange btn-lg" >Agregar</button>
         <button runat="server" id="btncancelarpermiso" class="w3-deep-orange btn-lg" >cancelar</button>
      </div>
            <br/>
    <footer class="w3-container w3-deep-orange">
       <a href="/inicio.aspx"  style='color: white'>
            <h3>INICIO</h3>
        </a>

    </footer>
  </div>
</div>
</div>
</asp:Content>


<%--<div class="w3-third">
    <fieldset  >
   <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar">
  <label></label></p>
  <p>
  <input class="w3-radio" type="radio" name="tiporol" value="Consultar">
  <label></label></p>
  <p>
  <input class="w3-radio" type="radio" name="tiporol" value="eliminar">
  <label></label></p>
  <p>
  <input class="w3-radio" type="radio" name="tiporol" value="Actualizar">
  <label></label></p>
     <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar">
  <label></label></p>
     <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar">
  <label></label></p>
     <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar" >
  <label></label></p>
     <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar" >
  <label></label></p>
  <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar" >
  <label></label></p>
  <p><input class="w3-radio" type="radio" name="tiporol" value="Insertar" >
  <label></label></p>
 </fieldset  >

       </div>--%>