<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="GestionCC.aspx.vb" Inherits="APPCRUZADI.GestionCC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /> <br /> 
    
  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
      <h1>Estado de Cuenta </h1>
    </header>
      <div class="form-group">
                    <div class="w3-container w3-center">
            
  <button runat="server" id="BtnBuscarCliente" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Buscar Cliente</button>

                    </div>
                            </div>
    <div class="w3-container">
      <br/>
  
      <div class="w3-row w3-border">
    <div class="w3-third">
      <br/>
      <fieldset>
             <br/>
        <label>Cuenta</label>
           <input runat="server" class="w3-input" type="text" id="TxtNombreCuenta" placeholder="Nombre" autocomplete="off"   disabled="disabled"/>

         <label>Cliente</label>
      <%--  <select class="w3-input"  id="cbcliente" style="text-transform: uppercase" required></select> 
    --%> 
            <input runat="server" class="w3-input" type="text" id="txtACliente" placeholder="Cliente" autocomplete="off" disabled="disabled"/>
                <label>Saldo</label>
        <input runat="server" class="w3-input" type="text" onkeypress="return Numeros(event)" id="txtsaldo" style="text-transform: uppercase" placeholder="Saldo" autocomplete="off" required/>
        <br/>
        </fieldset>
    </div>

    <div class="w3-third">
      <br/>
      <fieldset>
                      <br/>
      <label>Tipo De Cliente</label>
        <input runat="server" class="w3-input" type="text" id="txttipocliente"  placeholder="Tipo de Cliente" autocomplete="off" style="text-transform: uppercase" required/>
        <label>Dias De Credito</label>
        <input runat="server" class="w3-input" type="text" id="txtdcredito" maxlength="3"  placeholder="Dias de Credito" autocomplete="off" onkeypress="return Numeros(event)"  required/>
        <label>Limite de Credito</label>
        <input runat="server" class="w3-input" type="text" id="txtlcredito"  placeholder="Limite de Credito" autocomplete="off" onkeypress="return Numeros(event)" required/>
        </fieldset>
    </div>
    <div class="w3-third">
      <br/>
        <fieldset>
                        <br/>
        <label>Ejecutiva</label>
        <input runat="server" class="w3-input" type="text" id="txtejecutiva" style="text-transform: uppercase" placeholder="Ejecutiva" autocomplete="off" onkeyup="Espacio(this, event)" onkeypress="return Letras(event)" />
        <label>Email</label>
        <input runat="server" class="w3-input" type="text" id="txtemail" style="text-transform: uppercase" placeholder="Email" autocomplete="OFF"/>
        <label>Telefono</label>
        <input runat="server" class="w3-input" type="text" id="txttelefono"  placeholder="Telefono" autocomplete="off" onkeypress="return Numeros(event)" required/>
        </fieldset>
    </div> 
        <br/>
        <br/>
    </div>
    
      </div> 
        <br/>
        <br/>
      <%--  --%>

       <section>
  <fieldset >
      <legend>A Gestionar</legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total a Gestionar :</small>
                                <asp:Label ID="lblGestionartotal" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVGestionar" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="Serie" AllowSorting="false">
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

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="lblPaginadorGestionar" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

    </section>


      <%--  --%>
       <div class="form-group">
                          <div class="w3-container w3-center">
            
  <button runat="server" id="BtnGestionar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Gestionar Cliente</button>

                    </div>
                 </div>
      <%--  --%>
       <section>
  <fieldset>

           <legend>Gestionados</legend>
                    <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total Gestionados :</small>
                                <asp:Label ID="lblGestionadostotal" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVGestionados" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="cliente_id" >
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

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorGestionados" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

        </section>

           <%--  --%>

       <section>
  <fieldset >
      <legend>Pagados </legend>
                         <div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total a Gestionar :</small>
                                <asp:Label ID="LblTotalpagados" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />
                            <asp:GridView ID="GVPAgados" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="cliente_id" AllowSorting="false">
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

                            </asp:GridView>



                            <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorpagos" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />

                        </div>

                    </div>
                    <br />

                </fieldset>

    </section>


    <%--  --%>



     <footer class="w3-container w3-deep-orange">
            
            <a href="/inicio.aspx" style='color: white'>
                    <h3>INICIO</h3>
            </a>

    </footer>
     </div>
     


      <!-- Modal cCXC
    --------------------------------------------------------------------->
