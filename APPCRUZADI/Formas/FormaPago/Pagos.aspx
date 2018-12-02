<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Pagos.aspx.vb" Inherits="APPCRUZADI.Pagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <article>


        <div class="w3-card-4" style="width: 100%;">
            <header class="w3-container  w3-center w3-deep-orange">
                <h1>PAGO</h1>
            </header>

        
            <div class="w3-container">
                <br />

                <div class="w3-row w3-border">

                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>Factura</label>
                            <input runat="server" class="w3-input" type="text" id="txtfactura" autocomplete="off" readonly="readonly" />
                            <label>Cliente</label>
                            <input  runat="server" class="w3-input" type="text" id="txtClient" autocomplete="off" readonly="readonly" />
                            <label>Subtotal</label>
                            <input runat="server" class="w3-input" type="text" id="txtSubtotal" autocomplete="off" readonly="readonly" />
                            <label>ISV 15</label>
                            <input runat="server" class="w3-input" type="text" id="txtisv15" autocomplete="off" readonly="readonly" />


                            <%--      <label>Forma De Pago</label>
                            <select class="w3-input" id="cbfpago"></select>
                            <label>POS</label>
                            <select class="w3-input" id="cbpos"></select>
                            <label>Total Pagado</label>
                            <input class="w3-input" type="text" id="txttpagado" placeholder="" autocomplete="off" />--%>
                            <br />
                        </fieldset>

                    </div>
                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>Serie</label>
                            <input runat="server" class="w3-input" type="text" id="txtSerie" autocomplete="off" readonly="readonly" />
                            <label>Razon Social</label>
                            <input runat="server"  class="w3-input" type="text" id="txtRSocial" autocomplete="off" readonly="readonly" />
                            <label>Descuento 15</label>
                            <input runat="server" class="w3-input" type="text" id="txtdescuento15" autocomplete="off" readonly="readonly" />
                            <label>ISV 18</label>
                            <input runat="server"  class="w3-input" type="text" id="txtisv18" autocomplete="off" readonly="readonly" />
                            <%--      <label>Forma De Pago</label>
                            <select class="w3-input" id="cbfpago"></select>
                            <label>POS</label>
                            <select class="w3-input" id="cbpos"></select>
                            <label>Total Pagado</label>
                            <input class="w3-input" type="text" id="txttpagado" placeholder="" autocomplete="off" />--%>
                            <br />
                        </fieldset>
                    </div>
                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>Folio</label>
                            <input runat="server" class="w3-input" type="text" id="txtfolio" autocomplete="off" readonly="readonly" />
                            <label>RTN</label>
                            <input runat="server" class="w3-input" type="text" id="txtrtn" autocomplete="off" readonly="readonly" />
                            <label>Descuento 18</label>
                            <input runat="server" class="w3-input" type="text" id="txtdescuento18" autocomplete="off" readonly="readonly" />
                            <label>Total </label>
                            <input runat="server" class="w3-input" type="text" id="txtTotal" autocomplete="off" readonly="readonly" />
                                              <br />
                        </fieldset>
                    </div>

                </div>

            </div>

            <br />
            <br />
            <div class="w3-container">
                <br />

                <div class="w3-row w3-border">

                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>Forma De Pago</label>
                            <select runat="server" class="w3-input" id="cbfpago"></select>
                            <label>ISV 15</label>
                            <input runat="server" class="w3-input" type="text" id="txtisv15BD" autocomplete="off" />
                            <label>Descuento 8%</label>
                            <input runat="server" class="w3-input" type="text" id="txtdescuento8" autocomplete="off"  disabled="disabled"/>


                            <br />
                        </fieldset>

                    </div>
                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>POS</label>
                            <select runat="server" class="w3-input" id="cbpos" disabled="disabled"></select>

                            <label>ISV 18</label>
                            <input runat="server" class="w3-input" type="text" id="txtisv18BD" autocomplete="off" />
                            <label>Total </label>
                            <input runat="server" class="w3-input" type="text" id="txtTotalBD" autocomplete="off" />

                            <br />
                        </fieldset>
                    </div>
                    <div class="w3-third">
                        <br />
                        <fieldset>
                            <label>Subtotal</label>
                            <input runat="server" class="w3-input" type="text" id="txtSubtotalBd" autocomplete="off" readonly="readonly" />

                            <label>Retenciones</label>
                            <input runat="server" class="w3-input" type="text" id="txtRetenciones" autocomplete="off" />


                            <br />
                        </fieldset>
                    </div>
                    <br />
                    <br />
                </div>

            </div>
        </div>
      
    </article>

    
        <br/>
        <br/>

          <div class="w3-container w3-center">
              <div class="w3-half" >
  <button runat="server" id="BtnGuardar" class="w3-deep-orange btn-lg" type="button"><span class="glyphicon glyphicon-ok"></span>Guardar</button>
                <%-- </div>
                <div class="w3-half">--%>
                   <button runat="server" id="BtnCancelar" class="w3-deep-orange btn-lg" type="reset"><span class="glyphicon glyphicon-remove"></span>Cancelar</button>
      
             </div>

            </div>

    
  <footer class="w3-container w3-deep-orange">
            <a href="/inicio.aspx" style='color: white'>
                <h3>INICIO</h3>
            </a>

    </footer>
 
      


</asp:Content>
