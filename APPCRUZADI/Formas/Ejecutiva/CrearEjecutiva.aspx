<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="CrearEjecutiva.aspx.vb" Inherits="APPCRUZADI.CrearEjecutiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
  <br />
    <br />
    
    <div class="w3-card-4" style="width:100%">
    <header class="w3-container  w3-center w3-deep-orange">
      <h1>Crear Ejecutiva </h1>
    </header>

    <div class="w3-container">
      <br/>
  
      <div class="w3-row w3-border">
    <div class="w3-container w3-half">
      <br/>
      <fieldset>
               <br />
    <label>Nombre</label>
        <input runat="server" class="w3-input" type="text" id="Txtejecutiva" placeholder="Nombre de Ejecutiva" style="text-transform: uppercase"  onkeypress="return Letras(event)" onkeyup="DobleEspacio(this, event)" autocomplete="off" required />
             <br />
           <label>Usuario</label>
        <input runat="server" class="w3-input" type="text" id="txtsiglas"  maxlength="5"    placeholder="Usuario" onkeyup="Espacio(this, event)" onkeypress="return Letras(event)" style="text-transform: uppercase" autocomplete="off"  required/>
                      <br />

      </fieldset>
    </div>

    <div class="w3-container w3-half">
      <br/>
      <fieldset>
               <br />
      <label>Email</label>
        <input runat="server" class="w3-input" type="email" id="txtemail" style="text-transform: uppercase" onkeyup="DobleEspacio(this, event)" autocomplete="off"  placeholder="Email" required/>
           <asp:RegularExpressionValidator ID="REVEmailR" runat="server" ForeColor="#FF3300" ErrorMessage="Correo Invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="TxtEmail"></asp:RegularExpressionValidator>
                               <br />
          <label>Telefono</label>
        <input runat="server"  type="text" autocomplete="off" onkeyup="Espacio(this, event)" onkeypress="return Numeros(event)" class="w3-input"  id="Txttel"  placeholder="Numero Telefonico" required/>
                  
            <br />  
      </fieldset>
          <br/>
    </div>
      </div> 
               <div class="w3-container w3-center">      
        <fieldset> 
            <br />
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de Ejecutivas :</small>
                                <asp:Label ID="lblTotalesEjecutiva" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
            <asp:GridView ID="GVCrearEjecutiva" runat="server" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Ejecutiva_id" AllowSorting="false">
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />

              <Columns>
                  <asp:BoundField DataField="Ejecutiva_id" HeaderText="ID" />
                  <asp:BoundField DataField="Nombre_Ejecutiva" HeaderText="Ejecutiva" />
                   <asp:BoundField DataField="Siglas" HeaderText="Siglas" />
                   <asp:BoundField DataField="Email" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
             

               </Columns>
          </asp:GridView>
                                   <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorEjecutiva" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                            </div></div>
        </fieldset>
                   </div>

        <br/>
     
              <br/>
        <div class="w3-container w3-center">

                <button runat="server" id="btnguardar" class="w3-deep-orange btn-lg">Guardar</button>
                <button runat="server" id="BtnModificar" class="w3-deep-orange btn-lg" >Modificar</button>
                 
            </div>
      
    </div>

      <br/>
      <br/>

    <footer class="w3-container w3-deep-orange">
            
            <a href="/inicio.aspx" style='color: white'>
              <h3>INICIO</h3>
            </a>

        </footer>
  </div>

</asp:Content>