<%--    data-backdrop=”static” data-keyboard="false"--%>

        <div class="modal" id="GESTION"  tabindex="-1"  role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Cabecera -->
                <div class="modal-header">
                    <h4 class="modal-title  w3-center w3-deep-orange" id="myModalLabel">Gestion</h4>

                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Cerrar</span>
                    </button>

                </div>

                <!-- Modal Cuerpo contenido -->

                <div class="modal-body">
                    <p class="statusMsg"></p>

                      <div class="form-group">
                        <fieldset>

        <div>
   <label>Cliente</label>
        <input runat="server" id="txtClientemodal" class="w3-input" type="text"   autocomplete="off" />
            <br />
      </div>
        
                <div class="w3-half">
       <label> Tipo de Gestion</label>
       <br>
        <select runat="server" id="cbtipodGestionmodal" class="w3-input"></select>
      </div>
               

 <div class="w3-half">
        <label>Fecha Programada</label>
        <input runat="server" class="w3-input" type="date" id="txtfechaprogramadas"  autocomplete="off" />
         </div>
        <br/>         <br/> 
                            <div>

                         
        <label>Descripcion</label>
                            <textarea runat="server" class="w3-input"  id="txtdesripcion" ></textarea>
<%--        <input runat="server" class="w3-input" type="text" id="txtdesripcion"  autocomplete="off" />--%>
          </div>
                                 <br/>
               <br/>
        </fieldset>
                        </div>                                                                            
                </div>

                <!-- Modal Pie de Página -->
                 <div class="modal-footer">
          <button runat="server" id="btnguardar"  class="w3-deep-orange btn-lg" >Guardar</button>
          <button type="button"  class="w3-deep-orange btn-lg" data-dismiss="modal">Cancelar</button>
                         </div>
                          </div>                        
                     </div>
        </div>

    <!-- Modal Fin IT-->


    <%--  --%>
    <%--  --%>
    <%--  --%>
      <%--  --%>
       <!-- Modal Gestion factura detallada
    --------------------------------------------------------------------->
<%--    data-backdrop=”static” data-keyboard="false"--%>

