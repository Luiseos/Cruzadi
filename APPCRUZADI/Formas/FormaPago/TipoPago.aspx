<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="TipoPago.aspx.vb" Inherits="APPCRUZADI.TipoPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<br />
    <br />
  

  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>FORMA DE PAGO</h1>
    </header>

    <div class="w3-container">
      <br/>
      <br/>
      <fieldset>
        <label>Descripcion Pago</label>
        <input runat="server" class="w3-input" type="text" id="txtDescripcion"  placeholder="Descripcion de Estado" style="text-transform: uppercase"  onkeypress="return Letras(event)" onkeyup="DobleEspacio(this, event)" autocomplete="off" required />
        <br/> 

           <div class="container w3-panel w3-round-small ">
                     <h3>

                            <span style="float: right;"><small>Total Tipos de Pago :</small>
                                <asp:Label ID="lbltipopago" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">

                                                
                          <br/> 
          <asp:GridView ID="GVPagos" runat="server" AutoGenerateColumns="false" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="tipo_pago_id" AllowSorting="false" >
              
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
                  <asp:BoundField DataField="tipo_pago_id" HeaderText="ID" />
                  <asp:BoundField DataField="descripcion_pago" HeaderText="Descripcion" />
               </Columns>
          </asp:GridView>
          
          </div></div>
        <br/>
           <br/>
        </fieldset>
        <br/> 
         <div class="w3-container w3-center">
        <button runat="server" id="btnGuardar" class="w3-deep-orange btn-lg" >Agregar</button>
           <button runat="server" id="BtnModificar" class="w3-deep-orange btn-lg"  >Modificar</button>
          
   
       </div>
        <br/>
        
      
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
