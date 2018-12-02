<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ComisionesCC.aspx.vb" Inherits="APPCRUZADI.EjecutivaCC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /> <br /> 

  <div class="w3-card-4"  style="width:100%;">
    <header class="w3-container w3-center w3-deep-orange">
            <h1>Comision de Credito </h1>
    </header>

        <div class="w3-center" >
        <h2 class="w3-center" >Parametros de Fechas</h2>

       <input runat="server" id="TxtFechaInicio" type="date" />
              <input runat="server" id="TxtFechaFinal" type="date" />
       <br />
            </div>
    <div class="w3-container">
      <br/>
  
      <div class="w3-row w3-border">
    <div class="w3-third w3-container">
      <br/>
      <fieldset>
    <label>Total De Cobros Netos</label>
        <input runat="server" class="w3-input" type="text" id="txtcobrosnetos" placeholder="Cobros Netos" autocomplete="off" />
         <label>Canjes</label>
        <input runat="server" class="w3-input" type="text" id="txtcanjes"  placeholder="Canjes" autocomplete="off"/>
        <label>Retenciones</label>
        <input runat="server" class="w3-input" type="text" id="txtretenciones"  placeholder="Retenciones" autocomplete="off"/>
        <br/>
        </fieldset>
    </div>
    <div class="w3-third w3-container">
      <br/>
       <label>Comision POS BAC</label>
        <input runat="server" class="w3-input" type="text" id="txtbac"  placeholder="BAC"  autocomplete="off"/>
         <label>Comision POS Ficohsa</label>
        <input runat="server" class="w3-input" type="text" id="Txtficohsa"  placeholder="Ficohsa"  autocomplete="off"/>
         <label>Total Comisionable</label>
        <input runat="server" class="w3-input" type="text" id="Txtcomisionable"  placeholder="Total Comisionable"  autocomplete="off"/>
        <br/>
      </div>

   <div class="w3-third w3-container">
      <br/>
      <fieldset>
         <label>Comision</label>
        <input  runat="server" class="w3-input" type="text" id="txtcomision"  placeholder="Comision" autocomplete="off"/>
        <label>Comision Credito</label>
        <input runat="server" class="w3-input" type="text" id="txtcomisioncredito"  placeholder="70%" autocomplete="off"/>
        <label>Comision Facturas</label>
        <input runat="server" class="w3-input" type="text" id="txtcomisionfacturas"  placeholder="30%" autocomplete="off"/>
      <br/>
        </fieldset>
        </div>
          
    </div>
      </div> 
        <br/>
         
        <div class="w3-container w3-center">
        <button runat="server" id="btnagregar" class="w3-deep-orange btn-lg" >Calcular</button>
         
            </div> <br/><br/>
      
    </div>

      <br/>
      <br/>
    <fieldset>
     
<div class="container w3-panel w3-round-small ">
                        <h3>

                            <span style="float: right;"><small>Total de datos :</small>
                                <asp:Label ID="lblTotalesComisiones" runat="server" CssClass="label label-warning" /></span>
                        </h3>

                        <div class="table-responsive">


                            <br />

     <asp:GridView ID="GvComisionesCC" runat="server" AutoGenerateColumns="true" AllowPaging="True" CssClass="table table-bordered bs-table " DataKeyNames="cliente_id" AllowSorting="false">
    <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />

                                <EditRowStyle BackColor="#ffffcc" />
                                <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                <EmptyDataTemplate>
                                    ¡No hay Registros seleccionados!  
                                </EmptyDataTemplate>

                                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />

                                <RowStyle BackColor="#f5f5f0"
                                    Font-Italic="true"
                                    HorizontalAlign="Center" />


                                <%-- <alternatingrowstyle backcolor= #e0e0d1 
          font-italic="true"/>--%>
                                
                              
     </asp:GridView>
                                 <div class="row" style="margin-top: 20px;">

                                <div class="col-lg-10" style="text-align: right;">
                                    <h3>
                                        <asp:Label ID="LblPaginadorComisionesCC" runat="server" CssClass="label label-warning" /></h3>
                                </div>
                            </div>

                            <br />
                            <br />
                            </div>
  </div>
        </fieldset>

     <footer class="w3-container w3-deep-orange">
            <a href="/inicio.aspx" style='color: white'>
                   <h3>INICIO</h3>
            </a>

    </footer>
 
</asp:Content>