<%--        <div class="modal" id="FActDetallada"  tabindex="-1"  role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
        <div class="modal-dialog">
            <div class="modal-content">

                <!-- Modal Cabecera -->
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel1">Factura Detallada</h4>

                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span>
                        <span class="sr-only">Cerrar</span>
                    </button>

                </div>

                <!-- Modal Cuerpo contenido -->

                <div class="modal-body">
                    <p class="statusMsg"></p>
                                      <div class="form-group">
                            <label >Serie</label>
                            <input runat="server" type="text" class="form-control" id="Txtserie" Readonly="readonly" autocomplete="off" />
                        </div>
                                             <div class="form-group">
                            <label >Factura</label>
                            <input runat="server" type="text" class="form-control" id="Txtfactura" Readonly="readonly" autocomplete="off" />
                        </div>
                    <div class="form-group">
                        <label>Folio </label>
                        <input runat="server" type="TEXT" class="form-control" id="TXTFolio" readonly="readonly" autocomplete="off" />
                    </div>
                              <div class="form-group">
                            <label >RTN</label>
                            <input runat="server" type="text" class="form-control" id="TxtRtn" Readonly="readonly" autocomplete="off" />
                        </div>
                              <div class="form-group">
                            <label >Razon Social</label>
                            <input runat="server" type="text" class="form-control" id="TxtRazonSocial" Readonly="readonly" autocomplete="off" />
                        </div>
                         <div class="form-group">
                            <label >Fecha</label>
                            <input runat="server" type="text" class="form-control" id="Txtfechages" Readonly="readonly" autocomplete="off" />
                        </div>
                       <div class="form-group">
                            <label >Cliente</label>
                            <input runat="server" type="text" class="form-control" id="TxtClienteges" Readonly="readonly" autocomplete="off" />
                        </div>
                       <div class="form-group">
                            <label >CodigoCliente</label>
                            <input runat="server" type="text" class="form-control" id="TxtCodCliente" Readonly="readonly" autocomplete="off" />
                        </div>
                       <div class="form-group">
                            <label >Forma de Pago</label>
                            <input runat="server" type="text" class="form-control" id="TxtFpago" Readonly="readonly" autocomplete="off" />
                        </div>
                       <div class="form-group">
                            <label >Sub Total</label>
                            <input runat="server" type="text" class="form-control" id="TxtSubTotalges" Readonly="readonly" autocomplete="off" />
                        </div>
                       <div class="form-group">
                            <label >Descuento 15</label>
                            <input runat="server" type="text" class="form-control" id="TxtDescquince" Readonly="readonly" autocomplete="off" />
                        </div>
                     <div class="form-group">
                            <label >Descuento 18</label>
                            <input runat="server" type="text" class="form-control" id="Txtdesdieciocho" Readonly="readonly" autocomplete="off" />
                        </div>
                      <div class="form-group">
                            <label >ISV 15</label>
                            <input runat="server" type="text" class="form-control" id="TxtISV15" Readonly="readonly" autocomplete="off" />
                        </div>
                      <div class="form-group">
                            <label >ISV 18</label>
                            <input runat="server" type="text" class="form-control" id="TxtISV18" Readonly="readonly" autocomplete="off" />
                        </div>
                      <div class="form-group">
                            <label >Total</label>
                            <input runat="server" type="text" class="form-control" id="TxtTotal" Readonly="readonly" autocomplete="off" />
                        </div>
                        <br>
                        <br>

                      
                                      
                </div>

                <!-- Modal Pie de Página -->
                          </div>
        </div>
    </div>

    <!-- Modal Fin IT-->--%>
      
    <%--  --%>
    <%--  --%>
   <%--  <div id="FActDetallada" class="w3-modal">--%>
               <div class="modal" id="FActDetallada"  tabindex="-1"  role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" >
        <div class="modal-dialog">
    <div class="w3-modal-content">
      <header class="w3-container w3-deep-orange"> 
        <span onclick="document.getElementById('FActDetallada').style.display='none'" 
        class="w3-button w3-display-topright">&times;</span>
        <h2>Factura Detallada</h2>
      </header>
        <div class="w3-container">
         <div class="w3-third w3-container">
          <br /><br />
        <label>Serie</label>
        <input runat="server" class="w3-input" type="text" id="Txtserie" placeholder="Serie" disabled="disabled" />
        <label>Razon Social</label>
        <input runat="server" class="w3-input" type="text" id="TxtRazonSocial" placeholder="Razon Social" disabled="disabled" />
        <label>Codigo Cliente</label>
        <input runat="server" class="w3-input" type="text" id="TxtCodCliente" placeholder="Codigo Cliente" disabled="disabled" />
        <label>Sub-Total</label>
        <input runat="server" class="w3-input" type="text" id="TxtSubTotalges" placeholder="Sub-Total" disabled="disabled" />
         <label>Descuento 15</label>
        <input runat="server" class="w3-input" type="text" id="TxtDescquince" placeholder="Descuento" disabled="disabled" />
       
      
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Factura</label>
        <input runat="server" class="w3-input" type="text" id="Txtfactura" placeholder="Factura" disabled="disabled" />
        <label>RTN</label>
        <input runat="server" class="w3-input" type="text" id="TxtRtn" placeholder="RTN" disabled="disabled" />
        <label>Fecha</label>
        <input runat="server" class="w3-input" type="text" id="Txtfechages" placeholder="Fecha" disabled="disabled" />
        <label>ISV 15%</label>
        <input runat="server" class="w3-input" type="text" id="TxtISV15" placeholder="ISV 15%" disabled="disabled" />
        <label>Descuento 18</label>
        <input runat="server" class="w3-input" type="text" id="Txtdesdieciocho" placeholder="Descuento" disabled="disabled" />
       
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Folio</label>
        <input runat="server" class="w3-input" type="text" id="TXTFolio" placeholder="Folio" disabled="disabled" />
        <label>Cliente</label>
        <input runat="server" class="w3-input" type="text" id="TxtClienteges" placeholder="Cliente" disabled="disabled" />
            <label>Forma de Pago</label>
        <input runat="server" class="w3-input" type="text" id="TxtFpago" placeholder="Forma de Pago" disabled="disabled" />
        
        <label>ISV 18%</label>
        <input runat="server" class="w3-input" type="text" id="TxtISV18" placeholder="ISV 18%" disabled="disabled" />
     

        <label>Total</label>
        <input runat="server" class="w3-input" type="text" id="TxtTotal" placeholder="Total" disabled="disabled" />
  </div>
      </div>
      <br>
      <br>

      <footer class="w3-container w3-center w3-deep-orange">
        <p>CRUZADI</p>
      </footer>
    </div>
  </div>
     </div>

      
    <%--  --%>
    <%--  --%>

      <%--  --%>



    


  <div id="DetallePago" class="w3-modal">
    <div class="w3-modal-content">
      <header class="w3-container w3-deep-orange"> 
        <span onclick="document.getElementById('DetallePago').style.display='none'" 
        class="w3-button w3-display-topright">&times;</span>
        <h2>Detalle de Pago</h2>
      </header>
        <div class="w3-container">
         <div class="w3-third w3-container">
 <br /><br />
        <label>Serie</label>
        <input runat="server" class="w3-input" type="text" id="txtseriemo" placeholder="Serie" disabled="disabled" />
        <label>Fecha de Pago</label>
        <input runat="server" class="w3-input" type="text" id="txtfechapagomo"  disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Factura</label>
        <input runat="server" class="w3-input" type="text" id="txtfacturamo" placeholder="Factura" disabled="disabled" />
        <label>Tipo De Pago</label>
        <input runat="server" class="w3-input" type="text" id="txtfechaprogramacionmo" disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Folio</label>
        <input runat="server" class="w3-input" type="text" id="txtfoliomo" placeholder="Folio" disabled="disabled" />
        <label>Total Pagado</label>
        <input runat="server" class="w3-input" type="text" id="txttpagomo" disabled="disabled" />
  </div>
  
  
      </div>
      <br/><br/>
      <footer class="w3-container w3-center w3-deep-orange">
        <p>Cruzadi</p>
      </footer>
    </div>
  </div>

        
    <%--  --%>
    <%--  --%>

    
  <div id="GestionRealizadas" class="w3-modal">
    <div class="w3-modal-content">
      <header class="w3-container w3-deep-orange"> 
        <span onclick="document.getElementById('GestionRealizadas').style.display='none'" 
        class="w3-button w3-display-topright">&times;</span>
        <h2>Detalle de Gestion</h2>
      </header>
        <div class="w3-container">
         <div class="w3-third w3-container">
      <br /> <br />
        <label>ID Cliente</label>
        <input runat="server" class="w3-input" type="text" id="txtidclienteGes"  disabled="disabled" />
        <label>Fecha de Emision</label>
        <input runat="server" class="w3-input" type="text" id="txtfechaemisionges"  disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Usuario</label>
        <input runat="server" class="w3-input" type="text" id="txtusuarioges"  disabled="disabled" />
        <label>Fecha De Programacion</label>
        <input runat="server" class="w3-input" type="text" id="txtfechaprogramacionges"  disabled="disabled" />
  </div>
   <div class="w3-third w3-container">
     <br/> <br/>
        <label>Tipo De Gestion</label>
        <input runat="server" class="w3-input" type="text" id="txttipogestionges" disabled="disabled" />
  </div>
  
  <div class="w3-container">
    <label>Descripcion</label>
<textarea runat="server" class="w3-input" disabled="disabled" id="txtdescripcionges" placeholder="descripciones"></textarea>
    </div>
      </div>
      <br/><br/>
      <footer class="w3-container w3-center w3-deep-orange">
        <p>Cruzadi</p>
      </footer>
    </div>
  </div>

</asp:Content>
