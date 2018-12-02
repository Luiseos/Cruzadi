<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Principal.Master" CodeBehind="Registro.aspx.vb" Inherits="APPCRUZADI.Modal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Registro" class="w3-modal" data-backdrop="static" role="main"    >
        <div class="w3-modal-content w3-card-4 w3-animate-zoom " style="max-width:500px">
        
            <header class="w3-container w3-deep-orange">
                <span onclick="document.getElementById('Registro').style.display='none'" class="w3-button w3-xlarge w3-hover-red w3-display-topright" title="Close Modal">&times;</span>

                <h2>Resgistrese</h2>
            </header>
       <br />

        <div class="w3-section"  >
            <fieldset>
          <label><b>Nombre</b></label>
          <input runat="server" id="TxtNombre"  onblur="textChanged()" class="text-uppercase w3-input  w3-border" type="text" placeholder="Ingrese Nombre" name="Nombre" required>
            <label><b>Usuario</b></label>
          <input runat="server" id="TxtUsuarioR"  class="text-uppercase w3-input w3-border w3-margin-bottom" type="text" placeholder="Ingrese el Usuario" name="usuario"  >

          <label><b>Contrase&ntilde;a</b></label>
          <input runat="server"   onkeyup="Espacio(this, event)" id="TxtContraseñaR" class="w3-input w3-border w3-margin-bottom" type="password" placeholder="Ingrese Contrase&ntilde;a" name="usrname" required>
                <asp:CustomValidator ID="CstContraseñaR" runat="server" ErrorMessage="Contraseña Valida" ForeColor="#FF3300"  ControlToValidate="TxtContraseñaR"></asp:CustomValidator>
             <br />
                               
                 <label><b>Confirme Contrase&ntilde;a</b></label>
          <input runat="server" onkeyup="Espacio(this, event)" id="TxtContraseñaConfirmar" class="w3-input w3-border w3-margin-bottom" type="password" placeholder="Confirme Contrase&ntilde;a" name="" required>
                <asp:CompareValidator ID="CVComparador" runat="server" ErrorMessage="Contraseña no son iguales" ForeColor="#FF3300" ControlToCompare="TxtContraseñaR" ControlToValidate="TxtContraseñaConfirmar"></asp:CompareValidator>
           <br />
        <label><b>E-mail</b></label>
          <input runat="server" id="TxtEmail" class="w3-input w3-border w3-margin-bottom" type="Email" placeholder="Ingrese Su Correo Electronico" name="usrname" required>
                <asp:RegularExpressionValidator ID="REVEmailR" runat="server"  ForeColor="#FF3300" ErrorMessage="Correo Invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail"></asp:RegularExpressionValidator>
                </fieldset>
            
            <%--class="w3-button w3-block w3-deep-orange w3-section w3-padding"--%>
            <button runat="server" id="BtnGuardar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="button"  >Guardar</button>
          <button runat="server" id="BtnCancelar" class="w3-button w3-block w3-deep-orange w3-section w3-padding" type="reset">Cancelar
         </button>
           </div>
    

      </div>
    </div>
     
</asp:Content>
